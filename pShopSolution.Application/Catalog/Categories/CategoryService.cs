using pShopSolution.Data.EF;
using PShopSolution.ViewModels.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using pShopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace pShopSolution.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly PShopDbContext _context;

        public CategoryService(PShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        //join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        //join c in _context.Categories on pic.CategoryId equals c.Id
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).ToListAsync();
        }
    }
}