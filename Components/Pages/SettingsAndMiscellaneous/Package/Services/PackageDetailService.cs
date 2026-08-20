using ERP.Components.Pages.SettingsAndMiscellaneous.Package.Models;

namespace ERP.Components.Pages.SettingsAndMiscellaneous.Package.Services
{
    public class PackageDetailService
    {
        private List<PackageGroup> _packageGroups = new()
        {
            new PackageGroup
            {
                Name = "Lunch",
                Hotel = "Hilton",
                Details = new()
                {
                    new PackageDetailRow
                    {
                        StartDate = new DateTime(2017, 5, 6),
                        EndDate = new DateTime(2018, 5, 31),
                        Price = 60.00m,
                        Allowance = 0.00m
                    },
                    new PackageDetailRow
                    {
                        StartDate = new DateTime(2018, 6, 1),
                        EndDate = new DateTime(2019, 5, 31),
                        Price = 65.00m,
                        Allowance = 5.00m
                    },
                    new PackageDetailRow
                    {
                        StartDate = new DateTime(2019, 6, 1),
                        EndDate = new DateTime(2020, 5, 31),
                        Price = 70.00m,
                        Allowance = 10.00m
                    }
                }
            },
            new PackageGroup
            {
                Name = "Lunch 2",
                Hotel = "Hilton",
                Details = new()
                {
                    new PackageDetailRow
                    {
                        StartDate = new DateTime(2017, 5, 6),
                        EndDate = new DateTime(2018, 5, 31),
                        Price = 60.00m,
                        Allowance = 0.00m
                    },
                    
                }
            },
            new PackageGroup
            {
                Name = "Suit Lunch",
                Hotel = "Marriott",
                Details = new()
            }
        };

        public List<PackageGroup> GetPackageGroups()
        {
            return _packageGroups;
        }

        public PackageGroup? GetFirstGroup()
        {
            return _packageGroups.FirstOrDefault();
        }

        public void AddDetail(PackageGroup group, HolidayModel model)
        {
            if (group == null) return;

            if (!decimal.TryParse(model.Price, out var price))
            {
                throw new ArgumentException("Invalid price format");
            }

            if (!decimal.TryParse(model.Allowance, out var allowance))
            {
                throw new ArgumentException("Invalid allowance format");
            }

            group.Details.Add(new PackageDetailRow
            {
                StartDate = model.StartDate ?? DateTime.Today,
                EndDate = model.EndDate ?? DateTime.Today,
                Price = price,
                Allowance = allowance
            });
        }

        public void UpdateDetail(PackageDetailRow row, HolidayModel model)
        {
            if (row == null) return;

            if (!decimal.TryParse(model.Price, out var price))
            {
                throw new ArgumentException("Invalid price format");
            }

            if (!decimal.TryParse(model.Allowance, out var allowance))
            {
                throw new ArgumentException("Invalid allowance format");
            }

            row.StartDate = model.StartDate ?? DateTime.Today;
            row.EndDate = model.EndDate ?? DateTime.Today;
            row.Price = price;
            row.Allowance = allowance;
        }

        public HolidayModel CreateDefaultModel()
        {
            return new HolidayModel
            {
                Code = "PKD0000000003",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1),
                Price = "",
                Allowance = "",
                Remark = "",
                Sun = true,
                Mon = true,
                Tue = true,
                Wed = true,
                Thu = true,
                Fri = true,
                Sat = true
            };
        }

        public HolidayModel CreateModelFromRow(PackageDetailRow row)
        {
            return new HolidayModel
            {
                Code = "PKD0000000003",
                StartDate = row.StartDate,
                EndDate = row.EndDate,
                Price = row.Price.ToString("0.00"),
                Allowance = row.Allowance.ToString("0.00"),
                Remark = "",
                Sun = true,
                Mon = true,
                Tue = true,
                Wed = true,
                Thu = true,
                Fri = true,
                Sat = true
            };
        }
    }
}
