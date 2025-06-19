using gamer_world.Core.Entities.Product;
using gamer_world.Core.Interfaces;
using gamer_world.Infrastructure.Data;

namespace gamer_world.Infrastructure.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}