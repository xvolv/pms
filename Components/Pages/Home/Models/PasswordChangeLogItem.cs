namespace ERP.V7.WebPMS.Components.Pages.Home.Models
{
    public class PasswordChangeLogItem
    {
        public int SN { get; set; }
        public string User { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public string MachineName { get; set; } = string.Empty;
        public string OrganizationUnit { get; set; } = string.Empty;
    }
}
