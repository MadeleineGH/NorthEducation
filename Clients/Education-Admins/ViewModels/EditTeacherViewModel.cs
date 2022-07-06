using System.ComponentModel.DataAnnotations;

namespace Education_Admins.ViewModels
{
  public class EditTeacherViewModel
  {
    public int Id { get; set; }
    [Display(Name = "First name")]
    public string? FirstName { get; set; }
    [Display(Name = "Last name")]
    public string? LastName { get; set; }
    [Display(Name = "E-mail")]
    public string? Email { get; set; }
    [Display(Name = "Phone number")]
    public string? PhoneNumber { get; set; }
    [Display(Name = "Street address")]
    public string? StreetAddress { get; set; }
    [Display(Name = "Postal code")]
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
  }
}