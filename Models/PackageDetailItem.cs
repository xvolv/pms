namespace PackageApp.Models;

/// <summary>
/// A rate-period row belonging to a PackageHeader
/// (Start Date / End Date / Price / Allowance).
/// </summary>
public class PackageDetailItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string PackageCode { get; set; } = "";
    public DateTime StartDate { get; set; } = DateTime.Today;
    public DateTime EndDate { get; set; } = DateTime.Today;
    public decimal Price { get; set; }
    public decimal Allowance { get; set; }

    public PackageDetailItem Clone() => (PackageDetailItem)MemberwiseClone();
}
