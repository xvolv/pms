namespace ERP.V7.WebPMS.Components.Pages.Reports.Models;

public class ReportsState
{
    public DateTime BusinessDate { get; set; } = DateTime.Today;

    public List<ReportDefinition> Catalog { get; set; } = new();
    public List<CheckoutReportRow> CheckoutRows { get; set; } = new();
    public List<ManagerialFlashRow> ManagerialFlash { get; set; } = new();
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
            new() { Id = NextId(), Sn = 1, RegNo = "REG-10011", Guest = "Betelhem Assefa", Company = "", Room = "201",
                RoomType = "Standard", ArrivalDate = date.AddDays(-2), DepartureDate = date, PaymentType = "Cash",
                TotalBill = 3600m, Paid = 3600m },
            new() { Id = NextId(), Sn = 2, RegNo = "REG-10019", Guest = "Nahom Tesfaye", Company = "Ethio Trading PLC", Room = "305",
                RoomType = "Deluxe", ArrivalDate = date.AddDays(-3), DepartureDate = date, PaymentType = "Credit Card",
                TotalBill = 7800m, Paid = 7800m },
            new() { Id = NextId(), Sn = 3, RegNo = "REG-10027", Guest = "Sara Mekonnen", Company = "", Room = "112",
                RoomType = "Standard", ArrivalDate = date.AddDays(-1), DepartureDate = date, PaymentType = "City Ledger",
                TotalBill = 1900m, Paid = 1200m },
        };
    }

    public static List<ManagerialFlashRow> CreateManagerialFlashSample(DateTime date)
    {
        return new List<ManagerialFlashRow>
        {
            new() { Id = NextId(), Metric = "Occupancy %", Today = "78%", MonthToDate = "71%", PriorMonth = "68%", PriorYear = "65%" },
            new() { Id = NextId(), Metric = "Rooms Sold", Today = "39", MonthToDate = "742", PriorMonth = "680", PriorYear = "610" },
            new() { Id = NextId(), Metric = "Average Daily Rate (ADR)", Today = "2,450.00", MonthToDate = "2,380.00", PriorMonth = "2,300.00", PriorYear = "2,150.00" },
            new() { Id = NextId(), Metric = "RevPAR", Today = "1,911.00", MonthToDate = "1,689.80", PriorMonth = "1,564.00", PriorYear = "1,397.50" },
            new() { Id = NextId(), Metric = "Room Revenue", Today = "95,550.00", MonthToDate = "1,766,760.00", PriorMonth = "1,564,000.00", PriorYear = "1,311,500.00" },
            new() { Id = NextId(), Metric = "No Shows", Today = "1", MonthToDate = "14", PriorMonth = "11", PriorYear = "9" },
            new() { Id = NextId(), Metric = "Cancellations", Today = "2", MonthToDate = "22", PriorMonth = "19", PriorYear = "17" },
        };
    }

    public static List<DiscrepancyReportRow> CreateDiscrepancyReportSample(DateTime date)
    {
        return new List<DiscrepancyReportRow>
        {
            new() { Id = NextId(), Room = "306", SystemStatus = "Occupied", HousekeepingStatus = "Vacant Dirty",
                ReportedDate = date, Remark = "Guest checked out early, HK not updated by front desk." },
            new() { Id = NextId(), Room = "410", SystemStatus = "Vacant Clean", HousekeepingStatus = "Occupied",
                ReportedDate = date, Remark = "Walk-in assigned without system update." },
            new() { Id = NextId(), Room = "118", SystemStatus = "Vacant Dirty", HousekeepingStatus = "Vacant Clean",
                ReportedDate = date, Remark = "Room cleaned but status not synced from HK app." },
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
        ["Cash Receipt Report"] = ("CR", new[] { "Cash receipt - room balance", "Cash receipt - advance deposit", "Cash receipt - folio settlement" }, 500m, 5000m),
        ["Paid Out Report"] = ("PO", new[] { "Taxi fare paid out", "Doctor fee paid out", "Medicine purchase paid out" }, 100m, 1200m),
        ["Rebate Report"] = ("RB", new[] { "Rebate - rate correction", "Rebate - service complaint", "Rebate - late checkout waiver" }, 100m, 2000m),
        ["Credit Sales Report"] = ("CS", new[] { "Credit sale - room charge", "Credit sale - F&B", "Credit sale - laundry" }, 300m, 6000m),
        ["Cash Sales Report"] = ("CH", new[] { "Cash sale - room charge", "Cash sale - F&B", "Cash sale - mini bar" }, 200m, 4500m),
        ["Debit Note Report"] = ("DN", new[] { "Debit note - additional charge", "Debit note - damage fee", "Debit note - late fee" }, 150m, 3000m),
        ["Refund Report"] = ("RF", new[] { "Refund - cancelled reservation", "Refund - overpayment", "Refund - service issue" }, 200m, 3500m),
        ["Daily Room Charge Report"] = ("DR", new[] { "Room charge - standard", "Room charge - deluxe", "Room charge - suite" }, 1500m, 4500m),
        ["Room POS Charge Report"] = ("PC", new[] { "POS charge - restaurant", "POS charge - room service", "POS charge - spa" }, 150m, 2500m),
        ["Detail Daily Sales Transaction"] = ("DS", new[] { "Room charge + tax", "F&B charge + tax", "Laundry charge + tax" }, 400m, 5500m),
        ["Rate Adjustment Report"] = ("RA", new[] { "Rate adjusted - loyalty discount", "Rate adjusted - manager override", "Rate adjusted - long stay discount" }, 100m, 1500m),
        ["Check Report of the Day"] = ("CK", new[] { "Check received - folio settlement", "Check received - advance deposit" }, 500m, 6000m),
        ["City Ledger"] = ("CL", new[] { "City ledger - corporate account", "City ledger - travel agent account" }, 1000m, 12000m),
        ["Credit Cards of the Day"] = ("CC", new[] { "Visa settlement", "Mastercard settlement", "Amex settlement" }, 800m, 9000m),
        ["Deposit Ledger"] = ("DL", new[] { "Deposit held - advance reservation", "Deposit held - group booking" }, 1000m, 8000m),
        ["Rate Check Report"] = ("RC", new[] { "Rate variance - override not authorized", "Rate variance - system default applied" }, 100m, 2500m),
        ["Cash Dropped Report"] = ("CD", new[] { "Cash drop - morning shift", "Cash drop - evening shift" }, 2000m, 15000m),
        ["Room Income Report"] = ("RI", new[] { "Room income - standard rooms", "Room income - deluxe rooms", "Room income - suites" }, 5000m, 40000m),
    };

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

    private static readonly Dictionary<string, string[]> HousekeepingReportRooms = new()
    {
        ["HK Activity Report"] = new[] { "306", "410", "118" },
        ["HK Attendants Report"] = new[] { "-", "-", "-" },
        ["Status Report"] = new[] { "101", "102", "103", "104" },
        ["Task Assignment Report"] = new[] { "204", "215", "309" },
    };

    public static List<HousekeepingReportRow> CreateHousekeepingSample(string reportName, DateTime date)
    {
        var rooms = HousekeepingReportRooms.TryGetValue(reportName, out var r) ? r : new[] { "101", "102" };
        var rows = new List<HousekeepingReportRow>();

        for (var i = 0; i < rooms.Length; i++)
        {
            var (status, attendant, remark) = reportName switch
            {
                "HK Activity Report" => ("Vacant Clean", "T. Bekele", i % 2 == 0 ? "Changed from Vacant Dirty to Vacant Clean" : "Changed from Occupied to Vacant Dirty"),
                "HK Attendants Report" => ($"{6 + i} rooms completed", new[] { "T. Bekele", "S. Wolde", "M. Girma" }[i % 3], "Shift ending 16:00"),
                "Status Report" => (new[] { "Occupied Clean", "Vacant Dirty", "Vacant Clean", "Out of Order" }[i % 4], "-", ""),
                "Task Assignment Report" => (new[] { "Checkout Clean", "Turndown", "Stay-over Clean" }[i % 3], new[] { "T. Bekele", "S. Wolde", "M. Girma" }[i % 3], "Assigned for today's shift"),
                _ => ("-", "-", ""),
            };

            rows.Add(new HousekeepingReportRow
            {
                Id = NextId(),
                Sn = i + 1,
                Room = rooms[i],
                Status = status,
                Attendant = attendant,
                Date = date,
                Remark = remark,
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
                "No Show Report" => (date, date.AddDays(2), "No show - did not arrive by day closing"),
                "Package Report" => (date.AddDays(-1), date.AddDays(2), "Bed & Breakfast package included"),
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

    public static List<SummaryMetricRow> CreateSummaryMetricSample(string reportName, DateTime date)
    {
        var lines = reportName switch
        {
            "Daily Sales Summary" => new[]
            {
                ("Room Sales", "95,550.00", ""),
                ("F&B Sales", "27,700.00", ""),
                ("Other Sales", "6,400.00", ""),
                ("Subtotal", "129,650.00", ""),
                ("Tax", "19,447.50", "15% VAT"),
                ("Grand Total", "149,097.50", ""),
            },
            _ => new[] { (reportName, "-", "") },
        };

        return lines.Select((l, i) => new SummaryMetricRow
        {
            Id = NextId(),
            Sn = i + 1,
            Label = l.Item1,
            Value = l.Item2,
            Note = l.Item3,
        }).ToList();
    }

    public static List<ManagerialFlashRow> CreateDailyBusinessSample(DateTime date)
    {
        return new List<ManagerialFlashRow>
        {
            new() { Id = NextId(), Metric = "Total Transactions", Today = "149,097.50", MonthToDate = "3,254,300.00", PriorMonth = "3,010,500.00", PriorYear = "2,780,900.00" },
            new() { Id = NextId(), Metric = "Room Revenue", Today = "95,550.00", MonthToDate = "1,766,760.00", PriorMonth = "1,564,000.00", PriorYear = "1,311,500.00" },
            new() { Id = NextId(), Metric = "F&B Revenue", Today = "27,700.00", MonthToDate = "612,400.00", PriorMonth = "580,100.00", PriorYear = "540,300.00" },
            new() { Id = NextId(), Metric = "Other Revenue", Today = "6,400.00", MonthToDate = "142,600.00", PriorMonth = "135,900.00", PriorYear = "121,200.00" },
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
            ManagerialFlash = CreateManagerialFlashSample(today),
            DiscrepancyRows = CreateDiscrepancyReportSample(today),
            ArrivalRows = CreateArrivalListSample(today)
        };

        return state;
    }
}
