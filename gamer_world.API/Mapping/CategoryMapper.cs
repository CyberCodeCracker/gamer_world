using AutoMapper;
using gamer_world.Core.DTO;
using gamer_world.Core.Entities.Product;

namespace gamer_world.API.Mapping
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequest, Category>().ReverseMap();
        }
    }
}
