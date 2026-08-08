namespace ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

public class PaymentHistoryRow
{
    public int SN { get; set; }
    public DateTime Date { get; set; }
    public string ReceiptNo { get; set; } = "";
    public string VoucherType { get; set; } = "";
    public string ReceivedBy { get; set; } = "";
    public string Remark { get; set; } = "";
    public decimal Amount { get; set; }
    public bool Selected { get; set; }
}
