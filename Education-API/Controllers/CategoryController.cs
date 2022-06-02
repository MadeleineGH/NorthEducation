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
    private readonly ICategoryRepository _categoryRepo;
    public CategoryController(ICategoryRepository categoryRepo)
    {
      _categoryRepo = categoryRepo;
    }

    [HttpGet("list")]
    public async Task<ActionResult> ListAllCategories()
    {
      var list = await _categoryRepo.ListAllCategoriesAsync();
      return Ok(list);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetManufacturerById(int id)
    {
      return Ok(await _categoryRepo.GetCategoryAsync(id));
    }
    [HttpPost()]
    public async Task<ActionResult> AddCategory(PostCategoryViewModel model)
    {
      if(await _categoryRepo.GetCategoryAsync(model.Title!)is not null){
        return BadRequest($"There is already a category with title: {model.Title}.");
      }

      await _categoryRepo.AddCategoryAsync(model);

      if(await _categoryRepo.SaveAllAsync()){
        return StatusCode(201);
      };

      return StatusCode(500, "Error occured when trying to save the category.");
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCategory(int id, PutCategoryViewModel model)
    {
      try
      {
        await _categoryRepo.UpdateCategoryAsync(id, model);

        if (await _categoryRepo.SaveAllAsync())
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
        await _categoryRepo.DeleteCategoryAsync(id);

        if (await _categoryRepo.SaveAllAsync())
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