namespace YourProject.Components.DocumentBrowser.Models
{
    public class CashSalesModel
    {
        public string Code { get; set; } = string.Empty;
        public DateTime? IssuedDate { get; set; }
        public decimal GrandTotal { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string DeviceName { get; set; } = string.Empty;
        public string LastState { get; set; } = string.Empty;
    }
}