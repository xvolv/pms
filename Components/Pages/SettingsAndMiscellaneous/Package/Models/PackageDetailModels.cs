using System.ComponentModel.DataAnnotations;

namespace ERP.Components.Pages.SettingsAndMiscellaneous.Package.Models
{
    public class HolidayModel
    {
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; } = "PKD0000000003";

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [RegularExpression(@"^\d*\.?\d*$", ErrorMessage = "Please enter a valid number")]
        public string Price { get; set; } = "";

        [Required(ErrorMessage = "Allowance is required")]
        [RegularExpression(@"^\d*\.?\d*$", ErrorMessage = "Please enter a valid number")]
        public string Allowance { get; set; } = "";

        public string Remark { get; set; } = "";

        // Weekday properties
        public bool Sun { get; set; } = true;
        public bool Mon { get; set; } = true;
        public bool Tue { get; set; } = true;
        public bool Wed { get; set; } = true;
        public bool Thu { get; set; } = true;
        public bool Fri { get; set; } = true;
        public bool Sat { get; set; } = true;
    }

    public class PackageGroup
    {
        public string Name { get; set; } = "";
        public string Hotel { get; set; } = "";
        public List<PackageDetailRow> Details { get; set; } = new();
    }

    public class PackageDetailRow
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public decimal Allowance { get; set; }
    }
}
