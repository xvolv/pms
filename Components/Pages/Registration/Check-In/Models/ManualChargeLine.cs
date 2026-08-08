namespace ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

public class ManualChargeLine
{
    public int SN { get; set; }
    public string Description { get; set; } = "";
    public decimal UnitPrice { get; set; }
    public int Qty { get; set; }
    public decimal Tax { get; set; }
    public decimal TotalPrice { get; set; }
}
