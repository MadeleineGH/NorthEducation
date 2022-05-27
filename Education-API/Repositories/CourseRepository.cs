using Education_API.Data;
using Education_API.Interfaces;
using Education_API.Models;
using Education_API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Education_API.Repositories
{
  public class CourseRepository : ICourseRepository
  {
    private readonly EducationContext _context;
    public CourseRepository(EducationContext context)
    {
      _context = context;
    }

    public Task AddCourseAsync(Course model)
    {
      throw new NotImplementedException();
    }

    public void DeleteCourse(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<CourseViewModel?> GetCourseAsync(int id)
    {
      return await _context.Course.Where(c => c.Id == id)
      .Select(course => new CourseViewModel
      {
          CourseId = course.Id,
          CourseNumber = course.CourseNumber,
          Title = course.Title,
          Duration = course.Duration,
          Category = course.Category,
          Description = course.Description,
          Details = course.Details
      }).SingleOrDefaultAsync();
    }

    public Task<Course> GetCourseAsync(string courseNumber)
    {
      throw new NotImplementedException();
    }

    public async Task<List<Course>> ListAllCoursesAsync()
    {
        return await _context.Course.ToListAsync();
    }

    public Task<bool> SaveAllAsync()
    {
      throw new NotImplementedException();
    }

    public void UpdateCourse(int id, Course model)
    {
      throw new NotImplementedException();
    }
  }
}