using Book_API.DTO;
using Book_API.Helpers;
using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory categoriesService;
        public CategoryController(ICategory _categoriesService)
        {
            categoriesService = _categoriesService;
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategories()
        {
            List<Category> categories = await categoriesService.GetAllAsync();
            if (categories.Count == 0) return NotFound();
            List<CategoryDTO> categoryDTOs = new();
            foreach (Category category in categories)
                categoryDTOs.Add(category.ToCategoryDTO());
            return Ok(categoryDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            Category category = await categoriesService.GetByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category.ToCategoryDTO());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> DeleteCategoryById(int id)
        {
            Category category = await categoriesService.DeleteAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> AddCategory(Category category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            Category addedCategory = await categoriesService.AddAsync(category);
            return Ok(addedCategory.ToCategoryDTO());
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> EditCategory(int id, Category category)
        {
            Category editedCategory = await categoriesService.EditAsync(id, category,e=>e.Id);
            if (editedCategory == null) return NotFound();
            return Ok(editedCategory.ToCategoryDTO());
        }
    }
}
