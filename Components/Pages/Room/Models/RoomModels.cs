namespace ERP.V7.WebPMS.Components.Pages.Room;

public class BlockRow
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public bool IsExpanded { get; set; }
    public List<FloorRow> Floors { get; set; } = new();
}

public class FloorRow
{
    public int Id { get; set; }
    public int Number { get; set; }
    public List<RoomTileRow> Rooms { get; set; } = new();
}

public class RoomTileRow
{
    public int Id { get; set; }
    public string Number { get; set; } = "";
    public string TypeCode { get; set; } = "";
    public string TypeDescription { get; set; } = "";
    public string Status { get; set; } = "Clean";

    // Room Detail
    public string RoomCode { get; set; } = "";
    public int? MaxOccupancy { get; set; }
    public bool IsActive { get; set; } = true;
    public string PhoneNo { get; set; } = "";
    public string Measurement { get; set; } = "";
    public string Remark { get; set; } = "";

    // Space Capacity
    public string SpaceArrangement { get; set; } = "";
    public int? MaxCapacity { get; set; }
    public string SpaceRemark { get; set; } = "";

    // HK-Credits
    public decimal StayoverCredit { get; set; }
    public decimal DepartureCredit { get; set; }
    public decimal TurndownCredit { get; set; }
    public decimal PickupCredit { get; set; }
    public decimal VacantCredit { get; set; }
    public decimal EveningSectionCredit { get; set; }
}

public class BlockDraft
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public int NoOfFloors { get; set; } = 1;
    public int FloorStartsFrom { get; set; } = 1;
    public int RoomNoDigit { get; set; } = 3;
    public int RoomNoStartsFrom { get; set; } = 1;
    public int RoomsPerFloor { get; set; } = 10;
    public string Remarks { get; set; } = "";
}

public static class RoomNumbering
{
    public static string Generate(int floorNumber, int digit, int sequence)
    {
        var floorText = floorNumber.ToString();
        var sequenceWidth = Math.Max(digit - floorText.Length, 1);
        return floorText + sequence.ToString().PadLeft(sequenceWidth, '0');
    }
}
