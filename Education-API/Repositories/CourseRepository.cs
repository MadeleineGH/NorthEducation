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
      await _context.Course.AddAsync(courseToAdd);
      
    }

    public void DeleteCourse(int id)
    {
      var response = _context.Course.Find(id);

      if(response is not null)
      {
        _context.Course.Remove(response);
      }
    }

    public async Task<CourseViewModel?> GetCourseAsync(int id)
    {
      return await _context.Course.Where(c => c.Id == id)
      .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync();
    }

    public async Task<CourseViewModel?> GetCourseByCourseNumberAsync(int courseNumber)
    {
      return await _context.Course.Where(c => c.CourseNumber == courseNumber)
      .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync();
    }

    public async Task<List<CourseViewModel>> ListAllCoursesAsync()
    {
        return await _context.Course.ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public void UpdateCourse(int id, Course model)
    {
      throw new NotImplementedException();
    }
  }
}