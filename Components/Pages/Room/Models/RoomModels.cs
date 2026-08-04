using System.ComponentModel.DataAnnotations;

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

public class RoomTileRow : IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Room Number is required.")]
    public string Number { get; set; } = "";

    [Required(ErrorMessage = "Room Type is required.")]
    public string TypeCode { get; set; } = "";
    public string TypeDescription { get; set; } = "";
    public string Status { get; set; } = "Clean";

    // Room Detail
    public string RoomCode { get; set; } = "";

    [Range(0, 50, ErrorMessage = "Max Occupancy must be between 0 and 50.")]
    public int? MaxOccupancy { get; set; }
    public bool IsActive { get; set; } = true;
    public string PhoneNo { get; set; } = "";
    public string Measurement { get; set; } = "";
    public string Remark { get; set; } = "";

    // Space Capacity
    public string SpaceArrangement { get; set; } = "";

    [Range(0, 500, ErrorMessage = "Max Capacity must be between 0 and 500.")]
    public int? MaxCapacity { get; set; }
    public string SpaceRemark { get; set; } = "";

    // HK-Credits
    public decimal StayoverCredit { get; set; }
    public decimal DepartureCredit { get; set; }
    public decimal TurndownCredit { get; set; }
    public decimal PickupCredit { get; set; }
    public decimal VacantCredit { get; set; }
    public decimal EveningSectionCredit { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (MaxOccupancy.HasValue && MaxCapacity.HasValue && MaxOccupancy > MaxCapacity)
        {
            yield return new ValidationResult(
                "Max Occupancy cannot exceed the Max Capacity set on Space Capacity.",
                [nameof(MaxOccupancy)]);
        }
    }
}

public class BlockDraft
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Building Code is required.")]
    public string Code { get; set; } = "";

    [Required(ErrorMessage = "Building Name is required.")]
    public string Name { get; set; } = "";

    [Range(1, 200, ErrorMessage = "No of Floors must be between 1 and 200.")]
    public int NoOfFloors { get; set; } = 1;

    [Range(0, 999, ErrorMessage = "Floor Starts From must be 0 or greater.")]
    public int FloorStartsFrom { get; set; } = 1;

    [Range(1, 6, ErrorMessage = "Room No Digit must be between 1 and 6.")]
    public int RoomNoDigit { get; set; } = 3;

    [Range(0, 9999, ErrorMessage = "Room No Starts From must be 0 or greater.")]
    public int RoomNoStartsFrom { get; set; } = 1;

    [Range(1, 999, ErrorMessage = "Rooms on Each Floor must be at least 1.")]
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
