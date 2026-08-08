namespace ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

public class RegistrationRow
{
    public int SN { get; set; }
    public string Registration { get; set; } = "";
    public string Room { get; set; } = "";
    public string RoomType { get; set; } = "";
    public string Guest { get; set; } = "";
    public string Company { get; set; } = "";
    public DateTime Arrival { get; set; }
    public DateTime Departure { get; set; }
    public int Nights { get; set; }
    public string Payment { get; set; } = "";
    public string State { get; set; } = "6PM";
    public int RoomCount { get; set; } = 1;
}
