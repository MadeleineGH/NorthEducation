using System.ComponentModel.DataAnnotations;
using Education_API.Models;

namespace Education_API.ViewModels
{
  public class PostAddressViewModel
    {
        public int AddressId { get; set; }
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