using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education_Admins.ViewModels
{
  public class EditCourseViewModel : CreateCourseViewModel
  {
    public int Id { get; set; }
    public List<string>? Teacher { get; set; }
  }
}