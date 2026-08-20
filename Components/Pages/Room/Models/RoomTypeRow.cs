using System.ComponentModel.DataAnnotations;

namespace ERP.V7.WebPMS.Components.Pages.Room;

public class RoomTypeRow : IValidatableObject
{
    public int Id { get; set; }
    public int Sn { get; set; }

    [Required(ErrorMessage = "Room Type Code is required.")]
    public string Code { get; set; } = "";

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = "";

    [Range(0, int.MaxValue, ErrorMessage = "No of Rooms cannot be negative.")]
    public int NoOfRooms { get; set; }

    public bool Status { get; set; }

    [Required(ErrorMessage = "Activation Date is required.")]
    public DateTime? ActivationDate { get; set; }

    public string ComponentRoom { get; set; } = "";

    public string Hotel { get; set; } = "";

    public string RoomDescription { get; set; } = "";

    [Required(ErrorMessage = "Room Class is required.")]
    public string RoomClass { get; set; } = "Non-VIP";

    [Range(1, 20, ErrorMessage = "Default Occupancy must be between 1 and 20.")]
    public int DefaultOccupancy { get; set; } = 1;

    [Range(1, 20, ErrorMessage = "Maximum Occupancy must be between 1 and 20.")]
    public int MaximumOccupancy { get; set; } = 1;

    [Range(0, 20, ErrorMessage = "Maximum Adult must be between 0 and 20.")]
    public int MaximumAdult { get; set; }

    [Range(0, 20, ErrorMessage = "Maximum Childs must be between 0 and 20.")]
    public int MaximumChilds { get; set; }

    public bool IsHouseKeeping { get; set; }
    public bool IsPseudoRoom { get; set; }
    public bool CanBeMeetingRoom { get; set; }
    public bool AutoRoomAssign { get; set; }

    public decimal StayoverCredit { get; set; }
    public decimal DepartureCredit { get; set; }
    public decimal TurndownCredit { get; set; }
    public decimal PickupCredit { get; set; }
    public decimal VacantCredit { get; set; }
    public decimal EveningSectionCredit { get; set; }

    public HashSet<string> SelectedAmenities { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public Dictionary<string, string> AmenityDescriptions { get; set; } = new(StringComparer.OrdinalIgnoreCase);

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (MaximumOccupancy < DefaultOccupancy)
        {
            yield return new ValidationResult(
                "Maximum Occupancy cannot be less than Default Occupancy.",
                [nameof(MaximumOccupancy)]);
        }

        if (MaximumOccupancy > MaximumAdult + MaximumChilds)
        {
            yield return new ValidationResult(
                "Maximum Occupancy cannot exceed Maximum Adult + Maximum Childs.",
                [nameof(MaximumOccupancy)]);
        }

        if (!string.IsNullOrWhiteSpace(ComponentRoom) && !string.IsNullOrWhiteSpace(Code)
            && string.Equals(ComponentRoom, Code, StringComparison.OrdinalIgnoreCase))
        {
            yield return new ValidationResult(
                "A room type cannot be its own component room.",
                [nameof(ComponentRoom)]);
        }
    }
}
