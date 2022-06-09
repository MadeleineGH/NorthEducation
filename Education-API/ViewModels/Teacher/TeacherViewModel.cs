using Education_API.Models;

namespace Education_API.ViewModels
{
  public class TeacherViewModel
    {
        public int TeacherId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public ICollection<CompetenceViewModel>? Competences { get; set; }
    }
}