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
    private readonly TeacherServiceModel _teacherService;

    public CourseController(IConfiguration config, CourseServiceModel courseService, TeacherServiceModel teacherService)
    {
      _teacherService = teacherService;
      _courseService = courseService;
      _config = config;
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
    [HttpGet("Edit")]
    public async Task<IActionResult> Edit(int id)
    {
      // Skicka in en tom vy till formuläret
      var course = await _courseService.FindCourseToEdit(id);
      return View("Edit", course);
    }
    [HttpPost("Edit")]
    public async Task<IActionResult> Edit(EditCourseViewModel courseViewModel)
    {
      if (!ModelState.IsValid)
      {
        return View("Edit", courseViewModel);
      }

      if (await _courseService.EditCourse(courseViewModel.CourseNumber, courseViewModel))
      {
        return View("Confirmation");
      }

      return View("Edit", courseViewModel);
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