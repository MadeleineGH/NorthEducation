using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Education_API.Models
{
  public class Course
    {
        [Key]
        public int Id { get; set; }
        public int CourseNumber { get; set; }
        public string? Title { get; set; }
        public int Duration { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}