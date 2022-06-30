using System.Text.Json;
using Education_Admins.ViewModels;

namespace Education_Admins.Models
{
  public class CategoryServices
  {
    private readonly string _baseUrl;
    private readonly JsonSerializerOptions _options;
    private readonly IConfiguration _config;

    public CategoryServices(IConfiguration config)
    {
      _config = config;
      _baseUrl = $"{_config.GetValue<string>("baseUrl")}/categories";

      _options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };
    }

    public async Task<List<CategoryViewModel>> ListAllCategories()
    {
      var url = $"{_baseUrl}/list";

      using var http = new HttpClient();
      var response = await http.GetAsync(url);

      if (!response.IsSuccessStatusCode)
      {
        throw new Exception("An error occured with the connection.");
      }

      var categories = await response.Content.ReadFromJsonAsync<List<CategoryViewModel>>();

      return categories ?? new List<CategoryViewModel>();
    }
  }
}