namespace ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

public class EditDetailModel
{
    public DateTime Date { get; set; }
    public DateTime? ThroughDate { get; set; }
    public int Adult { get; set; } = 1;
    public int Child { get; set; } = 0;
    public string? RoomType { get; set; } = "";
    public string? RTC { get; set; } = "";
    public string Room { get; set; } = "";
    public string RateCode { get; set; } = "";
    public decimal Amount { get; set; } = 0;
    public bool FixedRate { get; set; } = false;
    public int NoOfRooms { get; set; } = 1;
    public decimal Adjustment { get; set; } = 0;
    public string? Source { get; set; } = "";
    public string? Market { get; set; } = "";
}
