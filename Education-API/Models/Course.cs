using System.ComponentModel.DataAnnotations;

namespace Education_API.Models
{
  public class Course
    {
        [Key]
        public int Id { get; set; }
        public int CourseNumber { get; set; }
        public string? Title { get; set; }
        public int Duration { get; set; }
        public Category? Category { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}