using System.ComponentModel.DataAnnotations;

namespace Education_API.ViewModels
{
  public class PatchStudentViewModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
    }
}