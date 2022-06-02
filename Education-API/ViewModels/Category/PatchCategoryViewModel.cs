using System.ComponentModel.DataAnnotations;

namespace Education_API.ViewModels
{
  public class PatchCategoryViewModel
    {
        [Required]
        public string? Title { get; set; }
    }
}