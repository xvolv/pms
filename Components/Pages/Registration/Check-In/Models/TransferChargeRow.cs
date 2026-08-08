namespace ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

public class TransferChargeRow
{
    public int SN { get; set; }
    public DateTime Date { get; set; }
    public string RoomNo { get; set; } = "";
    public string RoomType { get; set; } = "";
    public string RoomRate { get; set; } = "";
    public int Adults { get; set; }
    public int Child { get; set; }
    public string Remark { get; set; } = "";
    public decimal Amount { get; set; }
    public bool Selected { get; set; }
}
