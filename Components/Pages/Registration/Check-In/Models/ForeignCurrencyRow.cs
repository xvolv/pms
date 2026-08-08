namespace ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

public class ForeignCurrencyRow
{
    public int SN { get; set; }
    public string? Currency { get; set; }
    public decimal Amount { get; set; }
    public decimal Rate { get; set; }
    public decimal TotalAmount { get; set; }
    public bool Assign { get; set; }
    public string Remark { get; set; } = "";
}
