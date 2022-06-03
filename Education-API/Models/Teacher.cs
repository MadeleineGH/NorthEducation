using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
         public int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address? Address { get; set; }
        public ICollection<TeacherCompetence>? TeacherCompetences { get; set; }
    }
}