using System.ComponentModel.DataAnnotations;

namespace Education_API.ViewModels.Category
{
  public class PutCategoryViewModel
    {
        [Required]
        public string? Title { get; set; }
    }
}