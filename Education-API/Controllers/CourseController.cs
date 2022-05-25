using Education_API.Data;
using Education_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education_API.Controllers
{
  [ApiController]
  [Route("api/v1/course")]
    public class CourseController : ControllerBase
    {
    private readonly EducationContext _context;
      public CourseController(EducationContext context)
      {
        _context = context;
      }

      [HttpGet()]
      public async Task<ActionResult<List<Course>>> ListCourses()
      {
        var response = await _context.Course.ToListAsync();
        return Ok(response);
      }  

      [HttpGet("{id}")]
      public async Task<ActionResult<Course>> GetCourseById(int id)
      {
        var response = await _context.Course.FindAsync(id);

        if(response is null) 
            return NotFound($"There is no course with id: {id}.");

        return Ok(response);
      }

      [HttpPost()]
      public async Task<ActionResult<Course>> AddCourse(Course course)
      {
          await _context.Course.AddAsync(course);
          await _context.SaveChangesAsync();
          return StatusCode(201, course);
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
          var response = await _context.Course.FindAsync(id);

          if(response is null) 
            return NotFound($"There is no course with id: {id} to delete.");

          _context.Course.Remove(response);
          await _context.SaveChangesAsync();

          return NoContent();
      }
    }
}