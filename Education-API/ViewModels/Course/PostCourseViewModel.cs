using System.ComponentModel.DataAnnotations;

namespace Education_API.ViewModels
{
  public class PostCourseViewModel
    {
        [Required(ErrorMessage = "Course number is mandatory.")]
        public int CourseNumber { get; set; }
        public string? Title { get; set; }
        public int Duration { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public string? ImageUrl { get; set; }
    }
}