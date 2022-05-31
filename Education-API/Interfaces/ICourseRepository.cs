using Education_API.Models;
using Education_API.ViewModels;

namespace Education_API.Interfaces
{
  public interface ICourseRepository
    {
        // Signaturer för metoderna
        public Task<List<CourseViewModel>> ListAllCoursesAsync();
        public Task<CourseViewModel?> GetCourseAsync(int id);
        public Task<CourseViewModel?> GetCourseByCourseNumberAsync(int courseNumber);
        public Task AddCourseAsync(PostCourseViewModel model);
        public Task DeleteCourse(int id);
        public Task UpdateCourse(int id, PostCourseViewModel model);
        public Task<bool> SaveAllAsync();
    }
}