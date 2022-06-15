using AutoMapper;
using Education_API.Models;
using Education_API.ViewModels;
using Education_API.ViewModels.Category;

namespace Education_API.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
        CreateMap<PostCourseViewModel, Course>();
        CreateMap<Course, CourseViewModel>()
          .ForMember(dest => dest.CourseId, options => options
          .MapFrom(src => src.Id))
          .ForMember(dest => dest.CategoryName, options => options
          .MapFrom(src => src.Category!.Title));

        CreateMap<PostCategoryViewModel, Category>();
        CreateMap<PutCategoryViewModel, Category>();
        CreateMap<Category, CategoryViewModel>()
          .ForMember(dest => dest.CategoryId, options => options
          .MapFrom(src => src.Id));

        CreateMap<PostCompetenceViewModel, Competence>();
        CreateMap<Competence, CompetenceViewModel>()
          .ForMember(dest => dest.CompetenceId, options => options.
          MapFrom(src => src.Id));

        CreateMap<PostStudentViewModel, Student>();
        CreateMap<Student, StudentViewModel>()
          .ForMember(dest => dest.StudentId, options => options.
          MapFrom(src => src.Id));

        CreateMap<PostTeacherViewModel, Teacher>();
        CreateMap<Teacher, TeacherViewModel>()
          .ForMember(dest => dest.TeacherId, options => options.
          MapFrom(src => src.Id));

   
    }
  }
}