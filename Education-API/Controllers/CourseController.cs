using AutoMapper;
using Education_API.Interfaces;
using Education_API.Models;
using Education_API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education_API.Controllers
{
  [ApiController]
  [Route("api/v1/courses")]
    public class CourseController : ControllerBase
    {
    private readonly ICourseRepository _courseRepo;
    private readonly IMapper _mapper;
    public CourseController(ICourseRepository courseRepo, IMapper mapper)
    {
      _mapper = mapper;
      _courseRepo = courseRepo;
    }

    [HttpGet("list")]
    //[Authorize()]
    public async Task<ActionResult<List<CourseViewModel>>> ListCourses()
    {
      return Ok(await _courseRepo.ListAllCoursesAsync());
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
    [HttpGet("bytitle/{title}")]
    public async Task<ActionResult<List<CourseViewModel>>> GetCourseByTitle(string title)
      {
        return Ok(await _courseRepo.GetCourseByTitleAsync(title));
      } 
    [HttpPost()]
    public async Task<ActionResult> AddCourse(PostCourseViewModel model)
      {
          if(await _courseRepo.GetCourseByCourseNumberAsync(model.CourseNumber!)is not null){
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
      // Kapsla hela anropet i ett try...catch block
      // Anledningen ??r att metoden i v??rt repository kastar ett exception om vi inte kan hitta tillverkaren
      // som skall tas bort...
      try
      {
        await _courseRepo.DeleteCourseAsync(id);

        // Gl??m inte att anropa SaveAllAsync f??r att spara ner ??ndringarna till databasen.
        if (await _courseRepo.SaveAllAsync())
        {
          // Om allt gick bra returnera status kod 204(NoContent), vi har inget att rapportera
          return NoContent();
        }

        // Annars returnera status kod 500 (Internal Server Error)
        return StatusCode(500, $"An error occured when trying to delete course with id: {id}");
      }
      catch (Exception ex)
      {
        // Om vi hamnar h??r s?? har ett exception kastats ifr??n metoden i v??rt repository
        // och vi returnerar ett Internal Server Error meddelande.
        return StatusCode(500, ex.Message);
      }
      }
    }
}
