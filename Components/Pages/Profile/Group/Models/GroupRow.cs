using System.ComponentModel.DataAnnotations;

namespace ERP.V7.WebPMS.Components.Pages.Profile.Group.Models;

public class GroupRow
{
    public int Id { get; set; }
    public string GroupId { get; set; } = "";

    // Basic Information
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Group Code is required.")]
    public string GroupCode { get; set; } = "";

    [Required(ErrorMessage = "Group Type is required.")]
    public string GroupType { get; set; } = "";
    public bool IsActive { get; set; } = true;

    [Required(ErrorMessage = "Category is required.")]
    public string Category { get; set; } = "";

    // Additional Information
    public string AccountNo { get; set; } = "";
    public string TaxType { get; set; } = "";
    public string RateCode { get; set; } = "";
    public string Status { get; set; } = "Active";
    public string MailingAction { get; set; } = "";
    public string Currency { get; set; } = "";
    public string Owner { get; set; } = "";

    // Address
    public string Phone1 { get; set; } = "";
    public string Phone2 { get; set; } = "";

    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    public string Email { get; set; } = "";

    [Url(ErrorMessage = "Enter a valid website URL.")]
    public string Website { get; set; } = "";
    public string Kebele { get; set; } = "";
    public string Street { get; set; } = "";
    public string Address1 { get; set; } = "";
    public string POBox { get; set; } = "";
    public string Region { get; set; } = "";
    public string City { get; set; } = "";
    public string SubCity { get; set; } = "";
    public string Wereda { get; set; } = "";
}
