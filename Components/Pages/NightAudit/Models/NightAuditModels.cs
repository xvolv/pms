namespace ERP.V7.WebPMS.Components.Pages.NightAudit.Models;

public class NightAuditRegistration
{
    public int Id { get; set; }
    public string RegNo { get; set; } = "";
    public string Guest { get; set; } = "";
    public string Company { get; set; } = "";
    public string Room { get; set; } = "";
    public string RoomType { get; set; } = "";
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public int Adults { get; set; } = 1;
    public int Children { get; set; }
    public string Rtc { get; set; } = "";
    public string RateCode { get; set; } = "";
    public decimal Amount { get; set; }
    public bool IsFixedRate { get; set; }
    public string PaymentType { get; set; } = "";
    public decimal TotalBill { get; set; }
    public decimal Paid { get; set; }
    public decimal Remaining => TotalBill - Paid;
    public string Agent { get; set; } = "";
    public string Source { get; set; } = "";
    public string Market { get; set; } = "";

    public NightAuditRegistration Clone() => new()
    {
        Id = Id,
        RegNo = RegNo,
        Guest = Guest,
        Company = Company,
        Room = Room,
        RoomType = RoomType,
        ArrivalDate = ArrivalDate,
        DepartureDate = DepartureDate,
        Adults = Adults,
        Children = Children,
        Rtc = Rtc,
        RateCode = RateCode,
        Amount = Amount,
        IsFixedRate = IsFixedRate,
        PaymentType = PaymentType,
        TotalBill = TotalBill,
        Paid = Paid,
        Agent = Agent,
        Source = Source,
        Market = Market,
    };

    public void CopyFrom(NightAuditRegistration source)
    {
        ArrivalDate = source.ArrivalDate;
        DepartureDate = source.DepartureDate;
    }
}

public class HeldBillRow
{
    public int Id { get; set; }
    public int Sn { get; set; }
    public string VoucherNo { get; set; } = "";
    public string DeviceName { get; set; } = "";
    public string WaiterName { get; set; } = "";
    public DateTime HeldDate { get; set; }
    public decimal Amount { get; set; }
    public string HeldBy { get; set; } = "";
}

public class RoomDiscrepancyRow
{
    public int Id { get; set; }
    public string Room { get; set; } = "";
    public string SystemStatus { get; set; } = "";
    public string HousekeepingStatus { get; set; } = "";
    public DateTime ReportedDate { get; set; }
    public string Remark { get; set; } = "";
}

public class BucketCheckRow
{
    public int Id { get; set; }
    public int Sn { get; set; }
    public string RegNo { get; set; } = "";
    public string Room { get; set; } = "";
    public string Guest { get; set; } = "";
    public string Company { get; set; } = "";
    public DateTime Arrival { get; set; }
    public DateTime Departure { get; set; }
    public int Adults { get; set; }
    public int Children { get; set; }
    public string RoomType { get; set; } = "";
    public string Currency { get; set; } = "USD";
    public string ActualRtc { get; set; } = "";
    public decimal RateAmount { get; set; }
    public decimal UnitRoomRate { get; set; }
    public decimal Variance => UnitRoomRate - RateAmount;
    public bool Selected { get; set; }
}

public class RoomTaxPostLineItem
{
    public string ArticleCode { get; set; } = "";
    public string Name { get; set; } = "";
    public decimal UnitAmount { get; set; }
    public decimal Quantity { get; set; } = 1;
    public decimal TotalAmount => UnitAmount * Quantity;
}

public class RoomTaxPostRow
{
    public int Id { get; set; }
    public int Sn { get; set; }
    public string RegNo { get; set; } = "";
    public string Guest { get; set; } = "";
    public string Room { get; set; } = "";
    public decimal RoomCharge { get; set; }
    public decimal Tax { get; set; }
    public decimal Amount => LineItems.Sum(l => l.TotalAmount);
    public bool Selected { get; set; } = true;
    public bool IsExpanded { get; set; }
    public List<RoomTaxPostLineItem> LineItems { get; set; } = new();
}

public class ReportArchiveRow
{
    public int Id { get; set; }
    public string ReportName { get; set; } = "";
    public string Description { get; set; } = "";
    public bool Selected { get; set; } = true;
}

public class FolioChargeRow
{
    public int Sn { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = "";
    public string Reference { get; set; } = "";
    public string RoomNo { get; set; } = "";
    public string RoomType { get; set; } = "";
    public string RoomRate { get; set; } = "";
    public int Adults { get; set; }
    public int Children { get; set; }
    public string Remark { get; set; } = "";
    public decimal Charge { get; set; }
    public decimal Payment { get; set; }
}

public class FolioExtraBillRow
{
    public int Sn { get; set; }
    public string RoomNo { get; set; } = "";
    public DateTime Date { get; set; }
    public string InvoiceId { get; set; } = "";
    public decimal ServiceCharge { get; set; }
    public decimal Discount { get; set; }
    public decimal Vat { get; set; }
    public decimal SubTotal { get; set; }
    public string Remark { get; set; } = "";
    public decimal GrandTotal { get; set; }
}

public class FnbOutletSummary
{
    public string Outlet { get; set; } = "";
    public int Covers { get; set; }
    public decimal Revenue { get; set; }
}

public class RevenueJournalLine
{
    public string Account { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
}
