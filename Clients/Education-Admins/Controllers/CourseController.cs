using Education_Admins.Models;
using Education_Admins.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Education_Admins.Controllers
{
  [Route("[controller]")]
  public class CourseController : Controller
  {
    private readonly IConfiguration _config;
    private readonly CourseServices _courseService;
    private readonly TeacherServices _teacherService;

    public CourseController(IConfiguration config, CourseServices courseService)
    {
      _courseService = courseService;
      _config = config;
      _teacherService = new TeacherServices(_config);
    }

    [HttpGet()]
    public async Task<IActionResult> Index()
    {
      try
      {
        var courses = await _courseService.ListAllCourses();
        return View("Index", courses);
      }
      catch (System.Exception)
      {
        throw;
      }
    }
    [HttpGet("Create")]
    public IActionResult Create()
    {
      var course = new CreateCourseViewModel();
      return View("Create", course);
    }
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateCourseViewModel course)
    {
      if (!ModelState.IsValid)
      {
        return View("Create", course);
      }

      if (await _courseService.CreateCourse(course))
      {
        return View("Confirmation");
      }

      return View("Create", course);
    }
    [HttpGet("Edit")]
    public IActionResult Edit(int id)
    {
      // Skicka in en tom vy till formuläret
      var course = _courseService.FindCourseToEdit(id);
      return View("Edit", course);
    }
    [HttpPost("Edit")]
    public async Task<IActionResult> Edit(EditCourseViewModel course)
    {
      if (!ModelState.IsValid)
      {
        return View("Edit", course);
      }

      if (await _courseService.EditCourse(course))
      {
        return View("Confirmation");
      }

      return View("Edit", course);
    }
    [HttpGet("Details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
      try
      {
        // Hämta den specika bilen ifrån vårt API...
        var course = await _courseService.FindCourse(id);
        return View("Details", course);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return View("Error");
      }
    }
    public async Task<IActionResult> Delete(int id)
    {
      // Skicka in en tom vy till formuläret
      var course = await _courseService.FindCourse(id);
      if (course == null)
      {
        return NotFound();
      }
      return View("Index", course);
    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var courseToDelete = await _courseService.FindCourse(id);
      if (courseToDelete == null)
      {
        return NotFound();
      }
      await _courseService.DeleteCourse(id);
      return RedirectToAction("Index");
    }
  }
}