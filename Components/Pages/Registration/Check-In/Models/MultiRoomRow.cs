namespace ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

public class MultiRoomRow
{
    public int SN { get; set; }
    public string Company { get; set; } = "";
    public string Guest { get; set; } = "";
    public int GuestNo { get; set; } = 1;
    public string Room { get; set; } = "";
    public DateTime Arrival { get; set; }
    public DateTime Departure { get; set; }
    public string Key { get; set; } = "";
    public bool Selected { get; set; }
}
