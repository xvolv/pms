namespace ERP.V7.WebPMS.Components.Pages.Reports.Models;

public enum ReportGroup
{
    Interactive,
    NightAudit,
    Housekeeping,
    Transaction,
    Other,
}

public enum ReportCriteriaMode
{
    SimpleDate,
    PeriodRange,
}

public enum ReportPeriodType
{
    Daily,
    Weekly,
    Monthly,
    AtTheDayOf,
    Annually,
    DateRange,
    ShowAll,
}

public class ReportDefinition
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public ReportGroup Group { get; set; }
    public bool IsImplemented { get; set; }
}

public class CheckoutReportRow
{
    public int Id { get; set; }
    public string RegNo { get; set; } = "";
    public string Room { get; set; } = "";
    public int RoomCount { get; set; }
    public string RoomType { get; set; } = "";
    public string Company { get; set; } = "";
    public string Guest { get; set; } = "";
    public int Adult { get; set; }
    public int Child { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public string RateCode { get; set; } = "";
    public string PaymentType { get; set; } = "";
    public string User { get; set; } = "";
    public string ActualRtc { get; set; } = "";
    public string MarketCode { get; set; } = "";
    public decimal RateAmount { get; set; }
}

public class CityLedgerRow
{
    public int Id { get; set; }
    public string RegNo { get; set; } = "";
    public DateTime Date { get; set; }
    public string Guest { get; set; } = "";
    public string Company { get; set; } = "";
    public decimal SubTotal { get; set; }
}

public class ReportCriteria
{
    public DateTime Date { get; set; } = DateTime.Today;
    public string PeriodType { get; set; } = "Daily";
    public DateTime RangeStart { get; set; } = DateTime.Today;
    public DateTime RangeEnd { get; set; } = DateTime.Today;
}

public class ManagerialFlashItemRow
{
    public int Id { get; set; }
    public int Sn { get; set; }
    public string ReportItem { get; set; } = "";
    public string CurrentYearDay { get; set; } = "";
    public string CurrentYearMonth { get; set; } = "";
    public string CurrentYearToDate { get; set; } = "";
    public string PriorYearDay { get; set; } = "";
    public string PriorYearMonth { get; set; } = "";
    public string PriorYearToDate { get; set; } = "";
}

public class DiscrepancyReportRow
{
    public int Id { get; set; }
    public string RoomNo { get; set; } = "";
    public string RoomType { get; set; } = "";
    public string RoomStatus { get; set; } = "";
    public string HkStatus { get; set; } = "";
    public string FoStatus { get; set; } = "";
    public string ResStatus { get; set; } = "";
    public int FoPerson { get; set; }
    public int HkPerson { get; set; }
    public string Discrepancy { get; set; } = "";
    public DateTime Date { get; set; }
}

public class HkActivityRow
{
    public int Id { get; set; }
    public string Activity { get; set; } = "";
    public string RoomNumber { get; set; } = "";
    public DateTime Date { get; set; }
    public string User { get; set; } = "";
    public string DeviceName { get; set; } = "";
}

public class TaskAssignmentRow
{
    public int Id { get; set; }
    public DateTime TaskDate { get; set; }
    public string Task { get; set; } = "";
    public string InAuto { get; set; } = "";
    public int TotalSheets { get; set; }
    public int TotalCredits { get; set; }
}

public class ArrivalListRow
{
    public int Id { get; set; }
    public int Sn { get; set; }
    public string RegNo { get; set; } = "";
    public string Guest { get; set; } = "";
    public string Company { get; set; } = "";
    public string Room { get; set; } = "";
    public string RoomType { get; set; } = "";
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public int Adults { get; set; }
    public int Children { get; set; }
    public string Agent { get; set; } = "";
    public string Remark { get; set; } = "";
}

public class HousekeepingReportRow
{
    public int Id { get; set; }
    public int Sn { get; set; }
    public string Room { get; set; } = "";
    public string Status { get; set; } = "";
    public string Attendant { get; set; } = "";
    public DateTime Date { get; set; }
    public string Remark { get; set; } = "";
}

public class DailyResidentSummaryRow
{
    public int Id { get; set; }
    public int Sn { get; set; }
    public string RegNo { get; set; } = "";
    public string Guest { get; set; } = "";
    public string Company { get; set; } = "";
    public string Room { get; set; } = "";
    public string RateCode { get; set; } = "";
    public decimal RoomRevenue { get; set; }
    public decimal Package { get; set; }
    public decimal ServiceCharge { get; set; }
    public decimal Vat { get; set; }
    public decimal RoomTotal => RoomRevenue + Package + ServiceCharge + Vat;
    public decimal PosCharge { get; set; }
    public decimal TodayTotal => RoomTotal + PosCharge;
    public decimal Bbf { get; set; }
    public decimal ToDateTotal => TodayTotal + Bbf;
    public decimal Payment { get; set; }
    public decimal Discount { get; set; }
    public decimal Paidout { get; set; }
    public decimal Bcf => ToDateTotal - Payment - Discount - Paidout;
    public decimal Outstanding => Bcf;
}

public class CancellationReportRow
{
    public int Id { get; set; }
    public int Sn { get; set; }
    public string RegNo { get; set; } = "";
    public string Room { get; set; } = "";
    public int RoomCount { get; set; }
    public string RoomType { get; set; } = "";
    public string Company { get; set; } = "";
    public string Guest { get; set; } = "";
    public int Adult { get; set; }
    public int Child { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public string RateCode { get; set; } = "";
    public decimal RateAmount { get; set; }
    public string PaymentType { get; set; } = "";
    public string User { get; set; } = "";
    public string ActualRtc { get; set; } = "";
    public string MarketCode { get; set; } = "";
}

public class NoShowReportRow
{
    public int Id { get; set; }
    public int Sn { get; set; }
    public string RegNo { get; set; } = "";
    public string Guest { get; set; } = "";
    public string Company { get; set; } = "";
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public string RegState { get; set; } = "";
    public string RegType { get; set; } = "";
    public string PaymentType { get; set; } = "";
    public string MarketCode { get; set; } = "";
}

public class PackageReportRow
{
    public int Id { get; set; }
    public string RegNo { get; set; } = "";
    public string Room { get; set; } = "";
    public string Guest { get; set; } = "";
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public string PackageGroup { get; set; } = "";
    public string PackageType { get; set; } = "";
    public int Adult { get; set; }
    public int Child { get; set; }
    public decimal PackageAmount { get; set; }
}

public class RateCheckReportRow
{
    public int Id { get; set; }
    public string RegNo { get; set; } = "";
    public string Room { get; set; } = "";
    public string Guest { get; set; } = "";
    public string Company { get; set; } = "";
    public int Adult { get; set; }
    public int Child { get; set; }
    public string RateCodeHeader { get; set; } = "";
    public decimal RateCodeAmount { get; set; }
    public decimal RateAmount { get; set; }
    public decimal Variance { get; set; }
    public string Currency { get; set; } = "";
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public string RoomType { get; set; } = "";
    public string Rtc { get; set; } = "";
    public string RegState { get; set; } = "";
}

public class DailySalesSummaryRow
{
    public int Id { get; set; }
    public string VoucherId { get; set; } = "";
    public string Customer { get; set; } = "";
    public string RoomNo { get; set; } = "";
    public decimal Cash { get; set; }
    public decimal RoomCharge { get; set; }
    public decimal Entertainment { get; set; }
    public decimal CityLedger { get; set; }
    public decimal FoodAllowance { get; set; }
}

public class TrialBalanceLine
{
    public string Description { get; set; } = "";
    public decimal Balance { get; set; }
}

public class TrialBalanceGroup
{
    public string GroupName { get; set; } = "";
    public List<TrialBalanceLine> Lines { get; set; } = new();
    public int Count => Lines.Count;
    public decimal Total => Lines.Sum(l => l.Balance);
}

public class CashierVoucherLine
{
    public string VoucherType { get; set; } = "";
    public decimal CurrencyAmount { get; set; }
    public decimal Rate { get; set; } = 1.00m;
    public decimal EtbTotal { get; set; }
}

public class CashierCurrencyGroup
{
    public string CurrencyName { get; set; } = "";
    public List<CashierVoucherLine> Lines { get; set; } = new();
    public decimal Total => Lines.Sum(l => l.EtbTotal);
}

public class CashierPaymentMethodGroup
{
    public string MethodName { get; set; } = "";
    public List<CashierCurrencyGroup> Currencies { get; set; } = new();
    public decimal Total => Currencies.Sum(c => c.Total);
}

public class CashierUserGroup
{
    public string UserName { get; set; } = "";
    public List<CashierPaymentMethodGroup> PaymentMethods { get; set; } = new();
    public decimal Total => PaymentMethods.Sum(p => p.Total);
}

public class ReportSection
{
    public string Title { get; set; } = "";
    public string[] Columns { get; set; } = Array.Empty<string>();
    public bool[] RightAlign { get; set; } = Array.Empty<bool>();
    public List<string[]> Rows { get; set; } = new();
    public string[]? TotalRow { get; set; }
}

public class TransactionReportRow
{
    public int Id { get; set; }
    public int Sn { get; set; }
    public DateTime Date { get; set; }
    public string VoucherNo { get; set; } = "";
    public string RegNo { get; set; } = "";
    public string Guest { get; set; } = "";
    public string Room { get; set; } = "";
    public string Description { get; set; } = "";
    public string Cashier { get; set; } = "";
    public decimal Amount { get; set; }
}
