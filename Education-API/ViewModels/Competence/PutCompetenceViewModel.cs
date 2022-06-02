using System.ComponentModel.DataAnnotations;

namespace Education_API.ViewModels.Competence
{
  public class PutCompetenceViewModel
    {
        [Required]
        public string? Title { get; set; }
    }
}