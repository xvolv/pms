namespace ERP.V7.WebPMS.Components.Pages.DensityChart.Models;

public class DensityReservation
{
    public string RoomNumber { get; set; } = "";
    public string GuestName { get; set; } = "";
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string? Reminder { get; set; }

    public int Nights => Math.Max(1, (End.Date - Start.Date).Days);

    public bool Occupies(DateTime day) => day.Date >= Start.Date && day.Date < Start.Date.AddDays(Nights);
}

public record DensityRowSegment(int StartDayIndex, int Span, DensityReservation? Reservation);
