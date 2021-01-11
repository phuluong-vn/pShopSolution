using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using pShopSolution.ApiIntergration;
using PShopSolution.ViewModels.Common;
using PShopSolution.ViewModels.System.Users;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace pShopSolution.AdminApp.Services
{
    public class UserApiClient : BaseApiClient, IUserApiClient
    {


        public UserApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, configuration, httpContextAccessor)
        { }

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await PostAsync<ApiResult<string>>("/api/users/authenticate", httpContent);
        }

        public async Task<ApiResult<UserVm>> GetById(Guid id)
        {
            return await GetAsync<ApiResult<UserVm>>($"/api/Users/{id}");
        }

        public async Task<ApiResult<PageResult<UserVm>>> GetUserPagings(GetUserPagingRequest request)
        {
            return await GetAsync<ApiResult<PageResult<UserVm>>>($"/api/Users/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}&keywork={request.Keywork}");
        }

        public async Task<ApiResult<bool>> RegisterUser(RegisterRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await PostAsync<ApiResult<bool>>("/api/users", httpContent);
        }

        public async Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await PutAsync<ApiResult<bool>>($"/api/users/{id}", httpContent);
        }

        public async Task<ApiResult<bool>> DeleteUser(Guid id)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/users/{id}");
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await AssignRolePutAsync<ApiResult<bool>>($"/api/users/{id}/roles", httpContent);
        }
    }
}