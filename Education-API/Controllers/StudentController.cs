using AutoMapper;
using Education_API.Interfaces;
using Education_API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Education_API.Controllers
{
  [ApiController]
  [Route("api/v1/students")]
  public class StudentController : ControllerBase
  {
    private readonly IStudentRepository _studentRepo;
    private readonly IMapper _mapper;
    public StudentController(IStudentRepository studentRepo, IMapper mapper)
    {
      _mapper = mapper;
      _studentRepo = studentRepo;
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<StudentViewModel>>> ListStudents()
    {
      var studentList = await _studentRepo.ListAllStudentsAsync();
      return Ok(studentList);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<StudentViewModel>> GetStudentById(int id)
    {
      try
      {
        var response = await _studentRepo.GetStudentAsync(id);

        if (response is null)
          return NotFound($"There is no student with id: {id}.");

        return Ok(response);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
    [HttpGet("byemail/{email}")]
    public async Task<ActionResult<StudentViewModel>> GetStudentByEmail(string email)
    {
      try
      {
        var response = await _studentRepo.GetStudentByEmailAsync(email);

        if (response is null)
          return NotFound($"There is no student with the email: {email}.");

        return Ok(response);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
    [HttpPost()]
    public async Task<ActionResult> AddStudent(PostStudentViewModel model)
    {
      if (await _studentRepo.GetStudentAsync(model.StudentId!) is not null)
      {
        return BadRequest($"There is already a student with StudentId: {model.StudentId}.");
      }

      await _studentRepo.AddStudentAsync(model);

      if (await _studentRepo.SaveAllAsync())
      {
        return StatusCode(201);
      };

      return StatusCode(500, "Email already in use.");
    }
    [HttpPost("edit/{id}")]
    public async Task<ActionResult> UpdateStudent(int id, PostStudentViewModel model)
    {
      try
      {
        await _studentRepo.UpdateStudentAsync(id, model);

        if (await _studentRepo.SaveAllAsync())
        {
          return NoContent();
        }

        return StatusCode(500, "An error occured when trying to update the student.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateStudent(int id, PatchStudentViewModel model)
    {
      try
      {
        await _studentRepo.UpdateStudentAsync(id, model);

        if (await _studentRepo.SaveAllAsync())
        {
          return NoContent();
        }

        return StatusCode(500, "An error occured when trying to update the student.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
    [HttpDelete("students/{id}")]
    public async Task<ActionResult> DeleteStudent(int id)
    {
      await _studentRepo.DeleteStudentAsync(id);

      if (await _studentRepo.SaveAllAsync())
      {
        return NoContent();
      };

      return StatusCode(500, "An error occured");
    }
  }
}