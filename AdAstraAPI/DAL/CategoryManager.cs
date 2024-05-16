using Microsoft.EntityFrameworkCore;

namespace AdAstraAPI.DAL
{
    public static class CategoryManager
    {


        public static List<Models.Category> _categories;

        public static async Task<List<Models.Category>> GetAllCategories()
        {
            if (_categories is null || !_categories.Any())
            {
                _categories = (await CategoryData.GetCategoriesFromDbAsync()).ToList();
            }
            return _categories;
        }


        public static async Task<Models.Category> GetOneCategory(int id)
        {

            if (_categories == null)
            {
                throw new InvalidOperationException("CategoryData is not initialized. Call Initialize method first.");
            }
            var category = _categories.Where(c => c.Id == id).FirstOrDefault();
            return category;
        }
    }
}
