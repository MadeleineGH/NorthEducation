using Microsoft.AspNetCore.Mvc;

namespace Education_Platform.Controllers
{
  [Route("[controller]")]
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}