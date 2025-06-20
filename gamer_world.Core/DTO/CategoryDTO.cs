using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamer_world.Core.DTO
{
    public record CategoryDTO
    (string Name, string Description);
    public record UpdateCategoryRequest(string Name, string Description, int Id);
}
