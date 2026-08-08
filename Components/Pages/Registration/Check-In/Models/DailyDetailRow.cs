namespace ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

public class DailyDetailRow
{
    public int SN { get; set; }
    public DateTime Date { get; set; }
    public string WeekDay => Date.ToString("dddd");
    public int Adult { get; set; } = 1;
    public int Child { get; set; } = 0;
    public int RoomCount { get; set; } = 1;
    public string RoomType { get; set; } = "";
    public string ActualRTC { get; set; } = "";
    public string Room { get; set; } = "";
    public string Rate { get; set; } = "Standard Rate";
    public decimal RateAmount { get; set; } = 50;
    public string Market { get; set; } = "Corporate Business";
    public string Source { get; set; } = "Company Direct";
    public bool IsFixed { get; set; } = true;
    public List<PackageRow> Packages { get; set; } = new();
    public bool Expanded { get; set; } = false;
}
