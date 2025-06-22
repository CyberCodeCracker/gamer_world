using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamer_world.Core.DTO
{
    public record ProductDTO
    (string Name, string Description, decimal Price, List<PhotoDTO> Photos, string CategoryName);

    public record AddProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public int CategoryId{ get; set; }
        public IFormFileCollection Photos { get; set; }
    }

    public record UpdateProductDTO : AddProductDTO
    {
        public int Id { get; set; }
    }
    
}
