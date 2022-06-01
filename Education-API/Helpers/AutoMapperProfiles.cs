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
        CreateMap<Course, CourseViewModel>()
        .ForMember(dest => dest.CourseId, options => options.
        MapFrom(src => src.Id));

        CreateMap<CompetenceViewModel, Competence>();
        CreateMap<Competence, CompetenceViewModel>()
        .ForMember(dest => dest.CompetenceId, options => options.
        MapFrom(src => src.Id));
    }
  }
}