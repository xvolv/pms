using ERP.Components.Pages.SettingsAndMiscellaneous.Package.Models;

namespace ERP.Components.Pages.SettingsAndMiscellaneous.Package.Services
{
    public class PackageHeaderService
    {
        private List<PackageHeaderModel> _packages = new()
        {
            new PackageHeaderModel
            {
                Code = "PK001",
                Description = "Lunch Package",
                Hotel = "Hilton",
                Group = "Food",
                Type = "Standard",
                Currency = "USD",
                Article = "Lunch",
                PostingRhythm = "Monthly"
            },
            new PackageHeaderModel
            {
                Code = "PK002",
                Description = "Dinner Package",
                Hotel = "Marriott",
                Group = "Food",
                Type = "Premium",
                Currency = "USD",
                Article = "Dinner",
                PostingRhythm = "Weekly"
            },
            new PackageHeaderModel
            {
                Code = "PK003",
                Description = "Breakfast Package",
                Hotel = "Hilton",
                Group = "Food",
                Type = "Standard",
                Currency = "USD",
                Article = "Breakfast",
                PostingRhythm = "Daily"
            }
        };

        public List<PackageHeaderModel> GetPackages()
        {
            return _packages;
        }

        public void AddPackage(PackageHeaderModel package)
        {
            if (package == null) return;

            if (string.IsNullOrWhiteSpace(package.Code))
            {
                package.Code = GenerateNextCode();
            }

            _packages.Add(package);
        }

        public void UpdatePackage(PackageHeaderModel package)
        {
            if (package == null) return;

            var existing = _packages.FirstOrDefault(p => p.Code == package.Code);
            if (existing != null)
            {
                existing.Description = package.Description;
                existing.Hotel = package.Hotel;
                existing.Group = package.Group;
                existing.Type = package.Type;
                existing.Currency = package.Currency;
                existing.Article = package.Article;
                existing.PostingRhythm = package.PostingRhythm;
                existing.RateAppearance = package.RateAppearance;
                existing.SaleSeparate = package.SaleSeparate;
                existing.CalculateRule = package.CalculateRule;
                existing.Formula = package.Formula;
                existing.Remark = package.Remark;
            }
        }

        public void DeletePackage(PackageHeaderModel package)
        {
            if (package == null) return;

            _packages.Remove(package);
        }

        public PackageHeaderModel CreateDefaultModel()
        {
            return new PackageHeaderModel
            {
                Code = GenerateNextCode(),
                Description = "",
                Hotel = "",
                Group = "",
                Type = "",
                Currency = "",
                Article = "",
                PostingRhythm = "",
                RateAppearance = "",
                SaleSeparate = true,
                CalculateRule = "",
                Formula = "",
                Remark = ""
            };
        }

        public string GenerateNextCode()
        {
            var next = _packages.Count + 1;
            return $"PK{next:000}";
        }
    }
}
