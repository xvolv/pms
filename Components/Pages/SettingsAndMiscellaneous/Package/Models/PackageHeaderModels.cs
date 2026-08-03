using System.ComponentModel.DataAnnotations;

namespace ERP.Components.Pages.SettingsAndMiscellaneous.Package.Models
{
    public class PackageHeaderModel
    {
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; } = "";

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Group is required")]
        public string Group { get; set; } = "";

        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; } = "";

        [Required(ErrorMessage = "Currency is required")]
        public string Currency { get; set; } = "";

        [Required(ErrorMessage = "Article is required")]
        public string Article { get; set; } = "";

        [Required(ErrorMessage = "Posting Rhythm is required")]
        public string PostingRhythm { get; set; } = "";

        public string RateAppearance { get; set; } = "";
        public bool SaleSeparate { get; set; } = true;
        public string CalculateRule { get; set; } = "";
        public string Formula { get; set; } = "";
        public string Remark { get; set; } = "";
    }

    public class ArticleLookupItem
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Preference { get; set; } = "";
    }
}
