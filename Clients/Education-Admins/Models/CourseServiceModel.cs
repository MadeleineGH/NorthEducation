using System.Text.Json;
using Education_Admins.ViewModels;

namespace Education_Admins.Models
{
  public class CourseServiceModel
  {
    private readonly string _baseUrl;
    private readonly JsonSerializerOptions _options;
    private readonly IConfiguration _config;

    public CourseServiceModel(IConfiguration config)
    {
        _config = config;
        _baseUrl = $"{_config.GetValue<string>("baseUrl")}";

        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<List<CourseViewModel>> ListAllCourses()
    {
        var url = $"{_baseUrl}/courses";

        using var http = new HttpClient();
        var response = await http.GetAsync(url);

        if(!response.IsSuccessStatusCode)
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
    public async Task<bool> CreateCourse(CreateCourseViewModel course)
    {
      // HÄR BLIR DET FALSE NÄR JAG LÄGGER TILL NY KURS
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
  }
}