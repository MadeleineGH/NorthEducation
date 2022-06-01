using Education_API.Models;

namespace Education_API.ViewModels
{
  public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Address? Address { get; set; }
    }
}