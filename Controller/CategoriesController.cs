using Microsoft.AspNetCore.Mvc;
using Book_API.Services;
using Book_API.DTO;
using Book_API.Utilites;

namespace Book_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategories categoriesService;
        public CategoriesController(ICategories _categoriesService)
        {
            categoriesService = _categoriesService;
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategories()
        {
            List<Category> categories= await categoriesService.GetAll();
            if (categories.Count == 0) return NotFound();
            List<CategoryDTO> categoryDTOs = new();
            foreach (Category category in categories)
                categoryDTOs.Add(category.ToCategoryDTO());
            return Ok(categoryDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            Category category = await categoriesService.GetById(id);
            if(category == null) return NotFound();
            return Ok(category.ToCategoryDTO());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> DeleteCategoryById(int id)
        {
            Category category = await categoriesService.Delete(id);
            if(category==null) return NotFound();
            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> AddCategory(Category category)
        {
            await categoriesService.Add(category);
            return CreatedAtAction("GetCategoryById", category.Id, category);
        }
    }
}
