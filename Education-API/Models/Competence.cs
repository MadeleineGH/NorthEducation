using System.ComponentModel.DataAnnotations;

namespace Education_API.Models
{
  public class Competence
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<TeacherCompetence>? TeacherCompetences { get; set; }
    }
}