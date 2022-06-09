using System.ComponentModel.DataAnnotations;

namespace Education_Students.ViewModels
{
  public class CreateCourseViewModel
  {
    [Required(ErrorMessage = "Course number is mandatory")]
    [Display(Name = "Course number")]
    public int CourseNumber { get; set; }

    [Required(ErrorMessage = "Title is mandatory")]
    [Display(Name = "Title")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Duration is mandatory")]
    [Display(Name = "Duration")]
    public int Duration { get; set; }

    [Required(ErrorMessage = "Description is mandatory")]
    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Details is mandatory")]
    [Display(Name = "Details")]
    public string? Details { get; set; }

    [Required(ErrorMessage = "Category mandatory")]
    [Display(Name = "Category")]
    public string? Category { get; set; }

    [Required(ErrorMessage = "Image is mandatory")]
    [Display(Name = "Image")]
    public string? ImageUrl { get; set; }
  }
}