namespace ERP.V7.WebPMS.Services;

public class MenuItem
{
    public string Name { get; set; }
    public string Href { get; set; }
    public string Icon { get; set; }
    public string Category { get; set; }
    public MenuItem(string name, string href, string icon, string category)
    {
        Name = name;
        Href = href;
        Icon = icon;
        Category = category;
    }
}

public static class MenuCatalog
{
    public static readonly List<MenuItem> Items = new()
    {
        // Main Page
        new MenuItem("Document Browser", "document-browser", "bi bi-folder-fill", "Main Page"),
        new MenuItem("Registration Document", "registration-document", "bi bi-file-earmark-text-fill", "Main Page"),
        new MenuItem("Density Chart", "density-chart", "bi bi-bar-chart-steps", "Main Page"),
        new MenuItem("Room Status", "room-status", "bi bi-grid-3x3-gap-fill", "Main Page"),
        new MenuItem("Room Inventory", "room-inventory", "bi bi-key-fill", "Main Page"),
        new MenuItem("Package Audit", "package-audit", "bi bi-file-earmark-check-fill", "Main Page"),

        // Registration
        new MenuItem("Reservation", "reservation", "bi bi-calendar-event-fill", "Registration"),
        new MenuItem("Counter (Check In)", "checkin", "bi bi-plus-square-fill", "Registration"),
        new MenuItem("Group Registration", "group-registration", "bi bi-people-fill", "Registration"),

        // Profile
        new MenuItem("Guest", "guest", "bi bi-person", "Profile"),
        new MenuItem("Contact", "contact", "bi bi-telephone-fill", "Profile"),
        new MenuItem("Company", "company", "bi bi-building", "Profile"),
        new MenuItem("Travel Agent", "travel-agent", "bi bi-airplane-fill", "Profile"),
        new MenuItem("Source", "source", "bi bi-share-fill", "Profile"),
        new MenuItem("Group", "group", "bi bi-people", "Profile"),

        // Night Audit
        new MenuItem("End of Day", "end-of-day", "bi bi-brightness-alt-high-fill", "Night Audit"),
        new MenuItem("End of Month", "end-of-month", "bi bi-calendar-check-fill", "Night Audit"),

        // Reports
        new MenuItem("Reports", "reports", "bi bi-bar-chart-line-fill", "Reports"),

        // Settings
        new MenuItem("Property", "property", "bi bi-house-fill", "Setting And Miscellaneous"),
        new MenuItem("Package", "package", "bi bi-box-seam-fill", "Setting And Miscellaneous"),
        new MenuItem("Revenue Management", "revenue", "bi bi-cash-coin", "Setting And Miscellaneous"),
        new MenuItem("Calendar", "calendar", "bi bi-calendar3", "Setting And Miscellaneous"),
        new MenuItem("Budget", "budget", "bi bi-wallet2", "Setting And Miscellaneous"),
        new MenuItem("License", "license", "bi bi-key-fill", "Setting And Miscellaneous"),
        new MenuItem("ERP Update", "update", "bi bi-arrow-clockwise", "Setting And Miscellaneous"),

        // House Keeping
        new MenuItem("Task Assignment", "housekeeping?tab=0", "bi bi-clipboard-check-fill", "House Keeping"),
        new MenuItem("Room Management", "housekeeping?tab=1", "bi bi-door-open-fill", "House Keeping"),
        new MenuItem("Discrepancy", "housekeeping?tab=2", "bi bi-exclamation-triangle-fill", "House Keeping"),
        new MenuItem("Turndown Management", "housekeeping?tab=3", "bi bi-moon-stars-fill", "House Keeping"),
    };

    public static MenuItem? FindByHref(string href)
    {
        var path = href.TrimStart('/');

        var exact = Items.FirstOrDefault(m => string.Equals(m.Href, path, StringComparison.OrdinalIgnoreCase));
        if (exact is not null)
        {
            return exact;
        }

        var basePath = path.Split('?')[0];
        return Items.FirstOrDefault(m => string.Equals(m.Href.Split('?')[0], basePath, StringComparison.OrdinalIgnoreCase));
    }
}
