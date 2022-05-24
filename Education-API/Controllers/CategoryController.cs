using Education_API.Data;
using Education_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education_API.Controllers
{
    [ApiController]
    [Route("api/v1/category")]
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
      public ActionResult GetCategoryById(int id)
      {
        return Ok("{'message: 'Det funkar också'}");
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
      public ActionResult DeleteCategory(int id)
      {
          return NoContent();
      }
    }
}