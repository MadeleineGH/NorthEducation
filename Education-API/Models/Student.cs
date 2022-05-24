using System.ComponentModel.DataAnnotations;

namespace Education_API.Models
{
  public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Address? Address { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}