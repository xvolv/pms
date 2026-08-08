namespace ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

public class ExtraBillRow
{
    public int SN { get; set; }
    public string RoomNo { get; set; } = "";
    public DateTime Date { get; set; }
    public string InvoiceId { get; set; } = "";
    public decimal SerCharge { get; set; }
    public decimal Discount { get; set; }
    public decimal Vat { get; set; }
    public decimal SubTotal { get; set; }
    public string Remark { get; set; } = "";
    public decimal GrandTotal { get; set; }
    public bool Selected { get; set; }
    public bool Expanded { get; set; }
}
