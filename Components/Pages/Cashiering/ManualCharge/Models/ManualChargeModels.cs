namespace ERP.V7.WebPMS.Components.Pages.Cashiering.ManualCharge.Models;

public class ManualChargeHeader
{
    public string No { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Today;

    public string Registration { get; set; } = "";
    public string Room { get; set; } = "";
    public string Reference { get; set; } = "";
    public string Window { get; set; } = "";

    public string ChargeType { get; set; } = "";
    public string TransactionType { get; set; } = "";
    public string Currency { get; set; } = "";

    public decimal Discount { get; set; }
    public decimal AdditionalCharge { get; set; }

    public string Remark { get; set; } = "";
}

public class ManualChargeLineItem
{
    public int Id { get; set; }
    public string Article { get; set; } = "";
    public decimal Qty { get; set; } = 1;
    public decimal Amount { get; set; }
    public decimal Total => Qty * Amount;
    public string Remark { get; set; } = "";
}
