using System.ComponentModel.DataAnnotations;

namespace Education_Admins.ViewModels
{
  public class EditCourseViewModel
  {
    public int Id { get; set; }

    [Display(Name = "Title")]
    public string? Title { get; set; }
    [Display(Name = "Duration")]
    public int Duration { get; set; }
    [Display(Name = "Category")]
    public string? CategoryName { get; set; }
    [Display(Name = "Description")]
    public string? Description { get; set; }
    [Display(Name = "Details")]
    public string? Details { get; set; }
    [Display(Name = "Image")]
    public string? ImageUrl { get; set; }
    [Display(Name = "Teacher")]
    public int? TeacherId { get; set; }
    public List<TeacherViewModel>? TeacherList { get; set; }
  }
}