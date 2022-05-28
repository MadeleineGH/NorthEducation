using AutoMapper;
using Education_API.Models;
using Education_API.ViewModels;

namespace Education_API.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
        CreateMap<PostCourseViewModel, Course>();
        CreateMap<Course, CourseViewModel>();
    }
  }
}