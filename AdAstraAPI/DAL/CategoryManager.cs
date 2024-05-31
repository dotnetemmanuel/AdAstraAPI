using Microsoft.EntityFrameworkCore;

namespace AdAstraAPI.DAL
{
    public class CategoryManager
    {
        //public List<Models.Category> _categories { get; set; } = null;
        private AdAstraDbContext _context;

        public CategoryManager(AdAstraDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Category>> GetAllCategories()
        {
            //if (_categories is null || !_categories.Any())
            //{
            CategoryData categoryData = new CategoryData(_context);
            var _categories = (await categoryData.GetCategoriesFromDbAsync()).ToList();
            //}
            return _categories;
        }


        public async Task<Models.Category> GetOneCategory(int id)
        {
            //if (_categories == null)
            //{
            //    throw new InvalidOperationException("CategoryData is not initialized. Call Initialize method first.");
            //}
            CategoryData categoryData = new CategoryData(_context);
            var _categories = (await categoryData.GetCategoriesFromDbAsync()).ToList();
            var category = _categories.Where(c => c.Id == id).FirstOrDefault();
            return category;
        }
    }
}
