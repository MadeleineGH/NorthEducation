using Education_API.Interfaces;
using Education_API.ViewModels;
using Education_API.ViewModels.Competence;
using Microsoft.AspNetCore.Mvc;

namespace Education_API.Controllers
{
  [ApiController]
  [Route("api/v1/competences")]
  public class CompetenceController : ControllerBase
  {
    private readonly ICompetenceRepository _competenceRepo;
    public CompetenceController(ICompetenceRepository competenceRepo)
    {
        _competenceRepo = competenceRepo;
    }
    
      [HttpGet()]
      public async Task<ActionResult<List<CompetenceViewModel>>> ListAllCompetences()
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
      public async Task<ActionResult> AddCompetence(PostCompetenceViewModel model)
      {
          if(await _competenceRepo.GetCompetenceAsync(model.Title!)is not null){
            return BadRequest($"There is already a competence with title: {model.Title}.");
          }

          await _competenceRepo.AddCompetenceAsync(model);

          if(await _competenceRepo.SaveAllAsync()){
            return StatusCode(201);
          };

          return StatusCode(500, "Error occured when trying to save the competence.");
      }
      [HttpPut("{id}")]
      public async Task<ActionResult> UpdateCompetence(int id, PutCompetenceViewModel model)
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

          return StatusCode(500, "An error occured when trying to delete the competence.");
      }
  }
}