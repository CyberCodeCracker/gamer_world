using gamer_world.Core.Interfaces;
using gamer_world.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gamer_world.Core.Entities.Product;
using AutoMapper;

namespace gamer_world.API.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> get()
        {
            try
            {
                var category = await work.CategoryRepository.GetAllAsync();
                if (category is null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var category = await work.CategoryRepository.GetByIdAsync(id);
                if (category is null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("add-category")]
        public async Task<IActionResult> addCategory(CategoryRequest categoryRequest)
        {
            try
            {
                var category = mapper.Map<Category>(categoryRequest);
                await work.CategoryRepository.AddAsync(category);
                return Ok(new { message = "Category has been successfully added!" });

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);  

            }
        }
        [HttpPut("update-category")]
        public async Task<IActionResult> updateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            try
            {
                var category = mapper.Map<Category>(updateCategoryRequest);
                await work.CategoryRepository.UpdateAsync(category);
                return Ok(new { message = "Category has been successfully updated!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-category")]
        public async Task<IActionResult> deleteCategory(int id)
        {
            try
            {
                await work.CategoryRepository.DeleteAsync(id);
                return Ok(new { message = "Category has been successfully deleted!"});
            } 
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
