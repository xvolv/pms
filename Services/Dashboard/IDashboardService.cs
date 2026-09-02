using CNET_V7_Domain.Misc;
using CNET_V7_Domain.Misc.PmsDTO;
namespace ERP.V7.WebPMS.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<ResponseModel<PMSDashBoardReport>?> GetPmsDashboardReportAsync(bool forceRefresh = false);
        void InvalidateDashboardCache(int? consigneeUnitId = null);
    }
}
