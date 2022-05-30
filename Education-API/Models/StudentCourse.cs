using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Education_API.Models
{
  public class StudentCourse
    {
        [Key]
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }
    }
}