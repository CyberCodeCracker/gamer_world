using AutoMapper;
using gamer_world.Core.DTO;
using gamer_world.Core.Entities.Product;

namespace gamer_world.API.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryRequest, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequest, Category>().ReverseMap();
        }
    }
}
