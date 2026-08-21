using ERP.V7.WebPMS.Components.Pages.Registration.CheckIn;

namespace ERP.V7.WebPMS.Services;

public class FolioService
{
    public bool IsVisible { get; private set; }
    public RegistrationRow? TargetRegistration { get; private set; }
    public string GuestName { get; private set; } = "";
    public string RegNo { get; private set; } = "";
    public string Company { get; private set; } = "";
    public DateTime? Arrival { get; private set; }
    public DateTime? Departure { get; private set; }
    public string? Window { get; private set; }
    public string FsNum { get; private set; } = "00004045, 00004046";
    public string Tin { get; private set; } = "";
    public List<TransferChargeRow> RoomCharges { get; private set; } = new();
    public List<ExtraBillRow> ExtraBills { get; private set; } = new();
    public List<PaymentHistoryRow> Payments { get; private set; } = new();
    public Func<Task>? OnRefreshCallback { get; private set; }

    public event Action? OnChange;

    public void Open(
        RegistrationRow? targetRegistration = null,
        string? guestName = null,
        string? regNo = null,
        string? company = null,
        DateTime? arrival = null,
        DateTime? departure = null,
        string? window = null,
        string? fsNum = null,
        string? tin = null,
        List<TransferChargeRow>? roomCharges = null,
        List<ExtraBillRow>? extraBills = null,
        List<PaymentHistoryRow>? payments = null,
        Func<Task>? onRefresh = null)
    {
        TargetRegistration = targetRegistration;
        GuestName = guestName ?? targetRegistration?.Guest ?? "";
        RegNo = regNo ?? targetRegistration?.Registration ?? "";
        Company = company ?? targetRegistration?.Company ?? "";
        Arrival = arrival ?? targetRegistration?.Arrival;
        Departure = departure ?? targetRegistration?.Departure;
        Window = window;
        if (fsNum != null) FsNum = fsNum;
        if (tin != null) Tin = tin;
        RoomCharges = roomCharges ?? new List<TransferChargeRow>();
        ExtraBills = extraBills ?? new List<ExtraBillRow>();
        Payments = payments ?? new List<PaymentHistoryRow>();
        OnRefreshCallback = onRefresh;

        IsVisible = true;
        NotifyStateChanged();
    }

    public void Close()
    {
        IsVisible = false;
        NotifyStateChanged();
    }

    public async Task RefreshAsync()
    {
        if (OnRefreshCallback != null)
        {
            await OnRefreshCallback.Invoke();
        }
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
