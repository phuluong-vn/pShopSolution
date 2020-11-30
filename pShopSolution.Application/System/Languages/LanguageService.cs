using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using pShopSolution.Data.EF;
using PShopSolution.ViewModels.Common;
using PShopSolution.ViewModels.System.Languages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pShopSolution.Application.System.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IConfiguration _config;
        private readonly PShopDbContext _context;

        public LanguageService(IConfiguration config, PShopDbContext context)
        {
            _config = config;
            _context = context;
        }

        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageVm()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return new ApiSuccessResult<List<LanguageVm>>(languages);
        }
    }
}