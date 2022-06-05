using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    private readonly IMapper _mapper;
    public CourseRepository(EducationContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }

    public async Task AddCourseAsync(PostCourseViewModel model)
    {
      var courseToAdd = _mapper.Map<Course>(model);
      await _context.Courses.AddAsync(courseToAdd);
    }
    public async Task DeleteCourseAsync(int id)
    {
      var response = await _context.Courses.FindAsync(id);

      if(response is not null)
      {
        _context.Courses.Remove(response);
      }
    }
    public async Task<CourseViewModel?> GetCourseAsync(int id)
    {
      return await _context.Courses.Where(c => c.Id == id)
      .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync();
    }
    public async Task<List<CourseViewModel>> GetCourseByTitleAsync(string title)
    {
      return await _context.Courses
        .Where(c => c.Title!.ToLower() == title.ToLower())
        .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }
    public async Task<CourseViewModel?> GetCourseByCourseNumberAsync(int courseNumber)
    {
      return await _context.Courses.Where(c => c.CourseNumber == courseNumber)
      .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync();
    }
    public async Task<List<CourseViewModel>> ListAllCoursesAsync()
    {
        return await _context.Courses.Include(c => c.Category).ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider).ToListAsync();
    }
    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
    public async Task UpdateCourseAsync(int id, PostCourseViewModel model)
    {
      var course = await _context.Courses.FindAsync(id);

      if(course is null)
      {
        throw new Exception($"Couldn't find any course with id {id}.");
      }

        course.CourseNumber = model.CourseNumber;
        course.Title = model.Title;
        course.Duration = model.Duration;
        course.Description = model.Description;
        course.Details = model.Details;

        _context.Courses.Update(course);
    }
    public async Task UpdateCourseAsync(int id, PatchCourseViewModel model)
    {
      var course = await _context.Courses.FindAsync(id);

      if(course is null)
      {
        throw new Exception($"Couldn't find any course with id {id}.");
      }
  
        course.Description = model.Description;
        course.Details = model.Details;

        _context.Courses.Update(course);
    }
  }
} 