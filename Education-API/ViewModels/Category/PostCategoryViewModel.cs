using System.ComponentModel.DataAnnotations;

namespace Education_API.ViewModels
{
  public class PostCategoryViewModel
    {
        [Required]
        public string? Title { get; set; }
    }
}