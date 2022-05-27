using Education_API.Models;

namespace Education_API.ViewModels
{
  public class CourseViewModel
    {
        public int CourseId { get; set; }
        public int CourseNumber { get; set; }
        public string? Title { get; set; }
        public int Duration { get; set; }
        public Category? Category { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}