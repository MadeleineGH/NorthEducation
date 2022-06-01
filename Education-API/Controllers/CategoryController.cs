 using Education_API.Data;
using Education_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education_API.Controllers
{
  [ApiController]
    [Route("api/v1/categories")]
    public class CategoryController : ControllerBase
    {
    private readonly EducationContext _context;
    public CategoryController(EducationContext context)
    {
      _context = context;
    }

       [HttpGet()]
      public async Task<ActionResult<List<Course>>> ListCategories()
      {
        var response = await _context.Category.ToListAsync();
        return Ok(response);
      }  

      [HttpGet("{id}")]
      public async Task<ActionResult> GetCategoryById(int id)
      {
        return Ok("{'message: 'Det funkar också'}");
      }

      [HttpGet("bytitle/{title}")]
      public async Task<ActionResult<Category>> GetCategoryByTitle(string title)
      {
        var response = await _context.Category.SingleOrDefaultAsync(
          c => c.Title!.ToLower() == title.ToLower());

        if(response is null) 
            return NotFound($"There is no category named {title}.");

            return Ok(response);
      }

      [HttpPost()]
      public async Task<ActionResult<Category>> AddCategory(Category category)
      {
          await _context.Category.AddAsync(category);
          await _context.SaveChangesAsync();
          return StatusCode(201, category);
      }

      [HttpPut("{id}")]
      public ActionResult UpdateCategory()
      {
          return NoContent();
      }

      [HttpDelete("{id}")]
      public async Task<ActionResult> DeleteCategory(int id)
      {
             var response = await _context.Category.FindAsync(id);

          if(response is null) 
            return NotFound($"There is no course with id: {id} to delete.");

          _context.Category.Remove(response);
          await _context.SaveChangesAsync();

          return NoContent();
      }
    }
}