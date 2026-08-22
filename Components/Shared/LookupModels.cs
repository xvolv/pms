namespace ERP.V7.WebPMS.Components.Shared
{
    public class CustomerItem
    {
        public string Code { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string Tin { get; set; } = "";
    }

    public class GuestItem
    {
        public string FirstName { get; set; } = "";
        public string? MiddleName { get; set; }
        public string Tin { get; set; } = "";

        public string FullName => string.IsNullOrWhiteSpace(MiddleName) ? FirstName : $"{FirstName} {MiddleName}".Trim();
    }

    public class GroupItem
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
    }

    public class RegistrationLookupItem
    {
        public string Code { get; set; } = "";
        public string Guest { get; set; } = "";
        public string RoomNumber { get; set; } = "";
        public string RoomType { get; set; } = "";
    }
}
