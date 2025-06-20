using gamer_world.Core.Interfaces;
using gamer_world.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gamer_world.Core.Entities.Product;
using AutoMapper;
using gamer_world.API.Helper;

namespace gamer_world.API.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> getALlCategories()
        {
            try
            {
                var categories = await work.CategoryRepository.GetAllAsync();
                if (categories is null)
                {
                    return NotFound(new ResponseAPI(404));
                }
                return Ok(categories);
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
                    return BadRequest(new ResponseAPI(400, $"category not found id={id}"));
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> addCategory(CategoryDTO categoryRequest)
        {
            try
            {
                var category = mapper.Map<Category>(categoryRequest);
                await work.CategoryRepository.AddAsync(category);
                return Ok(new ResponseAPI(200, "Category has been added successfully!"));

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
                return Ok(new ResponseAPI(200, "Category has been updated successfully!"));
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
                return Ok(new ResponseAPI(200, "Category has been deleted successfully!"));
            } 
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
