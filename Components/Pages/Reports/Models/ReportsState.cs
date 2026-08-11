namespace ERP.V7.WebPMS.Components.Pages.Reports.Models;

public class ReportsState
{
    public DateTime BusinessDate { get; set; } = DateTime.Today;

    public List<ReportDefinition> Catalog { get; set; } = new();
    public List<CheckoutReportRow> CheckoutRows { get; set; } = new();
    public List<DiscrepancyReportRow> DiscrepancyRows { get; set; } = new();
    public List<ArrivalListRow> ArrivalRows { get; set; } = new();

    private static int _nextId;
    private static int NextId() => ++_nextId;

    public static List<ReportDefinition> CreateCatalog()
    {
        var catalog = new List<ReportDefinition>();

        //  Interactive Reports
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Interactive, Name = "Dashboard Report",
            Description = "Single view of hotel basic information, calendar, registration statistics, room occupancy, reservation and housekeeping status charts." });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Interactive, Name = "Room Inventory",
            Description = "Interactive view of room availability across the property." });

        // Night Audit Reports
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Trial Balance",
            Description = "All transactions posted, broken down by each of the five ledgers (Guest, AR, Deposit, Package, Inter-hotel).", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Rate Adjustment Report",
            Description = "Rate adjustments made on the given business date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Daily Resident Summary",
            Description = "Guest total balance on the given date after deducting payments.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Cancellation of the Day",
            Description = "List of reservations cancelled on the given date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Cashier Summary",
            Description = "Summary of cashiering activity for the selected date/shift, including cash, checks, card and AR totals.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Check Report of the Day",
            Description = "Checks received and processed on the given business date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Checkout Report",
            Description = "List of guests checked out on the given date, with registration and payment details.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "City Ledger",
            Description = "Non-guest transactions tracked by the back-office accounting department.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Credit Cards of the Day",
            Description = "Credit card transactions processed on the given business date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Daily Business Report",
            Description = "Total transactions made on the given date, with month and year-to-date totals compared to the prior year.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Deposit Ledger",
            Description = "Guest deposit balances held by the hotel.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "No Show Report",
            Description = "Reservations that did not arrive by the day-closing time of the given date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Package Report",
            Description = "Package transactions along with registration details for the given date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Rate Check Report",
            Description = "Rate amount variations on the given business date and where the difference occurs.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Daily Sales Summary",
            Description = "Summary of sales activity for the given business date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Cash Dropped Report",
            Description = "Cash drop amounts recorded for the given business date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Room Income Report",
            Description = "Income collected or expected to be collected on the given date or date range.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.NightAudit, Name = "Managerial Flash",
            Description = "The most comprehensive report: overall hotel rooms and room sales status compared with the previous month and year.", IsImplemented = true });

        //  Housekeeping Reports
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Housekeeping, Name = "Discrepancy Report",
            Description = "Discrepancies between front office and housekeeping room status recordings.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Housekeeping, Name = "HK Activity Report",
            Description = "Log of room status changes made on the given date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Housekeeping, Name = "HK Attendants Report",
            Description = "Housekeeping attendant activity summary.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Housekeeping, Name = "Status Report",
            Description = "Detailed status of all rooms within the hotel on the given date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Housekeeping, Name = "Task Assignment Report",
            Description = "Task assignment summary information for the given date.", IsImplemented = true });

        //  Transaction Reports (all share Daily/Weekly/Monthly/At the day of/Annually/Date Range/Show all criteria)
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Transaction, Name = "Cash Receipt Report",
            Description = "Cash receipt transactions made within the given date range or on the given date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Transaction, Name = "Paid Out Report",
            Description = "Cash paid-out transactions (expenses made on behalf of a guest and later charged to their account).", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Transaction, Name = "Rebate Report",
            Description = "Rebate transactions - amounts refunded or reduced from what has already been paid.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Transaction, Name = "Credit Sales Report",
            Description = "Credit sales transactions made within the given date range or on the given date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Transaction, Name = "Cash Sales Report",
            Description = "Cash sales transactions made within the given date range or on the given date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Transaction, Name = "Debit Note Report",
            Description = "Debit note transactions made within the given date range or on the given date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Transaction, Name = "Refund Report",
            Description = "Refunds issued to guests or customers within the given date range or on the given date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Transaction, Name = "Daily Room Charge Report",
            Description = "Daily room charges made within the given date range or on the given date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Transaction, Name = "Room POS Charge Report",
            Description = "POS charges made within the given date range in relation to registered guests.", IsImplemented = true });

        //  Other Reports
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Other, Name = "Arrival List",
            Description = "Guests expected to arrive on the next business date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Other, Name = "Departure List",
            Description = "Guests expected to check out on the next business date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Other, Name = "Detail Daily Sales Transaction",
            Description = "Transaction amount, additional charges, tax and totals from each guest, by cashier.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Other, Name = "Drop Off Report",
            Description = "Guests requesting shuttle service from the hotel at checkout.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Other, Name = "Guest In-House List",
            Description = "List of all current in-house guests.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Other, Name = "Pickup Report",
            Description = "Guests that need shuttle pickup service into the hotel.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Other, Name = "Police Report",
            Description = "In-house guests with name, gender, ID number, arrival and departure dates.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Other, Name = "Postmaster In-House List",
            Description = "In-house guests on the postmaster room type.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Other, Name = "Room Move",
            Description = "Guests moved from one room to another on the given business date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Other, Name = "Arrived List",
            Description = "Guests that arrived on the given business date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Other, Name = "Due Outs",
            Description = "Guests expected to check out on the next business date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Other, Name = "Stayovers",
            Description = "In-house guests who will not be checked out on the next business date.", IsImplemented = true });
        catalog.Add(new() { Id = NextId(), Group = ReportGroup.Other, Name = "Summary Of Summary Report",
            Description = "Room, POS and tax transaction summaries for a given date or date range." });

        return catalog;
    }

    public static List<CheckoutReportRow> CreateCheckoutReportSample(DateTime date)
    {
        return new List<CheckoutReportRow>
        {
            new() { Id = NextId(), RegNo = "REG-10011", Room = "201", RoomCount = 1, RoomType = "Standard",
                Company = "", Guest = "Betelhem Assefa", Adult = 1, Child = 0,
                ArrivalDate = date.AddDays(-2), DepartureDate = date, RateCode = "RACK", PaymentType = "Cash",
                User = "CNET ADMINISTRATOR", ActualRtc = "Front Desk", MarketCode = "Walk-In", RateAmount = 1800m },
            new() { Id = NextId(), RegNo = "REG-10019", Room = "305", RoomCount = 1, RoomType = "Deluxe",
                Company = "Ethio Trading PLC", Guest = "Nahom Tesfaye", Adult = 2, Child = 1,
                ArrivalDate = date.AddDays(-3), DepartureDate = date, RateCode = "CORP", PaymentType = "Credit Card",
                User = "CNET ADMINISTRATOR", ActualRtc = "Front Desk", MarketCode = "Corporate", RateAmount = 2600m },
            new() { Id = NextId(), RegNo = "REG-10027", Room = "112", RoomCount = 1, RoomType = "Standard",
                Company = "", Guest = "Sara Mekonnen", Adult = 1, Child = 0,
                ArrivalDate = date.AddDays(-1), DepartureDate = date, RateCode = "OTA", PaymentType = "City Ledger",
                User = "CNET ADMINISTRATOR", ActualRtc = "Front Desk", MarketCode = "Online Travel Agency", RateAmount = 1900m },
        };
    }

    public static List<CityLedgerRow> CreateCityLedgerSample(DateTime start, DateTime end)
    {
        return new List<CityLedgerRow>
        {
            new() { Id = NextId(), RegNo = "REG-10019", Date = start, Guest = "Nahom Tesfaye",
                Company = "Ethio Trading PLC", SubTotal = 7800m },
            new() { Id = NextId(), RegNo = "REG-10041", Date = start.AddDays(1), Guest = "Blen Girma",
                Company = "Horizon Addis Tours", SubTotal = 4200m },
            new() { Id = NextId(), RegNo = "REG-10052", Date = end, Guest = "Yonas Abera",
                Company = "Zemen Bank S.C.", SubTotal = 5600m },
        };
    }

    private static readonly (string Item, string CurrentDay)[] ManagerialFlashItems =
    {
        ("Total Rooms In Hotel", "67.00"),
        ("Rooms Occupied", "1.00"),
        ("Total Rooms Minus OOO Rooms", "67.00"),
        ("Available Rooms", "66.00"),
        ("Available Rooms Minus OOO Rooms", "66.00"),
        ("Complementary Rooms", "0.00"),
        ("House Use Rooms", "0.00"),
        ("Rooms Occupied Minus Comp and House Use", "1.00"),
        ("Rooms Occupied Minus House Use", "1.00"),
        ("Rooms Occupied Minus Comp", "1.00"),
        ("Day Use Rooms", "67.00"),
        ("Out Of Order Rooms", "0.00"),
        ("Out Of Service Rooms", "0.00"),
        ("In House Adults", "5.00"),
        ("In House Children", "0.00"),
        ("Total In House Persons", "5.00"),
        ("VIP Person In House", "-1.00"),
        ("VIP Rooms In House", "-1.00"),
        ("Source Rooms In House", "0.00"),
        ("Company Rooms In House", "0.00"),
        ("Travel Agent Rooms In House", "0.00"),
        ("Group Rooms In House", "0.00"),
        ("% Rooms Occupied", "1.49"),
        ("% Rooms Occupied Minus Comp and House", "1.49"),
        ("% Rooms Occupied Minus Comp House and OOO", "1.49"),
        ("% Rooms Occupied Minus Comp", "1.49"),
        ("% Rooms Occupied Minus House", "1.49"),
        ("% Rooms Occupied Minus Comp and OOO", "1.49"),
        ("% Rooms Occupied Minus House and OOO", "1.49"),
        ("% Rooms Occupied Minus OOO", "1.49"),
        ("Arrival Rooms", "14.00"),
        ("Arrival Persons", "14.00"),
        ("Walk In Rooms", "-1.00"),
        ("Walk In Persons", "-1.00"),
        ("Extended Stay Rooms", "9.00"),
        ("Extended Stay Persons", "9.00"),
        ("Departure Rooms", "0.00"),
        ("Departure Persons", "0.00"),
        ("Early Departure Rooms", "0.00"),
        ("Early Departure Persons", "0.00"),
        ("No Show Rooms", "1.00"),
        ("No Show Persons", "1.00"),
        ("Cancelled Reservations for Today", "1.00"),
        ("Reservations Made Today", "19.00"),
        ("Reservation Cancellations Made Today", "1.00"),
        ("Room Nights Reserved Today", "109.00"),
        ("Clean Rooms", "0.00"),
        ("Dirty Rooms", "0.00"),
        ("ADR", "38,083.23"),
        ("ADR Minus Comp", "38,083.23"),
        ("ADR minus house", "38,083.23"),
        ("ADR minus comp and house", "38,083.23"),
        ("Average Person Rate", "7,616.65"),
        ("Room Revenue", "38,083.23"),
        ("Food and Beverage Revenue", "0.00"),
        ("Other Revenue", "2,129.33"),
        ("Total Revenue", "40,212.56"),
        ("Total Revenue Per Person", "8,042.51"),
        ("Payments", "32,689.02"),
        ("Arrival Rooms for Tomorrow", "24.00"),
        ("Arrival Persons for Tomorrow", "24.00"),
        ("Departure Rooms for Tomorrow", "11.00"),
        ("Departure Persons for Tomorrow", "11.00"),
        ("% Rooms Occupied for Tomorrow", "20.90"),
        ("% Multiple Occupancy", "400.00"),
        ("% Rooms Occupied for Next 7 Days", "94.03"),
        ("Repeat Guest Rooms Occupied", "-347.00"),
        ("% Rooms Occupied Plus Day Use", "101.49"),
        ("Rooms Occupied Plus Day Use and No Show", "69.00"),
        ("% Rooms Occupied Plus Day Use and No Show", "102.99"),
    };

    public static List<ManagerialFlashItemRow> CreateManagerialFlashItems(DateTime date)
    {
        return ManagerialFlashItems.Select((item, i) => new ManagerialFlashItemRow
        {
            Id = NextId(),
            Sn = i + 1,
            ReportItem = item.Item,
            CurrentYearDay = item.CurrentDay,
        }).ToList();
    }

    public static List<DiscrepancyReportRow> CreateDiscrepancyReportSample(DateTime date)
    {
        return new List<DiscrepancyReportRow>
        {
            new() { Id = NextId(), RoomNo = "306", RoomType = "Standard", RoomStatus = "Vacant Dirty",
                HkStatus = "Occupied", FoStatus = "Vacant", ResStatus = "Checked Out", FoPerson = 0, HkPerson = 2,
                Discrepancy = "Sleep", Date = date },
            new() { Id = NextId(), RoomNo = "410", RoomType = "Deluxe", RoomStatus = "Occupied Clean",
                HkStatus = "Vacant", FoStatus = "Occupied", ResStatus = "Checked In", FoPerson = 2, HkPerson = 0,
                Discrepancy = "Skip", Date = date },
            new() { Id = NextId(), RoomNo = "118", RoomType = "Standard", RoomStatus = "Occupied Clean",
                HkStatus = "Occupied", FoStatus = "Occupied", ResStatus = "Checked In", FoPerson = 2, HkPerson = 1,
                Discrepancy = "Person", Date = date },
            new() { Id = NextId(), RoomNo = "215", RoomType = "Suite", RoomStatus = "Occupied Dirty",
                HkStatus = "Occupied", FoStatus = "Vacant", ResStatus = "Reserved", FoPerson = 0, HkPerson = 3,
                Discrepancy = "Sleep/Person", Date = date },
        };
    }

    public static List<HkActivityRow> CreateHkActivitySample(DateTime date)
    {
        return new List<HkActivityRow>
        {
            new() { Id = NextId(), Activity = "Dirty", RoomNumber = "306", Date = date, User = "T. Bekele", DeviceName = "HK Tablet 1" },
            new() { Id = NextId(), Activity = "Clean", RoomNumber = "410", Date = date, User = "S. Wolde", DeviceName = "HK Tablet 2" },
            new() { Id = NextId(), Activity = "Out of Order", RoomNumber = "118", Date = date, User = "M. Girma", DeviceName = "Front Desk PC" },
        };
    }

    public static ReportSection CreateStatusReportSection(DateTime date)
    {
        return new ReportSection
        {
            Title = "",
            Columns = new[] { "Total Rooms", "Clean Rooms", "Dirty Rooms", "Pickup Rooms", "Occ Rooms", "Occ+ Rooms", "Inspected Rooms", "Vacant Rooms", "Occupied Rooms" },
            RightAlign = new[] { true, true, true, true, true, true, true, true, true },
            Rows = new List<string[]>
            {
                new[] { "91", "53", "30", "8", "1", "2", "45", "90", "1" },
            },
        };
    }

    public static List<TaskAssignmentRow> CreateTaskAssignmentSample(DateTime date)
    {
        return new List<TaskAssignmentRow>
        {
            new() { Id = NextId(), TaskDate = date, Task = "Checkout Clean", InAuto = "Yes", TotalSheets = 12, TotalCredits = 12 },
            new() { Id = NextId(), TaskDate = date, Task = "Turndown", InAuto = "No", TotalSheets = 8, TotalCredits = 8 },
            new() { Id = NextId(), TaskDate = date, Task = "Stay-over Clean", InAuto = "Yes", TotalSheets = 15, TotalCredits = 15 },
        };
    }

    public static List<ArrivalListRow> CreateArrivalListSample(DateTime date)
    {
        var nextDay = date.AddDays(1);
        return new List<ArrivalListRow>
        {
            new() { Id = NextId(), Sn = 1, RegNo = "RES-20031", Guest = "Yared Alemayehu", Company = "", Room = "204",
                RoomType = "Standard", ArrivalDate = nextDay, DepartureDate = nextDay.AddDays(2), Adults = 1, Children = 0,
                Agent = "Direct" },
            new() { Id = NextId(), Sn = 2, RegNo = "RES-20044", Guest = "Meron Haile", Company = "Blue Nile Logistics", Room = "312",
                RoomType = "Deluxe", ArrivalDate = nextDay, DepartureDate = nextDay.AddDays(3), Adults = 2, Children = 1,
                Agent = "Corporate" },
            new() { Id = NextId(), Sn = 3, RegNo = "RES-20051", Guest = "Robel Getachew", Company = "", Room = "101",
                RoomType = "Standard", ArrivalDate = nextDay, DepartureDate = nextDay.AddDays(1), Adults = 1, Children = 0,
                Agent = "OTA" },
        };
    }

    private static readonly Dictionary<string, (string VoucherPrefix, string[] Descriptions, decimal MinAmount, decimal MaxAmount)> TransactionReportProfiles = new()
    {
        ["Detail Daily Sales Transaction"] = ("DS", new[] { "Room charge + tax", "F&B charge + tax", "Laundry charge + tax" }, 400m, 5500m),
        ["Rate Adjustment Report"] = ("RA", new[] { "Rate adjusted - loyalty discount", "Rate adjusted - manager override", "Rate adjusted - long stay discount" }, 100m, 1500m),
        ["Check Report of the Day"] = ("CK", new[] { "Check received - folio settlement", "Check received - advance deposit" }, 500m, 6000m),
        ["Credit Cards of the Day"] = ("CC", new[] { "Visa settlement", "Mastercard settlement", "Amex settlement" }, 800m, 9000m),
        ["Deposit Ledger"] = ("DL", new[] { "Deposit held - advance reservation", "Deposit held - group booking" }, 1000m, 8000m),
    };

    public static List<CashReceiptTransactionRow> CreateCashReceiptSample(DateTime date)
    {
        return new List<CashReceiptTransactionRow>
        {
            new() { Id = NextId(), VoucherId = "CRV-56575", RegNo = "WREG-00577-17", CustomerName = "AYALEW H/WOT",
                IssuedDate = date, RoomNo = "303", Note = "Payment for WREG-00577-17 Room = 303", OtherReference = "",
                GrandTotal = 500.00m, LastOperator = "PREPARED", Device = "tabletPC" },
            new() { Id = NextId(), VoucherId = "CRV-56576", RegNo = "WREG-00579-17", CustomerName = "AYALEW H/WOT",
                IssuedDate = date, RoomNo = "303", Note = "Payment for WREG-00579-17 Room = 303", OtherReference = "",
                GrandTotal = 3510.01m, LastOperator = "PREPARED", Device = "tabletPC" },
            new() { Id = NextId(), VoucherId = "CRV-56577", RegNo = "", CustomerName = "SAFARYAN GEVORG",
                IssuedDate = date, RoomNo = "200", Note = "", OtherReference = "",
                GrandTotal = 1000.01m, LastOperator = "PREPARED", Device = "tabletPC" },
        };
    }

    public const string CashReceiptKnownTotal = "21,863.04";

    public static readonly Dictionary<string, string> SimpleTransactionKnownTotal = new()
    {
        ["Paid Out Report"] = "13,412.67",
        ["Rebate Report"] = "1,785.50",
    };

    public static List<SimpleTransactionRow> CreateSimpleTransactionSample(string reportName, DateTime date)
    {
        return reportName switch
        {
            "Paid Out Report" => new List<SimpleTransactionRow>
            {
                new() { Id = NextId(), VoucherId = "POV-00009-17", RegNo = "WREG-01441-17", CustomerName = "BOYEBBE LLC",
                    IssuedDate = date, RoomNo = "101", Note = "", GrandTotal = 236.35m, LastOperator = "PREPARED", Device = "tabletPC" },
                new() { Id = NextId(), VoucherId = "POV-00008-17", RegNo = "WREG-01434-17", CustomerName = "KUNWAR SURENDRA",
                    IssuedDate = date, RoomNo = "551", Note = "", GrandTotal = 2367.42m, LastOperator = "PREPARED", Device = "tabletPC" },
                new() { Id = NextId(), VoucherId = "POV-00007-17", RegNo = "WREG-01444-17", CustomerName = "SAFARYAN GEVORG",
                    IssuedDate = date, RoomNo = "304", Note = "", GrandTotal = 200.15m, LastOperator = "PREPARED", Device = "tabletPC" },
            },
            "Rebate Report" => new List<SimpleTransactionRow>
            {
                new() { Id = NextId(), VoucherId = "RCRM-00006-17", RegNo = "WREG-01579-17", CustomerName = "SAFARYAN GEVORG",
                    IssuedDate = date, RoomNo = "308", Note = "", GrandTotal = 463.75m, LastOperator = "PREPARED", Device = "tabletPC" },
                new() { Id = NextId(), VoucherId = "RCRM-00005-17", RegNo = "WREG-01578-17", CustomerName = "AHMED NASIR SATARAJ",
                    IssuedDate = date, RoomNo = "402", Note = "", GrandTotal = 1321.75m, LastOperator = "PREPARED", Device = "Test F" },
            },
            "Refund Report" => new List<SimpleTransactionRow>
            {
                new() { Id = NextId(), VoucherId = "RRF-00001-17", RegNo = "WREG-01591-17", CustomerName = "AHMED NASIR SATARAJ",
                    IssuedDate = new DateTime(2017, 9, 20), RoomNo = "706", Note = "", GrandTotal = 5743.31m, LastOperator = "PREPARED", Device = "tabletPC" },
            },
            "Debit Note Report" => new List<SimpleTransactionRow>
            {
                new() { Id = NextId(), VoucherId = "DBN-00003-17", RegNo = "WREG-01560-17", CustomerName = "GUEST WASA TEST",
                    IssuedDate = date, RoomNo = "305", Note = "Additional charge - damage", GrandTotal = 350.00m, LastOperator = "PREPARED", Device = "tabletPC" },
                new() { Id = NextId(), VoucherId = "DBN-00004-17", RegNo = "WREG-01562-17", CustomerName = "SAFARYAN GEVORG",
                    IssuedDate = date, RoomNo = "308", Note = "Additional charge - late fee", GrandTotal = 150.00m, LastOperator = "PREPARED", Device = "tabletPC" },
            },
            "Room POS Charge Report" => new List<SimpleTransactionRow>
            {
                new() { Id = NextId(), VoucherId = "PCH-00012-17", RegNo = "WREG-01570-17", CustomerName = "SAFARYAN GEVORG",
                    IssuedDate = date, RoomNo = "308", Note = "POS charge - restaurant", GrandTotal = 245.00m, LastOperator = "PREPARED", Device = "tabletPC" },
                new() { Id = NextId(), VoucherId = "PCH-00013-17", RegNo = "WREG-01571-17", CustomerName = "AYALEW H/WOT",
                    IssuedDate = date, RoomNo = "303", Note = "POS charge - room service", GrandTotal = 180.50m, LastOperator = "PREPARED", Device = "tabletPC" },
            },
            _ => new List<SimpleTransactionRow>(),
        };
    }

    public static readonly Dictionary<string, (string SubTotal, string ServiceCharge, string Discount, string Vat, string GrandTotal)> DetailedTransactionKnownTotal = new()
    {
        ["Credit Sales Report"] = ("13,881.48", "1,406.12", "0.00", "2,077.45", "17,365.05"),
        ["Cash Sales Report"] = ("5,646.64", "564.66", "0.00", "1,046.47", "7,257.77"),
        ["Daily Room Charge Report"] = ("9,249.56", "924.95", "0.00", "1,721.48", "11,895.99"),
    };

    public static List<DetailedTransactionRow> CreateDetailedTransactionSample(string reportName, DateTime date)
    {
        return reportName switch
        {
            "Credit Sales Report" => new List<DetailedTransactionRow>
            {
                new() { Id = NextId(), VoucherId = "BCRS-00753-17", RegNo = "WREG-01576-17", CustomerName = "SAFARYAN GEVORG",
                    IssuedDate = date, RoomNo = "308", Note = "check_out", SubTotal = 3294.55m, ServiceCharge = 329.46m,
                    Discount = 0.00m, Vat = 651.01m, GrandTotal = 4275.02m, LastOperator = "PREPARED", Device = "tabletPC" },
                new() { Id = NextId(), VoucherId = "BCRS-00752-17", RegNo = "WREG-01561-17", CustomerName = "KUNWAR SURENDRA SI",
                    IssuedDate = date, RoomNo = "308", Note = "check_out", SubTotal = 2774.71m, ServiceCharge = 277.47m,
                    Discount = 0.00m, Vat = 457.2m, GrandTotal = 3509.38m, LastOperator = "PREPARED", Device = "tabletPC" },
            },
            "Cash Sales Report" => new List<DetailedTransactionRow>
            {
                new() { Id = NextId(), VoucherId = "BCRS-00758-17", RegNo = "WREG-01574-17", CustomerName = "AYALEW H/WOT",
                    IssuedDate = date, RoomNo = "308", Note = "check_out", SubTotal = 2209.45m, ServiceCharge = 220.94m,
                    Discount = 0.00m, Vat = 435.2m, GrandTotal = 2865.59m, LastOperator = "PREPARED", Device = "tabletPC" },
                new() { Id = NextId(), VoucherId = "BCRS-00756-17", RegNo = "WREG-01576-17", CustomerName = "SAFARYAN GEVORG",
                    IssuedDate = date, RoomNo = "308", Note = "check_out", SubTotal = 740.55m, ServiceCharge = 74.05m,
                    Discount = 0.00m, Vat = 139.4m, GrandTotal = 953.99m, LastOperator = "PREPARED", Device = "tabletPC" },
            },
            "Daily Room Charge Report" => new List<DetailedTransactionRow>
            {
                new() { Id = NextId(), VoucherId = "MDRC-01849-17", RegNo = "WREG-01595-17", CustomerName = "GUEST WASA TEST",
                    IssuedDate = date, RoomNo = "305", Note = "UpdatedRate", SubTotal = 1552.26m, ServiceCharge = 155.23m,
                    Discount = 0.00m, Vat = 306.2m, GrandTotal = 2013.69m, LastOperator = "PREPARED", Device = "tabletPC" },
                new() { Id = NextId(), VoucherId = "MDRC-01848-17", RegNo = "WREG-01594-17", CustomerName = "NIDIRI WAWERU DAVI",
                    IssuedDate = date, RoomNo = "303", Note = "AU RATE", SubTotal = 2774.71m, ServiceCharge = 277.47m,
                    Discount = 0.00m, Vat = 457.6m, GrandTotal = 3509.78m, LastOperator = "PREPARED", Device = "tabletPC" },
            },
            _ => new List<DetailedTransactionRow>(),
        };
    }

    private static readonly (string Guest, string Room)[] TransactionGuestPool =
    {
        ("Betelhem Assefa", "201"),
        ("Nahom Tesfaye", "305"),
        ("Sara Mekonnen", "112"),
        ("Yared Alemayehu", "204"),
    };

    public static List<TransactionReportRow> CreateTransactionSample(string reportName, DateTime rangeStart, DateTime rangeEnd)
    {
        if (rangeEnd < rangeStart)
        {
            (rangeStart, rangeEnd) = (rangeEnd, rangeStart);
        }

        (string VoucherPrefix, string[] Descriptions, decimal MinAmount, decimal MaxAmount) profile =
            TransactionReportProfiles.TryGetValue(reportName, out var p)
                ? p
                : ("TX", new[] { $"{reportName} transaction" }, 200m, 2000m);

        var spanDays = (rangeEnd - rangeStart).Days;
        var rowCount = Math.Min(4, spanDays + 1);
        var rows = new List<TransactionReportRow>();

        for (var i = 0; i < rowCount; i++)
        {
            var guest = TransactionGuestPool[i % TransactionGuestPool.Length];
            var description = profile.Descriptions[i % profile.Descriptions.Length];
            var amount = profile.MinAmount + (profile.MaxAmount - profile.MinAmount) * (i + 1) / (rowCount + 1);

            rows.Add(new TransactionReportRow
            {
                Id = NextId(),
                Sn = i + 1,
                Date = rangeStart.AddDays(spanDays == 0 ? 0 : i * spanDays / Math.Max(1, rowCount - 1)),
                VoucherNo = $"{profile.VoucherPrefix}-{20000 + NextId()}",
                RegNo = $"REG-1{i:00}30",
                Guest = guest.Guest,
                Room = guest.Room,
                Description = description,
                Cashier = "F. Desta",
                Amount = Math.Round(amount, 2),
            });
        }

        return rows;
    }

    private static readonly string[] HkAttendantsRooms = { "-", "-", "-" };

    public static List<HousekeepingReportRow> CreateHousekeepingSample(string reportName, DateTime date)
    {
        var rows = new List<HousekeepingReportRow>();

        for (var i = 0; i < HkAttendantsRooms.Length; i++)
        {
            rows.Add(new HousekeepingReportRow
            {
                Id = NextId(),
                Sn = i + 1,
                Room = HkAttendantsRooms[i],
                Status = $"{6 + i} rooms completed",
                Attendant = new[] { "T. Bekele", "S. Wolde", "M. Girma" }[i % 3],
                Date = date,
                Remark = "Shift ending 16:00",
            });
        }

        return rows;
    }

    private static readonly (string Guest, string Room, string RoomType, string Company)[] GuestListPool =
    {
        ("Tsedale Worku", "203", "Standard", ""),
        ("Elias Fikru", "310", "Deluxe", "Addis Exporters"),
        ("Hiwot Bekele", "115", "Standard", ""),
    };

    public static List<ArrivalListRow> CreateGuestListSample(string reportName, DateTime date)
    {
        var rows = new List<ArrivalListRow>();

        for (var i = 0; i < GuestListPool.Length; i++)
        {
            var g = GuestListPool[i];
            var (arrival, departure, remark) = reportName switch
            {
                "Departure List" or "Due Outs" => (date.AddDays(-2), date.AddDays(1), "Scheduled to check out"),
                "Guest In-House List" or "Stayovers" => (date.AddDays(-1), date.AddDays(3), "Currently in-house"),
                "Pickup Report" => (date.AddDays(1), date.AddDays(3), "Needs airport pickup on arrival"),
                "Drop Off Report" => (date.AddDays(-2), date, "Requests shuttle drop-off at checkout"),
                "Police Report" => (date.AddDays(-1), date.AddDays(2), i % 2 == 0 ? "Gender: M, ID#: ETH-00123456" : "Gender: F, ID#: ETH-00987654"),
                "Postmaster In-House List" => (date.AddDays(-1), date.AddDays(2), "Postmaster room type"),
                "Room Move" => (date.AddDays(-1), date.AddDays(2), $"Moved from Room {100 + i} to Room {g.Room}"),
                "Arrived List" => (date, date.AddDays(2), "Arrived and checked in today"),
                _ => (date.AddDays(-1), date.AddDays(1), ""),
            };

            rows.Add(new ArrivalListRow
            {
                Id = NextId(),
                Sn = i + 1,
                RegNo = $"REG-1{i:00}45",
                Guest = g.Guest,
                Company = g.Company,
                Room = g.Room,
                RoomType = reportName == "Postmaster In-House List" ? "Postmaster" : g.RoomType,
                ArrivalDate = arrival,
                DepartureDate = departure,
                Adults = 1 + i % 2,
                Children = i == 1 ? 1 : 0,
                Agent = "Direct",
                Remark = remark,
            });
        }

        return rows;
    }

    public static List<NoShowReportRow> CreateNoShowSample(DateTime date)
    {
        return new List<NoShowReportRow>
        {
            new() { Id = NextId(), Sn = 1, RegNo = "RES-20063", Guest = "Tsedale Worku", Company = "",
                ArrivalDate = date, DepartureDate = date.AddDays(2), RegState = "No Show", RegType = "Individual",
                PaymentType = "Credit Card", MarketCode = "Leisure" },
            new() { Id = NextId(), Sn = 2, RegNo = "RES-20071", Guest = "Elias Fikru", Company = "Addis Exporters",
                ArrivalDate = date, DepartureDate = date.AddDays(1), RegState = "No Show", RegType = "Corporate",
                PaymentType = "City Ledger", MarketCode = "Corporate" },
            new() { Id = NextId(), Sn = 3, RegNo = "RES-20084", Guest = "Hiwot Bekele", Company = "",
                ArrivalDate = date, DepartureDate = date.AddDays(3), RegState = "No Show", RegType = "Individual",
                PaymentType = "Cash", MarketCode = "Walk-In" },
        };
    }

    public static List<PackageReportRow> CreatePackageSample(DateTime date)
    {
        return new List<PackageReportRow>
        {
            new() { Id = NextId(), RegNo = "WREG-00599-17", Room = "305", Guest = "GUEST WASA TEST",
                ArrivalDate = new DateTime(2017, 9, 14), DepartureDate = new DateTime(2017, 9, 23),
                PackageGroup = "Bed Package", PackageType = "Bed and Breakfast", Adult = 1, Child = 0,
                PackageAmount = 0.00m },
        };
    }

    public static List<RateCheckReportRow> CreateRateCheckSample(DateTime date)
    {
        return new List<RateCheckReportRow>
        {
            new() { Id = NextId(), RegNo = "WREG-00593-17", Room = "304", Guest = "JAVIER PRIETO MINA", Company = "",
                Adult = 1, Child = 0, RateCodeHeader = "WASSAMARRATE", RateCodeAmount = 85.00m, RateAmount = 85.00m,
                Variance = 0.00m, Currency = "US Dollar", ArrivalDate = new DateTime(2017, 9, 13),
                DepartureDate = new DateTime(2017, 9, 14), RoomType = "KING", Rtc = "KING", RegState = "Cancelled" },
        };
    }

    public static List<DailySalesSummaryRow> CreateDailySalesSummarySample(DateTime date)
    {
        return new List<DailySalesSummaryRow>
        {
            new() { Id = NextId(), VoucherId = "BCRS-00729-17", Customer = "AYALEW HIWOT", RoomNo = "",
                Cash = 4010.00m, RoomCharge = 0m, Entertainment = 0m, CityLedger = 0m, FoodAllowance = 0m },
        };
    }

    private static readonly string[] DailyBusinessItemColumns =
        { "SN", "Particulars", "Total Today", "Month Todate", "Year To Date", "Last Year Date", "Last Year Month", "Last Year" };

    private static readonly bool[] DailyBusinessItemRightAlign = { false, false, true, true, true, true, true, true };

    public static List<ReportSection> CreateDailyBusinessSections(DateTime date)
    {
        return new List<ReportSection>
        {
            new()
            {
                Title = "Resident Summary",
                Columns = DailyBusinessItemColumns,
                RightAlign = DailyBusinessItemRightAlign,
                Rows = new List<string[]>
                {
                    new[] { "1", "Room Sales", "29350.51", "0", "0", "0", "0", "0" },
                    new[] { "2", "Package", "1383.00", "0", "0", "0", "0", "0" },
                    new[] { "3", "Service Charge", "3339.30", "0", "0", "0", "0", "0" },
                    new[] { "4", "VAT", "5311.61", "0", "0", "0", "0", "0" },
                    new[] { "5", "POS Charge", "0.00", "0", "0", "0", "0", "0" },
                    new[] { "6", "Today Total", "39384.42", "0", "0", "0", "0", "0" },
                    new[] { "7", "Brought Forward", "0.00", "0", "0", "0", "0", "0" },
                    new[] { "8", "Todate Total", "39384.42", "0", "0", "0", "0", "0" },
                    new[] { "9", "Rebate", "1321.75", "0", "0", "0", "0", "0" },
                    new[] { "10", "Paid Out", "1000.00", "0", "0", "0", "0", "0" },
                    new[] { "11", "Cash Receipt", "14743.03", "0", "0", "0", "0", "0" },
                    new[] { "12", "Carried Forward", "3382.03", "0", "0", "0", "0", "0" },
                    new[] { "13", "Outstanding", "20937.61", "0", "0", "0", "0", "0" },
                },
            },
            new()
            {
                Title = "Income Analysis",
                Columns = DailyBusinessItemColumns,
                RightAlign = DailyBusinessItemRightAlign,
                Rows = new List<string[]>
                {
                    new[] { "1", "Room Sales", "30733.51", "0", "0", "0", "0", "0" },
                    new[] { "2", "Discount", "-1321.75", "0", "0", "0", "0", "0" },
                    new[] { "3", "Service Charge", "3339.30", "0", "0", "0", "0", "0" },
                    new[] { "4", "VAT", "5311.61", "0", "0", "0", "0", "0" },
                },
                TotalRow = new[] { "", "Grand Total=", "38,062.67", "0.00", "0.00", "0.00", "0.00", "0.00" },
            },
            new()
            {
                Title = "Sales Centers Activity Analysis",
                Columns = new[] { "SN", "Machine Name", "Cash", "Room", "City Ledger", "Entertainment", "Food Allowance", "Total Today", "Month Today" },
                RightAlign = new[] { false, false, true, true, true, true, true, true, true },
                Rows = new List<string[]>
                {
                    new[] { "1", "Room Sales", "0", "39384.42", "0", "0", "0", "39384.42", "0" },
                },
                TotalRow = new[] { "", "Total =", "0.00", "39,384.42", "0.00", "0.00", "0.00", "39,384.42", "0.00" },
            },
            new()
            {
                Title = "Collector Analysis",
                Columns = new[] { "SN", "Cashier", "From Guest", "Advanced Deposit", "From Credit", "Cash Recieved", "Total" },
                RightAlign = new[] { false, false, true, true, true, true, true },
                Rows = new List<string[]>
                {
                    new[] { "1", "CNET ADMIN", "0", "0", "21863.04", "0", "21863.04" },
                },
                TotalRow = new[] { "", "Total =", "0.00", "0.00", "21,863.04", "0.00", "21,863.04" },
            },
            new()
            {
                Title = "Occupancy Summary",
                Columns = new[] { "SN", "Room Type", "Rooms", "Occupied", "Vacant", "Occupancy [%]", "MTD [%]", "YTD [%]", "Today", "Month", "Yearly", "ADR" },
                RightAlign = new[] { false, false, true, true, true, true, true, true, true, true, true, true },
                Rows = new List<string[]>
                {
                    new[] { "1", "KING", "55", "0", "53", "0", "0", "0", "0", "0", "0", "0" },
                    new[] { "2", "SUITE", "6", "0", "6", "0", "0", "0", "0", "0", "0", "0" },
                    new[] { "3", "TWIN", "5", "0", "5", "0", "0", "0", "0", "0", "0", "0" },
                    new[] { "4", "PSEUDO ROOM TYP", "20", "0", "10", "0", "0", "0", "0", "0", "0", "0" },
                    new[] { "5", "VIP", "5", "0", "4", "0", "0", "0", "0", "0", "0", "0" },
                },
                TotalRow = new[] { "", "Total =", "91.00", "0.00", "78.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00" },
            },
        };
    }

    private static readonly string[] CashDroppedDocumentColumns =
        { "Voucher ID", "Ref Number", "Date", "User", "Received From", "Payment Method", "Total" };

    private static readonly bool[] CashDroppedDocumentRightAlign = { false, false, false, false, false, false, true };

    public static List<ReportSection> CreateCashDroppedSections(DateTime date)
    {
        return new List<ReportSection>
        {
            new()
            {
                Title = "Sales Documents",
                Columns = new[] { "Voucher ID", "Room No", "Cash", "Room Charge", "Entertainment", "City Ledger", "Food Allowance" },
                RightAlign = new[] { false, false, true, true, true, true, true },
                Rows = new List<string[]>
                {
                    new[] { "BCS-00624-17", "", "82.96", "0", "0", "0", "0" },
                },
            },
            new()
            {
                Title = "Cash Receipt Documents",
                Columns = CashDroppedDocumentColumns,
                RightAlign = CashDroppedDocumentRightAlign,
                Rows = new List<string[]>
                {
                    new[] { "CRV-56575", "", "9/13/2017", "CNET ADMIN", "AYALEW HIWOT", "Cash", "500.00" },
                },
            },
            new()
            {
                Title = "Refund Documents",
                Columns = CashDroppedDocumentColumns,
                RightAlign = CashDroppedDocumentRightAlign,
                Rows = new List<string[]>
                {
                    new[] { "POV-00024-17", "", "9/13/2017", "CNET ADMIN", "SAFARYAN GEVORG", "Cash", "1000.00" },
                },
            },
        };
    }

    private static readonly string[] RoomIncomeColumns = { "Registration", "Date", "Room No", "Customer Name", "Rate Type", "Amount" };
    private static readonly bool[] RoomIncomeRightAlign = { false, false, false, false, false, true };

    public static List<ReportSection> CreateRoomIncomeSections(DateTime start, DateTime end)
    {
        return new List<ReportSection>
        {
            new()
            {
                Title = "Room Type: KING",
                Columns = RoomIncomeColumns,
                RightAlign = RoomIncomeRightAlign,
                Rows = new List<string[]>
                {
                    new[] { "WREG-00577-17", "9/13/2017", "303", "AYALEW HIWOT", "KING", "3054.71" },
                    new[] { "WREG-00579-17", "9/13/2017", "308", "SAFARYAN GEVORG", "KING", "3449.98" },
                    new[] { "WREG-00581-17", "9/13/2017", "308", "CHARLES LIHULUK ERICK", "KING", "1667.36" },
                    new[] { "WREG-00582-17", "9/13/2017", "308", "KUNWAR SURENDRA SINGH", "KING", "2659.46" },
                    new[] { "WREG-00583-17", "9/13/2017", "308", "KUNWAR SURENDRA SINGH", "KING", "4288.09" },
                    new[] { "WREG-00586-17", "9/13/2017", "311", "GUEST WASA TEST", "KING", "2659.46" },
                    new[] { "WREG-00588-17", "9/13/2017", "402", "AHEMAD NASIR SATARAJ", "KING", "5790.07" },
                    new[] { "WREG-00590-17", "9/13/2017", "301", "SAFARYAN GEVORG", "KING", "1642.07" },
                    new[] { "WREG-00597-17", "9/14/2017", "301", "GUO WENZHONG", "KING", "2659.46" },
                    new[] { "WREG-00599-17", "9/14/2017", "305", "GUEST WASA TEST", "KING", "1087.13" },
                },
            },
            new()
            {
                Title = "Room Type: PSEUDO ROOM TYPE",
                Columns = RoomIncomeColumns,
                RightAlign = RoomIncomeRightAlign,
                Rows = new List<string[]>
                {
                    new[] { "WREG-00592-17", "9/13/2017", "2002", "SAFARYAN GEVORG", "PSEUDO ROOM TYPE", "1479.85" },
                },
            },
            new()
            {
                Title = "Room Type: SUITE",
                Columns = RoomIncomeColumns,
                RightAlign = RoomIncomeRightAlign,
                Rows = new List<string[]>
                {
                    new[] { "WREG-00589-17", "9/13/2017", "705", "NAGUIB ALI TAHER", "SUITE", "2659.46" },
                    new[] { "WREG-00595-17", "9/14/2017", "703", "EBISEE SOLOMON REGASSA", "SUITE", "2659.46" },
                    new[] { "WREG-00596-17", "9/14/2017", "703", "YONGMING CHEN", "SUITE", "2659.46" },
                    new[] { "WREG-00600-17", "9/14/2017", "701", "NIJIRI WAWERU DAVID", "SUITE", "1479.85" },
                },
            },
            new()
            {
                Title = "Room Type: VIP",
                Columns = RoomIncomeColumns,
                RightAlign = RoomIncomeRightAlign,
                Rows = new List<string[]>
                {
                    new[] { "WREG-00603-17", "9/14/2017", "104", "DOUALEH AHMED DOUALEH", "VIP", "1479.46" },
                },
                TotalRow = new[] { "", "", "", "", "Grand Total=", "42,555.33" },
            },
        };
    }

    public static List<DailyResidentSummaryRow> CreateDailyResidentSummarySample(DateTime date)
    {
        return new List<DailyResidentSummaryRow>
        {
            new() { Id = NextId(), Sn = 1, RegNo = "REG-10041", Guest = "Samuel Girma", Company = "Sunrise Tours", Room = "108",
                RateCode = "AGENT-006", RoomRevenue = 1900m, Package = 200m, ServiceCharge = 210m, Vat = 315m,
                PosCharge = 450m, Bbf = 1200m, Payment = 2000m, Discount = 0m, Paidout = 0m },
            new() { Id = NextId(), Sn = 2, RegNo = "REG-10052", Guest = "Marta Alemu", Company = "", Room = "215",
                RateCode = "RACK-007", RoomRevenue = 2600m, Package = 0m, ServiceCharge = 260m, Vat = 429m,
                PosCharge = 0m, Bbf = 0m, Payment = 2600m, Discount = 100m, Paidout = 0m },
            new() { Id = NextId(), Sn = 3, RegNo = "REG-10058", Guest = "Yonas Bekele", Company = "Nile Exports", Room = "402",
                RateCode = "CORP-002", RoomRevenue = 4200m, Package = 350m, ServiceCharge = 455m, Vat = 750.75m,
                PosCharge = 620m, Bbf = 3400m, Payment = 8400m, Discount = 0m, Paidout = 150m },
        };
    }

    public static List<CancellationReportRow> CreateCancellationSample(DateTime date)
    {
        return new List<CancellationReportRow>
        {
            new() { Id = NextId(), Sn = 1, RegNo = "RES-30012", Room = "-", RoomCount = 1, RoomType = "Standard",
                Company = "", Guest = "Hana Wolde", Adult = 1, Child = 0, ArrivalDate = date, DepartureDate = date.AddDays(2),
                RateCode = "RACK-007", RateAmount = 1900m, PaymentType = "Cash", User = "F. Desta", ActualRtc = "RTC01",
                MarketCode = "Leisure" },
            new() { Id = NextId(), Sn = 2, RegNo = "RES-30027", Room = "-", RoomCount = 2, RoomType = "Deluxe",
                Company = "Blue Nile Logistics", Guest = "Dawit Mulugeta", Adult = 2, Child = 1, ArrivalDate = date.AddDays(1),
                DepartureDate = date.AddDays(4), RateCode = "CORP-001", RateAmount = 2600m, PaymentType = "City Ledger",
                User = "S. Wolde", ActualRtc = "RTC02", MarketCode = "Corporate Bl" },
            new() { Id = NextId(), Sn = 3, RegNo = "RES-30041", Room = "-", RoomCount = 1, RoomType = "Suite",
                Company = "", Guest = "Selam Fikru", Adult = 1, Child = 0, ArrivalDate = date, DepartureDate = date.AddDays(1),
                RateCode = "AGENT-006", RateAmount = 4200m, PaymentType = "Credit Card", User = "F. Desta", ActualRtc = "RTC03",
                MarketCode = "Agent" },
        };
    }

    public static List<TrialBalanceGroup> CreateTrialBalanceSample(DateTime date)
    {
        return new List<TrialBalanceGroup>
        {
            new()
            {
                GroupName = "Non Revenue",
                Lines = new List<TrialBalanceLine>
                {
                    new() { Description = "VAT", Balance = 9845.67m },
                    new() { Description = "Discount", Balance = 886.97m },
                    new() { Description = "Service Charge", Balance = 6047.67m },
                },
            },
            new()
            {
                GroupName = "Payment Cash",
                Lines = new List<TrialBalanceLine>
                {
                    new() { Description = "Cash Birr", Balance = 49503.85m },
                },
            },
            new()
            {
                GroupName = "Sales Center Revenues",
                Lines = new List<TrialBalanceLine>
                {
                    new() { Description = "sabebe-PC BEVERAGE", Balance = 65.58m },
                    new() { Description = "sabebe-PC FOOD", Balance = 335.00m },
                },
            },
        };
    }

    public static List<CashierUserGroup> CreateCashierSummarySample(DateTime date)
    {
        var cashLines = new List<CashierVoucherLine>
        {
            new() { VoucherType = "Cash Receipt", CurrencyAmount = 21863.04m, Rate = 1.00m, EtbTotal = 21863.04m },
            new() { VoucherType = "Paid Out", CurrencyAmount = -1000.00m, Rate = 1.00m, EtbTotal = -1000.00m },
            new() { VoucherType = "Cash Sales", CurrencyAmount = 82.96m, Rate = 1.00m, EtbTotal = 82.96m },
        };

        return new List<CashierUserGroup>
        {
            new()
            {
                UserName = "CNET ADMIN",
                PaymentMethods = new List<CashierPaymentMethodGroup>
                {
                    new()
                    {
                        MethodName = "Cash",
                        Currencies = new List<CashierCurrencyGroup>
                        {
                            new() { CurrencyName = "Birr", Lines = cashLines },
                        },
                    },
                },
            },
        };
    }

    public static ReportsState CreateSample()
    {
        var today = DateTime.Today;
        var state = new ReportsState
        {
            BusinessDate = today,
            Catalog = CreateCatalog(),
            CheckoutRows = CreateCheckoutReportSample(today),
            DiscrepancyRows = CreateDiscrepancyReportSample(today),
            ArrivalRows = CreateArrivalListSample(today)
        };

        return state;
    }
}
