using PShopSolution.ViewModels.System.Users;
using System.Threading.Tasks;

namespace pShopSolution.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}