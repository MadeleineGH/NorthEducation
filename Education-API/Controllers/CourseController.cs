using AutoMapper;
using Education_API.Interfaces;
using Education_API.Models;
using Education_API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Education_API.Controllers
{
  [ApiController]
  [Route("api/v1/course")]
    public class CourseController : ControllerBase
    {
      private readonly ICourseRepository _courseRepo;
    private readonly IMapper _mapper;
      public CourseController(ICourseRepository courseRepo, IMapper mapper)
      {
        _mapper = mapper;
        _courseRepo = courseRepo;
      }

      [HttpGet()]
      public async Task<ActionResult<List<CourseViewModel>>> ListCourses()
      {
        var courseList = await _courseRepo.ListAllCoursesAsync();
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
      public async Task<ActionResult> AddCourse(PostCourseViewModel model)
      {
          if(await _courseRepo.GetCourseAsync(model.CourseNumber!)is not null){
            return BadRequest($"There is already a course with course number: {model.CourseNumber}.");
          }

          await _courseRepo.AddCourseAsync(model);

          if(await _courseRepo.SaveAllAsync()){
            return StatusCode(201);
          };

          return StatusCode(500, "Error occured when trying to save the course.");
      }

      [HttpPut("{id}")]
      public async Task<ActionResult> UpdateCourse(int id, PostCourseViewModel model)
      {
          try
          {
            await _courseRepo.UpdateCourseAsync(id, model);

            if(await _courseRepo.SaveAllAsync())
            {
              return NoContent();
            }

            return StatusCode(500, "An error occured when trying to update the course.");
          }
          catch (Exception ex)
          {
            return StatusCode(500, ex.Message);
          }
      }

      [HttpPatch("{id}")]
      public async Task<ActionResult> UpdateCourse(int id, PatchCourseViewModel model)
      {
        try
        {
          await _courseRepo.UpdateCourseAsync(id, model);

          if(await _courseRepo.SaveAllAsync())
          {
            return NoContent();
          }

          return StatusCode(500, "An error occured when trying to update the course.");
        }
        catch (Exception ex)
        {
          return StatusCode(500, ex.Message);
        }
      }

      [HttpDelete("{id}")]
      public async Task<ActionResult> DeleteCourse(int id)
      {
          await _courseRepo.DeleteCourseAsync(id);

          if(await _courseRepo.SaveAllAsync())
          {
            return NoContent();
          };

          return StatusCode(500, "Hoppsan något gick fel");
      }
    }
}