using Education_API.ViewModels;
using Education_API.ViewModels.Category;

namespace Education_API.Interfaces
{
  public interface ICategoryRepository
    {
        public Task<List<CategoryViewModel>> ListAllCategoriesAsync();
        public Task<List<CategoryViewModel>> GetCategoryByTitleAsync(string title);
        public Task<CategoryViewModel?> GetCategoryAsync(int id);
        public Task<CategoryViewModel?> GetCategoryAsync(string title);
        public Task<List<CategoryWithCoursesViewModel>> ListCategoriesCourses();
        public Task<CategoryWithCoursesViewModel?> ListCategoriesCourses(int id);
        public Task AddCategoryAsync(PostCategoryViewModel model);
        public Task DeleteCategoryAsync(int id);
        public Task UpdateCategoryAsync(int id, PutCategoryViewModel model);
        public Task<bool> SaveAllAsync();
    }
}