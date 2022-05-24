using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Education_API.Controllers
{
    [ApiController]
    [Route("api/v1/teacher")]
    public class TeacherController : ControllerBase
    {
      [HttpGet()]
      public ActionResult ListTeachers()
      {
        return Ok("{'message: 'Det funkar'}");
      }  

      [HttpGet("{id}")]
      public ActionResult GetTeacherById(int id)
      {
        return Ok("{'message: 'Det funkar också'}");
      }

      [HttpPost()]
      public ActionResult AddTeacher()
      {
          return StatusCode(201);
      }

      [HttpPut("{id}")]
      public ActionResult UpdateTeacher()
      {
          return NoContent();
      }

      [HttpDelete("{id}")]
      public ActionResult DeleteTeacher(int id)
      {
          return NoContent();
      }
    }
}