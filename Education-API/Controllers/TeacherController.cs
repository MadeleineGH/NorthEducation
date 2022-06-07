using AutoMapper;
using Education_API.Interfaces;
using Education_API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Education_API.Controllers
{
    [ApiController]
    [Route("api/v1/teachers")]
    public class TeacherController : ControllerBase
    {  
      private readonly ITeacherRepository _teacherRepo;
      private readonly IMapper _mapper;
      public TeacherController(ITeacherRepository teacherRepo, IMapper mapper)
      {
        _mapper = mapper;
        _teacherRepo = teacherRepo;
      }

      [HttpGet()]
      public async Task<ActionResult<List<TeacherViewModel>>> ListTeachers()
      {
        var teacherList = await _teacherRepo.ListAllTeachersAsync();
        return Ok(teacherList);
      }  
      [HttpGet("{id}")]
      public async Task<ActionResult<TeacherViewModel>> GetTeacherById(int id)
      {
        try
        {
          var response = await _teacherRepo.GetTeacherAsync(id);

          if(response is null) 
              return NotFound($"There is no Teacher with id: {id}.");

          return Ok(response);
        }   
        catch(Exception ex)
        {
          return StatusCode(500, ex.Message);
        }
      }
      [HttpGet("byemail/{email}")]
      public async Task<ActionResult<TeacherViewModel>> GetTeacherByEmail(string email)
      {
        try
        {
          var response = await _teacherRepo.GetTeacherByEmailAsync(email);

          if(response is null) 
              return NotFound($"There is no Teacher with the email: {email}.");

          return Ok(response);
        }   
        catch(Exception ex)
        {
          return StatusCode(500, ex.Message);
        }
      }
      [HttpPost()]
      public async Task<ActionResult> AddTeacher(PostTeacherViewModel model)
      {
          if(await _teacherRepo.GetTeacherAsync(model.TeacherId!)is not null){
            return BadRequest($"There is already a Teacher with TeacherId: {model.TeacherId}.");
          }

          await _teacherRepo.AddTeacherAsync(model);

          if(await _teacherRepo.SaveAllAsync()){
            return StatusCode(201);
          };

          return StatusCode(500, "Email already in use.");
      }
      [HttpPut("{id}")]
      public async Task<ActionResult> UpdateTeacher(int id, PostTeacherViewModel model)
      {
          try
          {
            await _teacherRepo.UpdateTeacherAsync(id, model);

            if(await _teacherRepo.SaveAllAsync())
            {
              return NoContent();
            }

            return StatusCode(500, "An error occured when trying to update the Teacher.");
          }
          catch (Exception ex)
          {
            return StatusCode(500, ex.Message);
          }
      }
      [HttpPatch("{id}")]
      public async Task<ActionResult> UpdateTeacher(int id, PatchTeacherViewModel model)
      {
        try
        {
          await _teacherRepo.UpdateTeacherAsync(id, model);

          if(await _teacherRepo.SaveAllAsync())
          {
            return NoContent();
          }

          return StatusCode(500, "An error occured when trying to update the Teacher.");
        }
        catch (Exception ex)
        {
          return StatusCode(500, ex.Message);
        }
      }
      [HttpDelete("{id}")]
      public async Task<ActionResult> DeleteTeacher(int id)
      {
          await _teacherRepo.DeleteTeacherAsync(id);

          if(await _teacherRepo.SaveAllAsync())
          {
            return NoContent();
          };

          return StatusCode(500, "An error occured");
      }
    }
}