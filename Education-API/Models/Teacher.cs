using System.ComponentModel.DataAnnotations;

namespace Education_API.Models
{
  public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public ICollection<TeacherCompetence>? TeacherCompetences { get; set; }
    }
}