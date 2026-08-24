namespace ERP.V7.WebPMS.Components.Pages.RoomInventory.Models;

public class RoomInventoryRow
{
    public string RoomType { get; set; } = "";
    public Dictionary<int, int> DailyCounts { get; set; } = new();
}
