using System.Text.Json;
using Education_Admins.ViewModels;

namespace Education_Admins.Models
{
  public class CourseServiceModel
  {
    private readonly string _baseUrl;
    private readonly JsonSerializerOptions _options;
    private readonly IConfiguration _config;
    private readonly TeacherServiceModel _teacherService;

    public CourseServiceModel(IConfiguration config, TeacherServiceModel teacherService)
    {
      _teacherService = teacherService;
      _config = config;
      _baseUrl = $"{_config.GetValue<string>("baseUrl")}/courses";

      _options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };
    }

    public async Task<List<CourseViewModel>> ListAllCourses()
    {
      var url = $"{_baseUrl}/list";

      using var http = new HttpClient();
      var response = await http.GetAsync(url);

      if (!response.IsSuccessStatusCode)
      {
        throw new Exception("An error occured with the connection.");
      }

      var courses = await response.Content.ReadFromJsonAsync<List<CourseViewModel>>();

      return courses ?? new List<CourseViewModel>();
    }
    public async Task<CourseViewModel> FindCourse(int id)
    {
      var baseUrl = _config.GetValue<string>("baseUrl");
      var url = $"{baseUrl}/courses/{id}";

      using var http = new HttpClient();
      var response = await http.GetAsync(url);

      if (!response.IsSuccessStatusCode)
      {
        Console.WriteLine("Couldn't find the course.");
      }

      var course = await response.Content.ReadFromJsonAsync<CourseViewModel>();

      return course ?? new CourseViewModel();
    }
    public async Task<EditCourseViewModel> FindCourseToEdit(int id)
    {
      var course = await FindCourse(id);

      var courseToEdit = new EditCourseViewModel{
        CourseNumber = course.CourseNumber,
        Title  = course.Title,
        CategoryName = course.CategoryName,
        Description = course.Description,
        Details = course.Details,
        Duration = course.Duration,
        ImageUrl = course.ImageUrl,
        Teachers = await _teacherService.ListAllTeachers()
      };
      return courseToEdit;
    }
    public async Task<bool> CreateCourse(CreateCourseViewModel course)
    {
      using var http = new HttpClient();
      var baseUrl = _config.GetValue<string>("baseUrl");
      var url = $"{baseUrl}/courses";

      var response = await http.PostAsJsonAsync(url, course);

      if (!response.IsSuccessStatusCode)
      {
        string reason = await response.Content.ReadAsStringAsync();
        Console.WriteLine(reason);
        return false;
      }

      return true;
    }
      // Ändra till CreateCourse
    public async Task<bool> EditCourse(int id, EditCourseViewModel course)
    {
      using var http = new HttpClient();
      var baseUrl = _config.GetValue<string>("baseUrl");
      var url = $"{baseUrl}/courses/{id}";

      // Ändra till CreateCourse
      var response = await http.PutAsJsonAsync(url, (course as EditCourseViewModel));

      if (!response.IsSuccessStatusCode)
      {
        string reason = await response.Content.ReadAsStringAsync();
        Console.WriteLine(reason);
        return false;
      }

      return true;
    }
  }
}