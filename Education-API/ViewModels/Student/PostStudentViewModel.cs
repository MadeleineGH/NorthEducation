using System.ComponentModel.DataAnnotations;
using Education_API.Models;

namespace Education_API.ViewModels
{
  public class PostStudentViewModel
    {
        public int StudentId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? StreetAddress { get; set; }
        [Required]
        public string? PostalCode { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Country { get; set; }
    }
} 