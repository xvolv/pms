namespace ERP.V7.WebPMS.Components.Pages.Room;

public class RoomTypeRow
{
    public int Id { get; set; }
    public int Sn { get; set; }
    public string Code { get; set; } = "";
    public string Description { get; set; } = "";
    public int NoOfRooms { get; set; }
    public bool Status { get; set; }
    public DateTime? ActivationDate { get; set; }
    public string ComponentRoom { get; set; } = "";
    public string RoomClass { get; set; } = "Non-VIP";
    public int DefaultOccupancy { get; set; }
    public int MaximumOccupancy { get; set; }
    public int MaximumAdult { get; set; }
    public int MaximumChilds { get; set; }
    public bool IsHouseKeeping { get; set; }
    public bool IsPseudoRoom { get; set; }
    public bool CanBeMeetingRoom { get; set; }
    public bool AutoRoomAssign { get; set; }
}
