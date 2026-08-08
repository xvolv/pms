namespace ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

/// <summary>
/// Represents a room row in the Room Search popup.
/// Named RoomSearchItem to avoid collision with Room-module's RoomItem.
/// </summary>
public class RoomSearchItem
{
    public int SN { get; set; }
    public string Room { get; set; } = "";
    public string RoomType { get; set; } = "";
    public string HKStatus { get; set; } = "";
    public string FOStatus { get; set; } = "";
    public string Floor { get; set; } = "";
    public string Feature { get; set; } = "";
    public string Remark { get; set; } = "";
}
