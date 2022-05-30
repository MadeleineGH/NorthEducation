using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Education_API.Models
{
  public class TeacherCompetence
    {
        [Key]
        public int TeacherId { get; set; }
        public int CompetenceId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher? Teacher { get; set; }
        [ForeignKey("CompetenceId")]
        public Competence? Competence { get; set; }
    }
}