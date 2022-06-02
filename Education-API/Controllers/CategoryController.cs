using Education_API.Interfaces;
using Education_API.ViewModels;
using Education_API.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace Education_API.Controllers
{
  [ApiController]
    [Route("api/v1/categories")]
    public class CategoryController : ControllerBase
    {
    private readonly ICategoryRepository _repo;
    public CategoryController(ICategoryRepository repo)
    {
      _repo = repo;
    }

    [HttpGet("list")]
    public async Task<ActionResult> ListAllCategories()
    {
      var list = await _repo.ListAllCategoriesAsync();
      return Ok(list);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetManufacturerById(int id)
    {
      return Ok(await _repo.GetCategoryAsync(id));
    }

    [HttpPost()]
    public async Task<ActionResult> AddCategory(PostCategoryViewModel model)
    {
      try
      {
        await _repo.AddCategoryAsync(model);

        if (await _repo.SaveAllAsync())
        {
          return StatusCode(201);
        }

        return StatusCode(500, "Det gick fel när vi skulle spara tillverkaren");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCategory(int id, PutCategoryViewModel model)
    {
      try
      {
        await _repo.UpdateCategoryAsync(id, model);

        if (await _repo.SaveAllAsync())
        {
          return NoContent();
        }

        return StatusCode(500, $"Något gick fel och det gick inte att uppdatera tillverkare {model.Title}");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
      try
      {
        await _repo.DeleteCategoryAsync(id);

        if (await _repo.SaveAllAsync())
        {
          return NoContent();
        }

        return StatusCode(500, $"Det gick inte att ta bort tillverkare med id {id}");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
    }
}