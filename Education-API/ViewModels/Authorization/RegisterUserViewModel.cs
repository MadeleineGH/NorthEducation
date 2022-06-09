using System.ComponentModel.DataAnnotations;

namespace Education_API.ViewModels.Authorization
{
  public class RegisterUserViewModel
  {
    [Required]
    [EmailAddress(ErrorMessage = "Invalid e-mail address")]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    public bool IsAdmin { get; set; } = false;
  }
}