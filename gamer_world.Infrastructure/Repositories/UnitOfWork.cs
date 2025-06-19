using gamer_world.Core.Interfaces;
using gamer_world.Infrastructure.Data;

namespace gamer_world.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public ICategoryRepository CategoryRepository { get; }
    public IPhotoRepository PhotoRepository { get; }
    public IProductRepository ProductRepository { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        CategoryRepository = new CategoryRepository(_context);
        PhotoRepository = new PhotoRepository(_context);
        ProductRepository = new ProductRepository(_context);
    }
}