using System.ComponentModel.DataAnnotations;

namespace ERP.V7.WebPMS.Components.Pages.Profile.Contact.Models;

public class ContactRow
{
    public int Id { get; set; }
    public string Code { get; set; } = "";

    [Required(ErrorMessage = "Last Name is required.")]
    public string LastName { get; set; } = "";

    [Required(ErrorMessage = "First Name is required.")]
    public string FirstName { get; set; } = "";
    public string MiddleName { get; set; } = "";

    public string Title { get; set; } = "";
    public string Gender { get; set; } = "Male";
    public string Language { get; set; } = "";
    public bool IsActive { get; set; } = true;

    public string Nationality { get; set; } = "";
    public DateTime? DateOfBirth { get; set; }
    public string IdType { get; set; } = "Passport";
    public string PassportNum { get; set; } = "";

    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    public string Email { get; set; } = "";
    public string POBox { get; set; } = "";

    // Personal Detail
    public string Category { get; set; } = "";
    public string Currency { get; set; } = "";
    public string Status { get; set; } = "Active";
    public string Religion { get; set; } = "";
    public string Account { get; set; } = "";
    public string MailingAction { get; set; } = "";
    public string RateCode { get; set; } = "";

    public string Note { get; set; } = "";
}
