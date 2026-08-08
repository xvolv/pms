namespace ERP.V7.WebPMS.Components.Pages.HouseKeeping.Models;

public class TaskAssignmentRow
{
    public int Id { get; set; }
    public DateTime TaskDate { get; set; }
    public bool Auto { get; set; }
    public int TotalSheets { get; set; }
    public int TotalCredits { get; set; }
    public bool IsExpanded { get; set; }
    public List<TaskDetailRow> Details { get; set; } = new();
}

public class TaskDetailRow
{
    public string AttendantCode { get; set; } = "";
    public string AttendantName { get; set; } = "";
    public int TotalRooms { get; set; }
    public int TotalCredit { get; set; }
    public List<RoomTaskRow> Rooms { get; set; } = new();
}

public class AttendantRow
{
    public string Code { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public bool Selected { get; set; }
    public string FullName => $"{FirstName} {LastName}".Trim();
}

public class RoomTaskRow
{
    public int Id { get; set; }
    public string Room { get; set; } = "";
    public int Credit { get; set; }
}

public class TurndownRow
{
    public int Id { get; set; }
    public string Room { get; set; } = "";
    public string RoomType { get; set; } = "";
    public string HouseKeepingStatus { get; set; } = "";
    public string Name { get; set; } = "";
    public string ResStatus { get; set; } = "";
    public string TurndownStatus { get; set; } = "";
}

public class DiscrepancyRow
{
    public int Id { get; set; }
    public string RoomNumber { get; set; } = "";
    public string RoomType { get; set; } = "";
    public string RoomStatus { get; set; } = "";
    public string HouseKeepingStatus { get; set; } = "";
    public string FoStatus { get; set; } = "";
    public string ResStatus { get; set; } = "";
    public int FoPerson { get; set; }
    public int HkPerson { get; set; }
    public string Discrepancy { get; set; } = "";
}

public class RoomStatusRow
{
    public int Id { get; set; }
    public int Sn { get; set; }
    public string Room { get; set; } = "";
    public string RoomType { get; set; } = "";
    public string HouseKeepingStatus { get; set; } = "";
    public string FoStatus { get; set; } = "";
    public string ResStatus { get; set; } = "";
    public string Floor { get; set; } = "";
}
