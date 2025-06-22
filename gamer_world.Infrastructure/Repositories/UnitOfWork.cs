using AutoMapper;
using gamer_world.Core.Interfaces;
using gamer_world.Core.Services;
using gamer_world.Infrastructure.Data;

namespace gamer_world.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IImageManagementService _imageManagementService;
    public ICategoryRepository CategoryRepository { get; }
    public IPhotoRepository PhotoRepository { get; }
    public IProductRepository ProductRepository { get; }

    public UnitOfWork(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService)
    {
        _context = context;
        _mapper = mapper;
        _imageManagementService = imageManagementService;

        CategoryRepository = new CategoryRepository(_context);
        PhotoRepository = new PhotoRepository(_context);
        ProductRepository = new ProductRepository(_context, _mapper, _imageManagementService);
    }
}