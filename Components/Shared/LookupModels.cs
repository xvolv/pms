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
        public string Company { get; set; } = "";
        public bool Selected { get; set; }
    }

    public class ContactItem
    {
        public string Code { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string Phone { get; set; } = "";
        public string FullName => $"{FirstName} {MiddleName}".Trim();
    }

    public class AgentItem
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string IataNo { get; set; } = "";
        public string AgentType { get; set; } = "";
    }

    public class SourceItem
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string SourceType { get; set; } = "";
    }

    public class RateRow
    {
        public string Name { get; set; } = "";
        public string StandardRoom { get; set; } = "";
        public string Executive { get; set; } = "";
        public string PseudoRooms { get; set; } = "";
    }
}
