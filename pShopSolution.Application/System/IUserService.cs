using PShopSolution.ViewModels.System.Users;
using System.Threading.Tasks;

namespace pShopSolution.Application.System
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);
    }
}