using System.ComponentModel.DataAnnotations;

namespace Education_API.ViewModels
{
  public class PatchCourseViewModel
    {
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Details { get; set; }
    }
}