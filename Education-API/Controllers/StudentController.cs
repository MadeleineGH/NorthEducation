using Microsoft.AspNetCore.Mvc;

namespace Education_API.Controllers
{
  [ApiController]
    [Route("api/v1/student")]
    public class StudentController : ControllerBase
    {
      [HttpGet()]
      public ActionResult ListStudents()
      {
        return Ok("{'message: 'Det funkar'}");
      }  

      [HttpGet("{id}")]
      public ActionResult GetStudentById(int id)
      {
        return Ok("{'message: 'Det funkar också'}");
      }

      [HttpPost()]
      public ActionResult AddStudent()
      {
          return StatusCode(201);
      }

      [HttpPut("{id}")]
      public ActionResult UpdateStudent()
      {
          return NoContent();
      }

      [HttpDelete("{id}")]
      public ActionResult DeleteStudent(int id)
      {
          return NoContent();
      }
    }
}