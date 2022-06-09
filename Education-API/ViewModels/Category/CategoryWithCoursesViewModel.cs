using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education_API.ViewModels.Category
{
  public class CategoryWithCoursesViewModel
  {
    public int CategoryId { get; set; }
    public string? Title { get; set; }
    public List<CourseViewModel> Courses { get; set; } = new List<CourseViewModel>();
  }
}