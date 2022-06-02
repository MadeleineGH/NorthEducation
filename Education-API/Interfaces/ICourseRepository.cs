using Education_API.ViewModels;

namespace Education_API.Interfaces
{
  public interface ICourseRepository
    {
        public Task<List<CourseViewModel>> ListAllCoursesAsync();
        public Task<List<CourseViewModel>> GetCourseByTitleAsync(string title);
        public Task<CourseViewModel?> GetCourseAsync(int id);
        public Task<CourseViewModel?> GetCourseByCourseNumberAsync(int courseNumber);
        public Task AddCourseAsync(PostCourseViewModel model);
        public Task DeleteCourseAsync(int id);
        public Task UpdateCourseAsync(int id, PostCourseViewModel model);
        public Task UpdateCourseAsync(int id, PatchCourseViewModel model);
        public Task<bool> SaveAllAsync();
    }
}