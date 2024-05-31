using AdAstraAPI.DAL;
using Microsoft.AspNetCore.Mvc;

namespace AdAstraAPI.Controllers
{
[ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AdAstraDbContext _context;

        public CategoriesController(AdAstraDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.Category>> GetCategoriesAsync()
        {
            DAL.CategoryManager categoryManager = new DAL.CategoryManager(_context);
            return await categoryManager.GetAllCategories();
        }

        [HttpGet("{id}")]
        public async Task<Models.Category> GetCategoryAsync(int id)
        {
            DAL.CategoryManager categoryManager = new DAL.CategoryManager(_context);
            return await categoryManager.GetOneCategory(id);
        }
    }
}
