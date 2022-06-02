using System.ComponentModel.DataAnnotations;

namespace Education_API.ViewModels
{
  public class PostCompetenceViewModel
    {
        [Required]
        public string? Title { get; set; }
    }
}