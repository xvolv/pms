namespace ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

public class RoomChargeRow
{
    public int SN { get; set; }
    public string RegistrationNo { get; set; } = "";
    public DateTime Date { get; set; }
    public string RoomNo { get; set; } = "";
    public string Consignee { get; set; } = "";
    public decimal Amount { get; set; }
}
