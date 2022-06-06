using Education_Platform.Models;
using Microsoft.AspNetCore.Mvc;

namespace Education_Platform.Controllers
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
                // var vehicleService = new VehicleServiceModel(_config);

                var courses = await _courseService.ListAllCourses();
                return View("Index", courses);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            return View("Details");
        }
    }
}