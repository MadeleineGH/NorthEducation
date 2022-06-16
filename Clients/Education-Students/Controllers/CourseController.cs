using Education_Admins.Models;
using Education_Admins.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Education_Admins.Controllers
{
  [Route("[controller]")]
  public class CourseController : Controller
  {
    private readonly IConfiguration _config;
    private readonly CourseServiceModel _courseService;

    public CourseController(IConfiguration config)
    {
      _config = config;
      _courseService = new CourseServiceModel(_config);
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
      // Skicka in en tom vy till formuläret
      var course = new CreateCourseViewModel();
      return View("Create", course);
    }

    // Fungera som mottagare av formulärets data
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
  }
}