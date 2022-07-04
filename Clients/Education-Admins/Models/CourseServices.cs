using System.Text.Json;
using Education_Admins.ViewModels;

namespace Education_Admins.Models
{
  public class CourseServices
  {
    private readonly string _baseUrl;
    private readonly JsonSerializerOptions _options;
    private readonly IConfiguration _config;
    private readonly TeacherServices _teacherService;

    public CourseServices(IConfiguration config, TeacherServices teacherService)
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
      var teachers = await _teacherService.ListAllTeachers();

      var courseToEdit = new EditCourseViewModel
      {
        Id = id,
        Title = course.Title,
        CategoryName = course.CategoryName,
        Description = course.Description,
        Details = course.Details,
        Duration = course.Duration,
        ImageUrl = course.ImageUrl,
        TeacherId = course.TeacherId,
        TeacherList = teachers
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
    public async Task<bool> EditCourse(EditCourseViewModel course, int id)
    {
      using var http = new HttpClient();
      var baseUrl = _config.GetValue<string>("baseUrl");
      var url = $"{baseUrl}/courses/{id}";

      var response = await http.PostAsJsonAsync(url, course);

      if (!response.IsSuccessStatusCode)
      {
        string reason = await response.Content.ReadAsStringAsync();
        Console.WriteLine(reason);
        return false;
      }

      return true;
    }
    public async Task<bool> DeleteCourse(int id)
    {
      using var http = new HttpClient();
      var baseUrl = _config.GetValue<string>("baseUrl");
      var url = $"{baseUrl}/courses{id}";

      var response = await http.DeleteAsync(url);

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