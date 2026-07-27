using System.Threading.Tasks;
using CNET_V7_Domain.Misc;

namespace ERP.V7.WebPMS.Services
{
    public interface IApiService
    {
        Task<CNET_V7_Domain.Misc.ResponseModel<SystemInitDTO>?> InitializeSystemAsync(string tin);
        Task<CNET_V7_Domain.Misc.ResponseModel<LoginResponse>?> AuthenticateAsync(string username, string password, string tin, string branchId);
    }
}
