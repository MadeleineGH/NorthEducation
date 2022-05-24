using System.ComponentModel.DataAnnotations;

namespace Education_API.Models
{
  public class Address
    {
        [Key]
        public int Id { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}