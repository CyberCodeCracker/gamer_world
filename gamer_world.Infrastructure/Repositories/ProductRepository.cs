using AutoMapper;
using gamer_world.Core.DTO;
using gamer_world.Core.Entities.Product;
using gamer_world.Core.Interfaces;
using gamer_world.Core.Services;
using gamer_world.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace gamer_world.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly AppDbContext context;
    private readonly IMapper mapper;
    private readonly IImageManagementService imageManagementService;
    public ProductRepository(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService) : base(context)
    {
        this.context = context;
        this.mapper = mapper;
        this.imageManagementService = imageManagementService;
    }

    public async Task<bool> AddAsync(AddProductDTO ProductDTO)
    {
        if (ProductDTO is null)
        {
            return false;
        }
        var product = mapper.Map<Product>(ProductDTO);
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();

        var ImagePath = await imageManagementService.AddImageAsync(ProductDTO.Photos, ProductDTO.Name);
        var photo = ImagePath.Select(Path => new Photo
        {
            ImageName = Path,
            ProductId = product.Id
        }).ToList();
        await context.Photos.AddRangeAsync(photo);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(UpdateProductDTO UpdateProductDTO)
    {
        if (UpdateProductDTO is null)
        {
            return false;
        }
        var existingProduct = await context.Products
            .Include(m => m.Category)
            .Include(m => m.Photos)
            .FirstOrDefaultAsync(m => m.Id == UpdateProductDTO.Id)
            ;
        if (existingProduct is null)
        {
            return false;
        }
        mapper.Map(UpdateProductDTO, existingProduct);

        var existingPhotos = existingProduct.Photos;

        foreach (var item in existingPhotos)
        {
            imageManagementService.DeleteImageAsync(item.ImageName);
        }
        context.Photos.RemoveRange(existingPhotos);

        var ImagePath = await imageManagementService.AddImageAsync(UpdateProductDTO.Photos, UpdateProductDTO.Name);

        var photo = ImagePath.Select(path => new Photo
        {
            ImageName = path,
            ProductId = UpdateProductDTO.Id
        }).ToList()
        ;

        await context.Photos.AddRangeAsync(photo);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(Product product)
    {
        var photos = await context.Photos
            .Where(m => m.ProductId == product.Id)
            .ToListAsync();
        foreach (var item in photos)
        {
            imageManagementService.DeleteImageAsync(item.ImageName);
        }
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }
}