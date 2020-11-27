using PShopSolution.ViewModels.Common;
using PShopSolution.ViewModels.System.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pShopSolution.AdminApp.Services
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVm>>> GetAll();
    }
}