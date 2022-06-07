using Education_API.Models;

namespace Education_API.ViewModels
{
  public class AddressViewModel
    {
        public int AddressId { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}