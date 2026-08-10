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

public class ManagerialFlashRow
{
    public int Id { get; set; }
    public string Metric { get; set; } = "";
    public string Today { get; set; } = "";
    public string MonthToDate { get; set; } = "";
    public string PriorMonth { get; set; } = "";
    public string PriorYear { get; set; } = "";
}

public class DiscrepancyReportRow
{
    public int Id { get; set; }
    public string Room { get; set; } = "";
    public string SystemStatus { get; set; } = "";
    public string HousekeepingStatus { get; set; } = "";
    public DateTime ReportedDate { get; set; }
    public string Remark { get; set; } = "";
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

public class SummaryMetricRow
{
    public int Id { get; set; }
    public int Sn { get; set; }
    public string Label { get; set; } = "";
    public string Value { get; set; } = "";
    public string Note { get; set; } = "";
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
