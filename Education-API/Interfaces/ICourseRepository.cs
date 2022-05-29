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
        public Task AddCourseAsync(Course model);
        public void DeleteCourse(int id);
        public void UpdateCourse(int id, Course model);
        public Task<bool> SaveAllAsync();
    }
}