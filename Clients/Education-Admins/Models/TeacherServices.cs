using System.Text.Json;
using Education_Admins.ViewModels;

namespace Education_Admins.Models
{
  public class TeacherServices
  {
    private readonly string _baseUrl;
    private readonly JsonSerializerOptions _options;
    private readonly IConfiguration _config;

    public TeacherServices(IConfiguration config)
    {
      _config = config;
      _baseUrl = $"{_config.GetValue<string>("baseUrl")}/teachers";

      _options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };
    }

    public async Task<List<TeacherViewModel>> ListAllTeachers()
    {
        var url = $"{_baseUrl}/list";

        using var http = new HttpClient();
        var response = await http.GetAsync(url);

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception("An error occured with the connection.");
        }

        var teachers = await response.Content.ReadFromJsonAsync<List<TeacherViewModel>>(); 

        return teachers ?? new List<TeacherViewModel>();
    }
    public async Task<TeacherViewModel> FindTeacher(int id)
    {
      var baseUrl = _config.GetValue<string>("baseUrl");
      var url = $"{baseUrl}/teachers/{id}";

      using var http = new HttpClient();
      var response = await http.GetAsync(url);

      if (!response.IsSuccessStatusCode)
      {
        Console.WriteLine("Couldn't find the teacher.");
      }

      var teacher = await response.Content.ReadFromJsonAsync<TeacherViewModel>();

      return teacher ?? new TeacherViewModel();
    }
    public async Task<bool> CreateTeacher(CreateTeacherViewModel teacher)
    {
      using var http = new HttpClient();
      var baseUrl = _config.GetValue<string>("baseUrl");
      var url = $"{baseUrl}/teachers";

      var response = await http.PostAsJsonAsync(url, teacher);

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