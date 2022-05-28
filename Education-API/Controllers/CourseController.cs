using AutoMapper;
using Education_API.Data;
using Education_API.Interfaces;
using Education_API.Models;
using Education_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education_API.Controllers
{
  [ApiController]
  [Route("api/v1/course")]
    public class CourseController : ControllerBase
    {
      private readonly EducationContext _context;
      private readonly ICourseRepository _courseRepo;
    private readonly IMapper _mapper;
      public CourseController(EducationContext context, ICourseRepository courseRepo, IMapper mapper)
      {
        _mapper = mapper;
        _courseRepo = courseRepo;
        _context = context;
      }

      [HttpGet()]
      public async Task<ActionResult<List<CourseViewModel>>> ListCourses()
      {
        // var response = await _context.Course.ToListAsync();
        var response = await _courseRepo.ListAllCoursesAsync();
        var courseList = new List<CourseViewModel>();

        foreach(var course in response){
          courseList.Add(
            new CourseViewModel {
              CourseId = course.Id,
              CourseNumber = course.CourseNumber,
              Title = course.Title,
              Duration = course.Duration,
              Category = course.Category,
              Description = course.Description,
              Details = course.Details
              }
          );
        };
        return Ok(courseList);
      }  

      [HttpGet("{id}")]
      public async Task<ActionResult<CourseViewModel>> GetCourseById(int id)
      {
        try
        {
          var response = await _courseRepo.GetCourseAsync(id);

          if(response is null) 
              return NotFound($"There is no course with id: {id}.");

          return Ok(response);
        }   
        catch(Exception ex)
        {
          return StatusCode(500, ex.Message);
        }
      }

      [HttpGet("bycoursenumber/{courseNumber}")]
      public async Task<ActionResult<Course>> GetCourseByCourseNumber(int courseNumber)
      {
        var response = await _courseRepo.GetCourseByCourseNumberAsync(courseNumber);

        if(response is null) 
            return NotFound($"There is no course with course number: {courseNumber}.");

            return Ok(response);
      }

      [HttpPost()]
      public async Task<ActionResult<Course>> AddCourse(PostCourseViewModel course)
      {
          // var courseToAdd = new Course{
          //   CourseNumber = course.CourseNumber,
          //   Title = course.Title,
          //   Duration = course.Duration,
          //   Category = course.Category,
          //   Description = course.Description,
          //   Details = course.Details
          // };
          var courseToAdd = _mapper.Map<Course>(course);

          await _context.Course.AddAsync(courseToAdd);

          await _context.SaveChangesAsync();
          return StatusCode(201, courseToAdd);
      }

      [HttpPut("{id}")]
      public async Task<ActionResult> UpdateCourse(int id, Course model)
      {
          var response = await _context.Course.FindAsync(id);

          if(response is null) 
            return NotFound($"There is no course with id: {id}.");

          response.CourseNumber = model.CourseNumber;
          response.Title = model.Title;
          response.Duration = model.Duration;
          response.Category = model.Category;
          response.Description = model.Description;
          response.Details = model.Details;

          _context.Course.Update(response);
          await _context.SaveChangesAsync();

          return NoContent();
      }

      [HttpDelete("{id}")]
      public async Task<ActionResult> DeleteCourse(int id)
      {
          _courseRepo.DeleteCourse(id);

          if(await _courseRepo.SaveAllAsync())
          {
            return NoContent();
          };

          return StatusCode(500, "Hoppsan något gick fel");
      }
    }
}