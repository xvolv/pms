namespace ERP.V7.WebPMS.Components.Pages.NightAudit.Models;

public class NightAuditState
{
    public DateTime BusinessDate { get; set; } = DateTime.Today;

    public List<NightAuditRegistration> OverdueOut { get; set; } = new();
    public List<NightAuditRegistration> DueOut { get; set; } = new();
    public List<NightAuditRegistration> WaitingList { get; set; } = new();
    public List<NightAuditRegistration> SixPmArrivals { get; set; } = new();
    public List<NightAuditRegistration> GuaranteedArrivals { get; set; } = new();
    public List<RoomDiscrepancyRow> RoomDiscrepancies { get; set; } = new();
    public List<HeldBillRow> HeldBills { get; set; } = new();
    public List<BucketCheckRow> BucketChecks { get; set; } = new();
    public bool BucketCheckDone { get; set; }
    public List<RoomTaxPostRow> RoomTaxPosts { get; set; } = new();
    public bool RoomTaxPosted { get; set; }
    public bool TransactionsSummarized { get; set; }
    public List<FnbOutletSummary> FnbOutlets { get; set; } = new();
    public bool FnbAuditDone { get; set; }
    public List<RevenueJournalLine> RevenueJournal { get; set; } = new();
    public bool RevenueJournalized { get; set; }
    public List<ReportArchiveRow> Reports { get; set; } = new();
    public bool ReportArchived { get; set; }
    public bool ArchiveInProgress { get; set; }
    public int ArchiveProgress { get; set; }

    public List<string> CancellationReasons { get; } = new()
    {
        "Guest No Longer Coming",
        "Duplicate Reservation",
        "Room Not Available",
        "Guest Request",
        "Booked in Error",
        "Other",
    };

    public static NightAuditState CreateSample()
    {
        var today = DateTime.Today;
        int id = 0;
        int NextId() => ++id;

        var state = new NightAuditState { BusinessDate = today };

        state.OverdueOut = new List<NightAuditRegistration>
        {
            new() { Id = NextId(), RegNo = "REG-10021", Guest = "Abebe Kebede", Company = "Ethio Trading PLC", Room = "204",
                RoomType = "Standard", ArrivalDate = today.AddDays(-4), DepartureDate = today.AddDays(-1), Adults = 1,
                Children = 0, Rtc = "RTC01", RateCode = "CORP-001", Amount = 1800m, IsFixedRate = true, PaymentType = "Cash",
                TotalBill = 7200m, Paid = 5200m, Agent = "Direct", Source = "Walk-In" },
            new() { Id = NextId(), RegNo = "REG-10034", Guest = "Liya Tesfaye", Company = "", Room = "311",
                RoomType = "Deluxe", ArrivalDate = today.AddDays(-6), DepartureDate = today.AddDays(-2), Adults = 2,
                Children = 1, Rtc = "RTC02", RateCode = "RACK-007", Amount = 2600m, IsFixedRate = false, PaymentType = "Credit Card",
                TotalBill = 10400m, Paid = 10400m, Agent = "Direct", Source = "OTA" },
        };

        state.DueOut = new List<NightAuditRegistration>
        {
            new() { Id = NextId(), RegNo = "REG-10041", Guest = "Samuel Girma", Company = "Sunrise Tours", Room = "108",
                RoomType = "Standard", ArrivalDate = today.AddDays(-2), DepartureDate = today, Adults = 1, Children = 0,
                Rtc = "RTC01", RateCode = "AGENT-006", Amount = 1900m, IsFixedRate = false, PaymentType = "City Ledger",
                TotalBill = 3800m, Paid = 2000m, Agent = "Sunrise Tours", Source = "Agent" },
            new() { Id = NextId(), RegNo = "REG-10052", Guest = "Marta Alemu", Company = "", Room = "215",
                RoomType = "Deluxe", ArrivalDate = today.AddDays(-1), DepartureDate = today, Adults = 2, Children = 0,
                Rtc = "RTC02", RateCode = "RACK-007", Amount = 2600m, IsFixedRate = true, PaymentType = "Cash",
                TotalBill = 2600m, Paid = 2600m, Agent = "Direct", Source = "Walk-In" },
            new() { Id = NextId(), RegNo = "REG-10058", Guest = "Yonas Bekele", Company = "Nile Exports", Room = "402",
                RoomType = "Suite", ArrivalDate = today.AddDays(-3), DepartureDate = today, Adults = 1, Children = 0,
                Rtc = "RTC03", RateCode = "CORP-002", Amount = 4200m, IsFixedRate = false, PaymentType = "Credit Card",
                TotalBill = 12600m, Paid = 8400m, Agent = "Direct", Source = "Corporate" },
        };

        state.WaitingList = new List<NightAuditRegistration>
        {
            new() { Id = NextId(), RegNo = "REG-10063", Guest = "Hana Wolde", Company = "", Room = "-",
                RoomType = "Standard", ArrivalDate = today, DepartureDate = today.AddDays(2), Adults = 1, Children = 0,
                Rtc = "RTC01", RateCode = "RACK-007", Amount = 1900m, PaymentType = "Cash", Agent = "Direct", Source = "Phone" },
        };

        state.SixPmArrivals = new List<NightAuditRegistration>
        {
            new() { Id = NextId(), RegNo = "REG-10071", Guest = "Dawit Mulugeta", Company = "", Room = "112",
                RoomType = "Standard", ArrivalDate = today, DepartureDate = today.AddDays(1), Adults = 1, Children = 0,
                Rtc = "RTC01", RateCode = "RACK-007", Amount = 1900m, PaymentType = "Cash", Agent = "Direct", Source = "Walk-In" },
        };

        state.GuaranteedArrivals = new List<NightAuditRegistration>
        {
            new() { Id = NextId(), RegNo = "REG-10079", Guest = "Selam Fikru", Company = "Blue Nile Logistics", Room = "218",
                RoomType = "Deluxe", ArrivalDate = today, DepartureDate = today.AddDays(3), Adults = 1, Children = 0,
                Rtc = "RTC02", RateCode = "CORP-001", Amount = 2600m, PaymentType = "Credit Card", Agent = "Direct",
                Source = "Corporate" },
            new() { Id = NextId(), RegNo = "REG-10082", Guest = "Kalkidan Assefa", Company = "", Room = "309",
                RoomType = "Suite", ArrivalDate = today, DepartureDate = today.AddDays(1), Adults = 2, Children = 0,
                Rtc = "RTC03", RateCode = "RACK-007", Amount = 4200m, PaymentType = "Cash", Agent = "Direct", Source = "OTA" },
        };

        state.RoomDiscrepancies = new List<RoomDiscrepancyRow>
        {
            new() { Id = NextId(), Room = "306", SystemStatus = "Occupied", HousekeepingStatus = "Vacant Dirty",
                ReportedDate = today, Remark = "Guest checked out early, HK not updated by front desk." },
            new() { Id = NextId(), Room = "410", SystemStatus = "Vacant Clean", HousekeepingStatus = "Occupied",
                ReportedDate = today, Remark = "Walk-in assigned without system update." },
        };

        state.HeldBills = new List<HeldBillRow>
        {
            new() { Id = NextId(), RegNo = "REG-10041", Guest = "Samuel Girma", Room = "108", BillNo = "BILL-5581",
                Amount = 1800m, HeldDate = today.AddDays(-1), HeldBy = "F. Desta", Reason = "Awaiting company approval" },
        };

        state.BucketChecks = state.DueOut.Concat(state.GuaranteedArrivals)
            .Select(r => new BucketCheckRow
            {
                Id = NextId(),
                RegNo = r.RegNo,
                Guest = r.Guest,
                Room = r.Room,
                RoomType = r.RoomType,
                Departure = r.DepartureDate,
                Adults = r.Adults,
                RateCode = r.RateCode,
            }).ToList();

        var inHouse = state.DueOut.Concat(state.GuaranteedArrivals).ToList();
        state.RoomTaxPosts = inHouse.Select(r => new RoomTaxPostRow
        {
            Id = NextId(),
            RegNo = r.RegNo,
            Guest = r.Guest,
            Room = r.Room,
            RoomCharge = r.Amount,
            Tax = Math.Round(r.Amount * 0.15m, 2),
            Packages = r.RegNo == "REG-10058"
                ? new List<PackagePostLine> { new() { Description = "Breakfast Package", Amount = 350m } }
                : new List<PackagePostLine>(),
        }).ToList();

        state.FnbOutlets = new List<FnbOutletSummary>
        {
            new() { Outlet = "Main Restaurant", Covers = 64, Revenue = 18200m },
            new() { Outlet = "Lobby Bar", Covers = 22, Revenue = 6400m },
            new() { Outlet = "Room Service", Covers = 11, Revenue = 3100m },
        };

        state.RevenueJournal = new List<RevenueJournalLine>
        {
            new() { Account = "4000 - Room Revenue", Description = "Room charges for business date", Debit = 0, Credit = 12600m },
            new() { Account = "4100 - F&B Revenue", Description = "Food & beverage revenue", Debit = 0, Credit = 27700m },
            new() { Account = "2100 - Guest Ledger", Description = "Guest ledger control", Debit = 40300m, Credit = 0 },
        };

        state.Reports = new List<ReportArchiveRow>
        {
            new() { Id = NextId(), ReportName = "Daily Revenue Report", Description = "Summary of all revenue posted for the business date." },
            new() { Id = NextId(), ReportName = "Manager's Flash Report", Description = "Occupancy, ADR and RevPAR summary." },
            new() { Id = NextId(), ReportName = "Guest Ledger Summary", Description = "Outstanding balances for in-house guests." },
            new() { Id = NextId(), ReportName = "City Ledger Summary", Description = "Outstanding balances for company/agent accounts." },
            new() { Id = NextId(), ReportName = "Night Audit Log", Description = "Full log of actions performed during this audit." },
        };

        return state;
    }
}
