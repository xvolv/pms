using System.ComponentModel.DataAnnotations;

namespace ERP.V7.WebPMS.Components.Pages.Profile.Company.Models;

public class CompanyRow
{
    public int Id { get; set; }
    public string CorpId { get; set; } = "";

    // Basic Information
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "TIN No is required.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "TIN No must be 10 digits.")]
    public string TinNo { get; set; } = "";

    [Required(ErrorMessage = "Business Type is required.")]
    public string BusinessType { get; set; } = "";
    public bool IsActive { get; set; } = true;

    [Required(ErrorMessage = "Category is required.")]
    public string Category { get; set; } = "";

    // Additional Information
    public string AccountNo { get; set; } = "";
    public string RateCode { get; set; } = "";
    public string Status { get; set; } = "Active";
    public string MailingAction { get; set; } = "";
    public string Currency { get; set; } = "";
    public string Owner { get; set; } = "";

    // Potential Information
    [Range(0, int.MaxValue, ErrorMessage = "Potential Roomnights cannot be negative.")]
    public int? PotentialRoomNights { get; set; }

    [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "Potential Revenue cannot be negative.")]
    public decimal? PotentialRevenue { get; set; }

    // Address - Contact
    public string SmtpServer { get; set; } = "";
    public string Password { get; set; } = "";
    public string POBox { get; set; } = "";

    // Address - Social Media
    public string Facebook { get; set; } = "";

    [Url(ErrorMessage = "Enter a valid website URL.")]
    public string Website { get; set; } = "";

    // Address - Telephone
    [Phone(ErrorMessage = "Enter a valid office phone number.")]
    public string OfficePhone { get; set; } = "";

    [Phone(ErrorMessage = "Enter a valid mobile phone number.")]
    public string MobilePhone { get; set; } = "";
}
