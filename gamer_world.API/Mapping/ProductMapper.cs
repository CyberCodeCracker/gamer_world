using AutoMapper;
using gamer_world.Core.DTO;
using gamer_world.Core.Entities.Product;

namespace gamer_world.API.Mapping
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDTO>
                ().ForMember(x => x.CategoryName,
                x => x.MapFrom(src => src.Category.Name))
                .ReverseMap()
                ;
        }
    }
}
