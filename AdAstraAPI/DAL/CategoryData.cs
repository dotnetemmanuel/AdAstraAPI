using Microsoft.EntityFrameworkCore;

namespace AdAstraAPI.DAL
{
    public class CategoryData
    {
        private AdAstraDbContext _context;

        public CategoryData(AdAstraDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Category>> GetCategoriesFromDbAsync()
        {
            List<Models.Category> categories;

            if (_context == null)
            {
                throw new InvalidOperationException("CategoryData is not initialized. Call Initialize method first.");
            }
            categories = await _context.Categories.Include(c => c.ParentCategory).Include(c => c.Creator).Include(c => c.Subgategories).Include(c => c.Posts).ToListAsync();
            return categories;
        }
    }
}
