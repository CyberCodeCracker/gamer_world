using gamer_world.Core.Entities.Product;
using gamer_world.Core.Interfaces;
using gamer_world.Infrastructure.Data;

namespace gamer_world.Infrastructure.Repositories;

public class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
{
    public PhotoRepository(AppDbContext context) : base(context)
    {
    }
}