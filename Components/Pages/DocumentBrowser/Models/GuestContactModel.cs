namespace YourProject.Components.DocumentBrowser.Models
{
    public class GuestContactModel
    {
        public string Code { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime? DOB { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string NationalID { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}