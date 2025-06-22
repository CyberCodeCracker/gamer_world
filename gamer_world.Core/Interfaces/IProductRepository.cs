using gamer_world.Core.DTO;
using gamer_world.Core.Entities.Product;

namespace gamer_world.Core.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<bool> AddAsync(AddProductDTO ProductDTO); 

    Task<bool> UpdateAsync(UpdateProductDTO UpdateProductDTO);

    Task DeleteAsync(Product product);
}