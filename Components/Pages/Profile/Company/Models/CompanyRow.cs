namespace ERP.V7.WebPMS.Components.Pages.Profile.Company.Models;

public class CompanyRow
{
    public int Id { get; set; }
    public string CorpId { get; set; } = "";

    // Basic Information
    public string Name { get; set; } = "";
    public string TinNo { get; set; } = "";
    public string BusinessType { get; set; } = "";
    public bool IsActive { get; set; } = true;
    public string Category { get; set; } = "";

    // Additional Information
    public string AccountNo { get; set; } = "";
    public string RateCode { get; set; } = "";
    public string Status { get; set; } = "Active";
    public string MailingAction { get; set; } = "";
    public string Currency { get; set; } = "";
    public string Owner { get; set; } = "";

    // Potential Information
    public int? PotentialRoomNights { get; set; }
    public decimal? PotentialRevenue { get; set; }

    // Address - Contact
    public string SmtpServer { get; set; } = "";
    public string Password { get; set; } = "";
    public string POBox { get; set; } = "";

    // Address - Social Media
    public string Facebook { get; set; } = "";
    public string Website { get; set; } = "";

    // Address - Telephone
    public string OfficePhone { get; set; } = "";
    public string MobilePhone { get; set; } = "";
}
