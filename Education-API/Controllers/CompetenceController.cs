using Education_API.Interfaces;
using Education_API.Models;
using Education_API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Education_API.Controllers
{
  [ApiController]
  [Route("api/v1/competence")]
  public class CompetenceController : ControllerBase
  {
    private readonly ICompetenceRepository _competenceRepo;
    public CompetenceController(ICompetenceRepository competenceRepo)
    {
        _competenceRepo = competenceRepo;
    }
    
      [HttpGet()]
      public async Task<ActionResult<List<CompetenceViewModel>>> ListCompetences()
      {
        var courseList = await _competenceRepo.ListAllCompetencesAsync();
        return Ok(courseList);
      }  

      [HttpGet("bytitle/{title}")]
      public async Task<ActionResult<List<CompetenceViewModel>>> GetCompetenceByTitle(string title)
      {
        return Ok(await _competenceRepo.GetCompetenceByTitleAsync(title));
      } 

      [HttpPost()]
      public async Task<ActionResult> AddCompetence(CompetenceViewModel model)
      {
        try
        {
        if (await _competenceRepo.GetCompetenceAsync(model.Title!.ToLower()) is not null)
        {
          var error = new ErrorViewModel{
            StatusCode = 400,
            StatusText = $"Competence: {model.Title} already exist."
          };
          
          return BadRequest(error);
        }

        await _competenceRepo.AddCompetenceAsync(model);

        if (await _competenceRepo.SaveAllAsync())
        {
          return StatusCode(201);
        }

        return StatusCode(500, "Det gick inte att spara fordonet");
        }
        catch (Exception ex)
        {
          var error = new ErrorViewModel{
            StatusCode = 500,
            StatusText = ex.Message
          };
          return StatusCode(500, error);
        }
      }

      [HttpPut("{id}")]
      public async Task<ActionResult> UpdateCompetence(int id, CompetenceViewModel model)
      {
          try
          {
            await _competenceRepo.UpdateCompetenceAsync(id, model);

            if(await _competenceRepo.SaveAllAsync())
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
      public async Task<ActionResult> DeleteCompetence(int id)
      {
          await _competenceRepo.DeleteCompetenceAsync(id);

          if(await _competenceRepo.SaveAllAsync())
          {
            return NoContent();
          };

          return StatusCode(500, "Hoppsan något gick fel");
      }
  }
}