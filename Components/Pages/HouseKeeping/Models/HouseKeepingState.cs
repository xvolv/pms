namespace ERP.V7.WebPMS.Components.Pages.HouseKeeping.Models;

public class HouseKeepingState
{
    public List<AttendantRow> Attendants { get; set; } = new();
    public List<TaskAssignmentRow> TaskAssignments { get; set; } = new();
    public List<RoomTaskRow> DemoRooms { get; set; } = new();
    public List<TurndownRow> Turndowns { get; set; } = new();
    public List<DiscrepancyRow> Discrepancies { get; set; } = new();
    public List<RoomStatusRow> RoomStatuses { get; set; } = new();

    public List<string> RoomList { get; } = new()
    {
        "101", "102", "103", "301", "302", "303", "304", "201", "202", "203",
        "204", "205", "206", "207", "208", "209", "210", "211", "212", "164A",
    };

    public List<string> RoomTypes { get; } = new() { "Standard Room", "Executive" };

    public List<string> Floors { get; } = new() { "Abay Block", "Floor - 1", "Floor - 3" };

    public List<string> HkStatuses { get; } = new()
    {
        "Dirty", "Clean", "Inspected", "Pickup", "Out Of Order", "Out Of Service",
    };

    public List<string> FoStatuses { get; } = new() { "Occupied", "Vacant" };

    public List<string> ResStatuses { get; } = new()
    {
        "Arrival", "Arrived", "Stay Over", "Day Use", "Due Out", "Departed", "Not Reserved",
    };

    public List<string> TurndownStatuses { get; } = new() { "Required", "Not Required", "Completed" };

    public List<string> PersonOptions { get; } = new() { "1", "2", "3", "4", "5" };

    public List<string> Months { get; } = new()
    {
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December",
    };
    public List<string> Hotels { get; } = new()
    {
        "Test Hotel ", "Hotel B", "Hotel C", "Hotel D", "Hotel E",
    };

    private static int _nextId;
    private static int NextId() => ++_nextId;

    /// <summary>Splits rooms into contiguous, non-overlapping groups, one per attendant, spreading any remainder across the first groups.</summary>
    public static List<List<RoomTaskRow>> DivideRooms(List<RoomTaskRow> rooms, int attendantCount)
    {
        if (attendantCount <= 0 || rooms.Count == 0)
            return new List<List<RoomTaskRow>>();

        var groups = new List<List<RoomTaskRow>>();
        var baseCount = rooms.Count / attendantCount;
        var remainder = rooms.Count % attendantCount;
        var index = 0;
        for (var i = 0; i < attendantCount; i++)
        {
            var take = baseCount + (i < remainder ? 1 : 0);
            groups.Add(rooms.Skip(index).Take(take).ToList());
            index += take;
        }
        return groups;
    }

    public static List<AttendantRow> CreateAttendantsSample()
    {
        return new List<AttendantRow>
        {
            new() { Code = "EMP-00001", FirstName = "RRRR", LastName = "" },
            new() { Code = "EMP-00005", FirstName = "BAYE", LastName = "DESSIE" },
            new() { Code = "EMP-00017", FirstName = "ADDIS", LastName = "ALEMU" },
        };
    }

    public static List<TaskAssignmentRow> CreateTaskAssignmentsSample(List<RoomTaskRow> demoRooms)
    {
        var sample1Rooms = demoRooms.Select(r => new RoomTaskRow { Id = r.Id, Room = r.Room, Credit = r.Credit }).ToList();
        var sample2Rooms = demoRooms.Select(r => new RoomTaskRow { Id = r.Id, Room = r.Room, Credit = r.Credit }).ToList();

        var assignment1 = new TaskAssignmentRow
        {
            Id = NextId(),
            TaskDate = new DateTime(2017, 8, 19),
            Auto = true,
            TotalSheets = 1,
            Details = new()
            {
                new() { AttendantCode = "EMP-00005", AttendantName = "BAYE DESSIE", TotalRooms = sample1Rooms.Count, TotalCredit = sample1Rooms.Sum(r => r.Credit), Rooms = sample1Rooms },
            },
        };
        assignment1.TotalCredits = assignment1.Details.Sum(d => d.TotalCredit);

        var assignment2 = new TaskAssignmentRow
        {
            Id = NextId(),
            TaskDate = new DateTime(2017, 8, 26),
            Auto = true,
            TotalSheets = 1,
            Details = new()
            {
                new() { AttendantCode = "EMP-00017", AttendantName = "ADDIS TESFAYE ALEMU", TotalRooms = sample2Rooms.Count, TotalCredit = sample2Rooms.Sum(r => r.Credit), Rooms = sample2Rooms },
            },
        };
        assignment2.TotalCredits = assignment2.Details.Sum(d => d.TotalCredit);

        return new List<TaskAssignmentRow> { assignment1, assignment2 };
    }

    public static List<RoomTaskRow> CreateDemoRoomsSample()
    {
        var rooms = new[]
        {
            "201", "202", "203", "204", "205", "206", "207", "208", "209",
            "210", "211", "212", "164A", "102", "103", "104", "105", "106",
        };

        return rooms.Select(r => new RoomTaskRow { Id = NextId(), Room = r, Credit = 0 }).ToList();
    }

    public static List<TurndownRow> CreateTurndownSample()
    {
        return new List<TurndownRow>
        {
            new() { Id = NextId(), Room = "101", RoomType = "Standard Room", HouseKeepingStatus = "Dirty", Name = "John Smith", ResStatus = "Arrived", TurndownStatus = "Required" },
            new() { Id = NextId(), Room = "102", RoomType = "Executive", HouseKeepingStatus = "Clean", Name = "Jane Doe", ResStatus = "Stay Over", TurndownStatus = "Completed" },
            new() { Id = NextId(), Room = "103", RoomType = "Standard Room", HouseKeepingStatus = "Inspected", Name = "Robert Brown", ResStatus = "Arrival", TurndownStatus = "Not Required" },
            new() { Id = NextId(), Room = "201", RoomType = "Standard Room", HouseKeepingStatus = "Dirty", Name = "Alice Johnson", ResStatus = "Stay Over", TurndownStatus = "Required" },
            new() { Id = NextId(), Room = "202", RoomType = "Executive", HouseKeepingStatus = "Clean", Name = "Michael White", ResStatus = "Arrived", TurndownStatus = "Completed" },
            new() { Id = NextId(), Room = "301", RoomType = "Standard Room", HouseKeepingStatus = "Pickup", Name = "Sarah Connor", ResStatus = "Due Out", TurndownStatus = "Required" },
        };
    }

    public static List<DiscrepancyRow> CreateDiscrepancySample()
    {
        return new List<DiscrepancyRow>
        {
            new() { Id = NextId(), RoomNumber = "201", RoomType = "Standard Room", RoomStatus = "Dirty", HouseKeepingStatus = "Occupied", FoStatus = "Occupied", ResStatus = "Stay Over", FoPerson = 2, HkPerson = 2, Discrepancy = "" },
            new() { Id = NextId(), RoomNumber = "305", RoomType = "Executive", RoomStatus = "Clean", HouseKeepingStatus = "Vacant", FoStatus = "Occupied", ResStatus = "Due Out", FoPerson = 1, HkPerson = 0, Discrepancy = "Skip" },
            new() { Id = NextId(), RoomNumber = "104", RoomType = "Standard Room", RoomStatus = "Dirty", HouseKeepingStatus = "Occupied", FoStatus = "Vacant", ResStatus = "Stay Over", FoPerson = 2, HkPerson = 3, Discrepancy = "Sleep/Person" },
            new() { Id = NextId(), RoomNumber = "302", RoomType = "Executive", RoomStatus = "Clean", HouseKeepingStatus = "Vacant", FoStatus = "Occupied", ResStatus = "Arrived", FoPerson = 1, HkPerson = 1, Discrepancy = "Skip" },
            new() { Id = NextId(), RoomNumber = "205", RoomType = "Standard Room", RoomStatus = "Inspected", HouseKeepingStatus = "Occupied", FoStatus = "Vacant", ResStatus = "Stay Over", FoPerson = 2, HkPerson = 2, Discrepancy = "Sleep" },
        };
    }

    public static List<RoomStatusRow> CreateRoomStatusSample()
    {
        var rooms = new[]
        {
            ("103", "Abay Block", "Clean"),
            ("101", "Floor - 1", "Clean"),
            ("102", "Floor - 1", "Clean"),
            ("301", "Floor - 3", "Dirty"),
            ("302", "Floor - 3", "Dirty"),
            ("303", "Floor - 3", "Dirty"),
            ("304", "Floor - 3", "Clean"),
        };

        return rooms.Select((r, index) => new RoomStatusRow
        {
            Id = NextId(),
            Sn = index + 1,
            Room = r.Item1,
            RoomType = "Standard Room",
            HouseKeepingStatus = r.Item3,
            FoStatus = "Vacant",
            ResStatus = "Not Reserved",
            Floor = r.Item2,
        }).ToList();
    }

    public static HouseKeepingState CreateSample()
    {
        var attendants = CreateAttendantsSample();
        var demoRooms = CreateDemoRoomsSample();

        return new HouseKeepingState
        {
            Attendants = attendants,
            TaskAssignments = CreateTaskAssignmentsSample(demoRooms),
            DemoRooms = demoRooms,
            Turndowns = CreateTurndownSample(),
            Discrepancies = CreateDiscrepancySample(),
            RoomStatuses = CreateRoomStatusSample(),
        };
    }
}
