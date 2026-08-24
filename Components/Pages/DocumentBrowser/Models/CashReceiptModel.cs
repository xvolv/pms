namespace YourProject.Components.DocumentBrowser.Models
{
    public class CashReceiptModel
    {
        public string Code { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string TIN { get; set; } = string.Empty;
        public DateTime? IssuedDate { get; set; }
        public string OriginBranch { get; set; } = string.Empty;
        public decimal GrandTotal { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string DeviceName { get; set; } = string.Empty;
        public string LastState { get; set; } = string.Empty;
    }
}