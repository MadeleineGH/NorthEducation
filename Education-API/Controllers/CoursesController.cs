using Microsoft.AspNetCore.Mvc;

namespace Education_API.Controllers
{
  [ApiController]
    [Route("api/v1/courses")]
    public class CoursesController : ControllerBase
    {
      // En metod för att hämta alla kurser
      [HttpGet()]
      public ActionResult ListCourses()
      {
        return Ok("{'message: 'Det funkar'}");
      }  

      [HttpGet("{id}")]
      public ActionResult GetCourseById(int id)
      {
        return Ok("{'message: 'Det funkar också'}");
      }

      [HttpPost()]
      public ActionResult AddCourse()
      {
          // Här kommer vi att kontakta databasen
          return StatusCode(201);
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