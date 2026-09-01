using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CNET_V7_Domain.Domain.SettingSchema;
using CNET_V7_Domain.Domain.ViewSchema;

namespace ERP.V7.WebPMS.Services.DocumentBrowser
{
    public class ConsigneeFilterCriteria
    {
        public int GslType { get; set; } = 27; // 27 = Guest, 30 = Contact, 28 = Company, 31 = Agent, 41 = Group, 42 = Source
        public int FieldFormatType { get; set; } = 1617;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? ConsigneeCode { get; set; }
        public int? ChildPreferenceId { get; set; }
        public int? ObjectStateId { get; set; }
    }

    public class TransactionFilterCriteria
    {
        public int DefinitionId { get; set; } = 197; // 197 = Cash Receipt, 111 = Credit Sales, 106 = Cash Sales, etc.
        public int FieldFormatType { get; set; } = 1617;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? VoucherCode { get; set; }
    }

    public interface IDocumentBrowserService
    {
        Task<DateTime?> GetServerTimeAsync(bool forceRefresh = false);
        Task<List<FieldFormatDTO>> GetFieldFormatsAsync(int referenceId, bool forceRefresh = false);
        Task<List<PreferenceDTO>> GetPreferencesAsync(int systemConstantId, bool forceRefresh = false);
        Task<List<SystemConstantDTO>> GetObjectStatesAsync(string type = "ObjectState Definition", string category = "Article", bool forceRefresh = false);
        Task<List<VwConsigneeViewDTO>> GetConsigneeHeaderFormattedViewAsync(ConsigneeFilterCriteria filter, bool forceRefresh = false);
        Task<List<VwVoucherHeaderDTO>> GetVoucherHeaderFormattedViewAsync(TransactionFilterCriteria filter, bool forceRefresh = false);
        void InvalidateConsigneeCache(int? gslType = null);
        void InvalidateVoucherCache(int? definitionId = null);
        void ClearCache();
    }
}
