using System.Text.Json;
using Education_Admins.ViewModels;

namespace Education_Admins.Models
{
  public class StudentServices
  {
    private readonly string _baseUrl;
    private readonly JsonSerializerOptions _options;
    private readonly IConfiguration _config;

    public StudentServices(IConfiguration config)
    {
      _config = config;
      _baseUrl = $"{_config.GetValue<string>("baseUrl")}/students";

      _options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };
    }

    public async Task<List<StudentViewModel>> ListAllStudents()
    {
      var url = $"{_baseUrl}/list";

      using var http = new HttpClient();
      var response = await http.GetAsync(url);

      if (!response.IsSuccessStatusCode)
      {
        throw new Exception("An error occured with the connection.");
      }

      var students = await response.Content.ReadFromJsonAsync<List<StudentViewModel>>();

      return students ?? new List<StudentViewModel>();
    }
    public async Task<StudentViewModel> FindStudent(int id)
    {
      var baseUrl = _config.GetValue<string>("baseUrl");
      var url = $"{baseUrl}/students/{id}";

      using var http = new HttpClient();
      var response = await http.GetAsync(url);

      if (!response.IsSuccessStatusCode)
      {
        Console.WriteLine("Couldn't find the student.");
      }

      var student = await response.Content.ReadFromJsonAsync<StudentViewModel>();

      return student ?? new StudentViewModel();
    }
    public async Task<EditStudentViewModel> FindStudentToEdit(int id)
    {
      var student = await FindStudent(id);

      var studentToEdit = new EditStudentViewModel
      {
        Id = id,
        FirstName = student.FirstName,
        LastName = student.LastName,
        Email = student.Email,
        PhoneNumber = student.PhoneNumber,
        StreetAddress = student.StreetAddress,
        PostalCode = student.PostalCode,
        City = student.City,
        Country = student.Country
      };
      return studentToEdit;
    }
    public async Task<bool> CreateStudent(CreateStudentViewModel student)
    {
      using var http = new HttpClient();
      var baseUrl = _config.GetValue<string>("baseUrl");
      var url = $"{baseUrl}/students";

      var response = await http.PostAsJsonAsync(url, student);

      if (!response.IsSuccessStatusCode)
      {
        string reason = await response.Content.ReadAsStringAsync();
        Console.WriteLine(reason);
        return false;
      }

      return true;
    }
    public async Task<bool> EditStudent(EditStudentViewModel student, int id)
    {
      using var http = new HttpClient();
      var baseUrl = _config.GetValue<string>("baseUrl");
      var url = $"{baseUrl}/students/{id}";

      var response = await http.PostAsJsonAsync(url, student);

      if (!response.IsSuccessStatusCode)
      {
        string reason = await response.Content.ReadAsStringAsync();
        Console.WriteLine(reason);
        return false;
      }

      return true;
    }
    public async Task<bool> DeleteStudent(int id)
    {
      using var http = new HttpClient();
      var baseUrl = _config.GetValue<string>("baseUrl");
      var url = $"{baseUrl}/students{id}";

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