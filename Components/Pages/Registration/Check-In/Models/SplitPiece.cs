namespace ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

public class SplitPiece
{
    public int SN { get; set; }
    public string VoucherNo { get; set; } = "";
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public bool Expanded { get; set; }
    public List<SplitLineItem> LineItems { get; set; } = new();
}

public class SplitLineItem
{
    public string ArticleCode { get; set; } = "";
    public string Name { get; set; } = "";
    public decimal UnitAmount { get; set; }
    public decimal Quantity { get; set; }
    public decimal TotalAmount { get; set; }
}
