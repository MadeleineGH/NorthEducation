using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Education_API.Models;
using Education_API.ViewModels;

namespace Education_API.Data
{
  public class LoadData
  {
    public static async Task LoadCategories(EducationContext context)
    {
      if (await context.Categories.AnyAsync()) return;

      var categoriesData = await File.ReadAllTextAsync("Data/categories.json");
      var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);

      await context.AddRangeAsync(categories!);
      await context.SaveChangesAsync();

    }
    public static async Task LoadCompetences(EducationContext context)
    {
      if (await context.Competences.AnyAsync()) return;

      var competencesData = await File.ReadAllTextAsync("Data/make.json");
      var competences = JsonSerializer.Deserialize<List<Competence>>(competencesData);

      await context.AddRangeAsync(competences!);
      await context.SaveChangesAsync();

    }
    public static async Task LoadCourses(EducationContext context)
    {
      if (await context.Courses.AnyAsync()) return;

      var courseData = await File.ReadAllTextAsync("Data/courses.json");
      var courses = JsonSerializer.Deserialize<List<PostCourseViewModel>>(courseData);

      if (courses is null) return;

      foreach (var course in courses)
      {
        //var category = await context.Categories.SingleOrDefaultAsync(c => c.Title.ToLower() == course.category!.ToLower());
        if (course is not null)
        {
          var newCourse = new Course
          {
            CourseNumber = course.CourseNumber,
            Title = course.Title,
            Duration = course.Duration,
            Description = course.Description,
            Details = course.Details,
            ImageUrl = course.ImageUrl
          };

          context.Courses.Add(newCourse);
        }
      }
      await context.SaveChangesAsync();
    }
    public static async Task LoadStudents(EducationContext context)
    {
      if (await context.Students.AnyAsync()) return;

      var studentData = await File.ReadAllTextAsync("Data/courses.json");
      var students = JsonSerializer.Deserialize<List<PostStudentViewModel>>(studentData);

      if (students is null) return;

      foreach (var student in students)
      {
        //var category = await context.Categories.SingleOrDefaultAsync(c => c.Title.ToLower() == course.category!.ToLower());
        if (student is not null)
        {
          var newStudent = new Student
          {
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            PhoneNumber = student.PhoneNumber,
          };

          context.Students.Add(newStudent);
        }
      }
      await context.SaveChangesAsync();
    }
    public static async Task LoadTeachers(EducationContext context)
    {
      if (await context.Teachers.AnyAsync()) return;

      var teacherData = await File.ReadAllTextAsync("Data/teachers.json");
      var teachers = JsonSerializer.Deserialize<List<PostTeacherViewModel>>(teacherData);

      if (teachers is null) return;

      foreach (var teacher in teachers)
      {
        //var category = await context.Categories.SingleOrDefaultAsync(c => c.Title.ToLower() == course.category!.ToLower());
        if (teacher is not null)
        {
          var newTeacher = new Teacher
          {
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Email = teacher.Email,
            PhoneNumber = teacher.PhoneNumber
          };

          context.Teachers.Add(newTeacher);
        }
      }
      await context.SaveChangesAsync();
    }
    public static async Task LoadAddresses(EducationContext context)
    {
      if (await context.Addresses.AnyAsync()) return;

      var addressData = await File.ReadAllTextAsync("Data/addresses.json");
      var addresses = JsonSerializer.Deserialize<List<PostAddressViewModel>>(addressData);

      if (addresses is null) return;

      foreach (var address in addresses)
      {
        //var category = await context.Categories.SingleOrDefaultAsync(c => c.Title.ToLower() == course.category!.ToLower());
        if (address is not null)
        {
          var newAddress = new Address
          {
            StreetAddress = address.StreetAddress,
            PostalCode = address.PostalCode,
            City = address.City,
            Country = address.Country
          };

          context.Addresses.Add(newAddress);
        }
      }
      await context.SaveChangesAsync();
    }
  }
}