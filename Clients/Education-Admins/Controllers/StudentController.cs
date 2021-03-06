using Education_Admins.Models;
using Education_Admins.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Education_Admins.Controllers
{
  [Route("[controller]")]
  public class StudentController : Controller
  {
    private readonly IConfiguration _config;
    private readonly StudentServices _studentService;

    public StudentController(IConfiguration config)
    {
      _config = config;
      _studentService = new StudentServices(_config);
    }

    [HttpGet()]
    public async Task<IActionResult> Index()
    {
      try
      {
        var students = await _studentService.ListAllStudents();
        return View("Index", students);
      }
      catch (System.Exception)
      {
        throw;
      }
      ViewBag.Students = _studentService.ListAllStudents();
      return View();
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
      // Skicka in en tom vy till formuläret
      var student = new CreateStudentViewModel();
      return View("Create", student);
    }
    // Fungera som mottagare av formulärets data
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateStudentViewModel student)
    {
      if (!ModelState.IsValid)
      {
        return View("Create", student);
      }

      if (await _studentService.CreateStudent(student))
      {
        return View("Confirmation");
      }

      return View("Create", student);
    }
    [HttpGet("Edit")]
    public async Task<IActionResult> Edit(int id)
    {
      // Skicka in en studentvy till formuläret
      var student = await _studentService.FindStudentToEdit(id);
      return View("Edit", student);
    }
    [HttpPost("Edit")]
    public async Task<IActionResult> Edit(EditStudentViewModel student, int id)
    {
      if (!ModelState.IsValid)
      {
        return View("Edit", student);
      }

      if (await _studentService.EditStudent(student, id))
      {
        return View("ConfirmationUpdate");
      }

      return View("Edit", student);
    }
    [HttpGet("Details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
      try
      {
        // Hämta den specika bilen ifrån vårt API...
        var student = await _studentService.FindStudent(id);
        return View("Details", student);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return View("Error");
      }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentToDelete(int id)
    {
      var student = await _studentService.FindStudent(id);

      if (student == null)
      {
        return NotFound();
      }
      return View("Delete", student);
    }
    [HttpPost("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      await _studentService.DeleteStudent(id);
      return RedirectToAction("Index");
    }
  }
}