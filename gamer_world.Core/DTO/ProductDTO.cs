using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamer_world.Core.DTO
{
    public record ProductDTO
    (string Name, string Description, decimal Price, List<PhotoDTO> Photos, string CategoryName);
    
}
