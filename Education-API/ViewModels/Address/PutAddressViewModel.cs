using System.ComponentModel.DataAnnotations;

namespace Education_API.ViewModels.Address
{
  public class PutAddressViewModel
    {
        public int AddressId { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}