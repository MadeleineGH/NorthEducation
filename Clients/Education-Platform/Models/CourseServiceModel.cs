using System.Text.Json;
using Education_Platform.ViewModels;

namespace Education_Platform.Models
{
  public class CourseServiceModel
  {
    private readonly string _baseUrl;
    private readonly JsonSerializerOptions _options;
    private readonly IConfiguration _config;

    public CourseServiceModel(IConfiguration config)
    {
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

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception("An error occured with the connection.");
        }

        var courses = await response.Content.ReadFromJsonAsync<List<CourseViewModel>>(); 

        return courses ?? new List<CourseViewModel>();
    }
  }
}