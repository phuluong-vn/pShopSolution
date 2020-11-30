using pShopSolution.AdminApp.Services;
using PShopSolution.ViewModels.System.Languages;
using System.Collections.Generic;

namespace pShopSolution.AdminApp.Models
{
    public class NavigationViewModel
    {
        public List<LanguageVm> Languages { get; set; }
        public string CurrentLanguageId { get; set; }
    }
}