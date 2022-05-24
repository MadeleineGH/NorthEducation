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
      public async Task<ActionResult> GetCourseById(int id)
      {
        var response = await _context.Course.FirstOrDefaultAsync();
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
      public ActionResult UpdateCourse()
      {
          return NoContent();
      }

      [HttpDelete("{id}")]
      public ActionResult DeleteCourse(int id)
      {
          return NoContent();
      }
    }
}