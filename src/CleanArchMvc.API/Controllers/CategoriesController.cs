using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            if (categories == null) return NotFound("Categories not found.");

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int? id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null) return NotFound("Category not found.");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null) return BadRequest("Invalid data.");

            await _categoryService.AddAsync(categoryDto);

            return new CreatedAtRouteResult(nameof(GetCategory), new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.Id) return BadRequest("ID's doesn't match.");

            if (categoryDto == null) return BadRequest();

            await _categoryService.UpdateAsync(categoryDto);
            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null) return NotFound("Category not found.");

            await _categoryService.RemoveAsync(id);
            return Ok();
        }
    }
}
