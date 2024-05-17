using Microsoft.AspNetCore.Mvc;

namespace AdAstraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Models.Category>> GetCategoriesAsync()
        {
            return await DAL.CategoryManager.GetAllCategories();
        }

        [HttpGet("{id}")]
        public async Task<Models.Category> GetCategoryAsync(int id)
        {
            return await DAL.CategoryManager.GetOneCategory(id);
        }
    }
}
