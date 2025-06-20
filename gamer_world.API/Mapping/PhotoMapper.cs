using AutoMapper;
using gamer_world.Core.DTO;
using gamer_world.Core.Entities.Product;

namespace gamer_world.API.Mapping
{
    public class PhotoMapper : Profile
    {
        public PhotoMapper()
        {
            CreateMap<Photo, PhotoDTO>().ReverseMap();
        }
    }
}
