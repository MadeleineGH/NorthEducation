using Education_Admins.Models;
using Education_Admins.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Education_Admins.Controllers
{
  [Route("[controller]")]
  public class TeacherController : Controller
  {
    private readonly IConfiguration _config;
    private readonly TeacherServices _teacherService;

    public TeacherController(IConfiguration config)
    {
      _config = config;
      _teacherService = new TeacherServices(_config);
    }

    [HttpGet()]
    public async Task<IActionResult> Index()
    {
      try
      {
        var teachers = await _teacherService.ListAllTeachers();
        //Lagt till två rader
        ViewData["Teachers"] = teachers;
        // return View();
        return View("Index", teachers);
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
      var teacher = new CreateTeacherViewModel();
      return View("Create", teacher);
    }
    // Fungera som mottagare av formulärets data
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateTeacherViewModel teacher)
    {
      if (!ModelState.IsValid)
      {
        return View("Create", teacher);
      }

      if (await _teacherService.CreateTeacher(teacher))
      {
        return View("Confirmation");
      }

      return View("Create", teacher);
    }
    [HttpGet("Details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
      try
      {
        // Hämta den specika bilen ifrån vårt API...
        var teacher = await _teacherService.FindTeacher(id);
        return View("Details", teacher);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return View("Error");
      }
    }
    [HttpGet("TeacherCompetences")]
    public async Task<IActionResult> TeacherCompetences(int id)
    {
      try
      {
        ViewBag.TeacherId = id;
        var competences = await _teacherService.FindTeacher(id);
        return View("TeacherCompetences", competences);
      }
      catch (System.Exception ex)
      {
        Console.WriteLine(ex.Message);
        return View("Error");
      }
    }
  }
}