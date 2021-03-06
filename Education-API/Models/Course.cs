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
      public string? Description { get; set; }
      public string? Details { get; set; }
      public string? ImageUrl { get; set; }
      public int? CategoryId { get; set; }
      [ForeignKey("CategoryId")]
      public Category? Category { get; set; } = new Category();
      public int? TeacherId { get; set; }
      [ForeignKey("TeacherId")]
      public Teacher? Teacher { get; set; } = new Teacher();
      public ICollection<StudentCourse>? StudentCourses { get; set; }
  }
}