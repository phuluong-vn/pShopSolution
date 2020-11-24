using PShopSolution.ViewModels.Common;

namespace PShopSolution.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keywork { get; set; }
    }
}