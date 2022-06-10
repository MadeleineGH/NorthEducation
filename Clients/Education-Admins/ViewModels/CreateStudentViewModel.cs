using System.ComponentModel.DataAnnotations;

namespace Education_Admins.ViewModels
{
  public class CreateStudentViewModel
  {
    [Required(ErrorMessage = "First name is mandatory")]
    [Display(Name = "First name")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is mandatory")]
    [Display(Name = "Last name")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email is mandatory")]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Phone number is mandatory")]
    [Display(Name = "Phone number")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Street address is mandatory")]
    [Display(Name = "Street address")]
    public string? StreetAddress { get; set; }

    [Required(ErrorMessage = "Postal code is mandatory")]
    [Display(Name = "Postal code")]
    public string? PostalCode { get; set; }

    [Required(ErrorMessage = "City is mandatory")]
    [Display(Name = "City")]
    public string? City { get; set; }

    [Required(ErrorMessage = "Country is mandatory")]
    [Display(Name = "Country")]
    public string? Country { get; set; }
  }
}