namespace ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

public class BillSplitItem
{
    public int SN { get; set; }
    public string VoucherNo { get; set; } = "";
    public string Purpose { get; set; } = "";
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
}
