using PShopSolution.ViewModels.Common;
using PShopSolution.ViewModels.System.Users;
using System;
using System.Threading.Tasks;

namespace pShopSolution.Application.System.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<UserVm>> GetById(Guid id);

        Task<ApiResult<PageResult<UserVm>>> GetUserPaging(GetUserPagingRequest request);
    }
}