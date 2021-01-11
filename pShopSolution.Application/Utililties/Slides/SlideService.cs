using Microsoft.EntityFrameworkCore;
using pShopSolution.Data.EF;
using pShopSolution.Data.Enum;
using PShopSolution.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pShopSolution.Application.Utililties.Slides
{
    public class SlideService : ISlideService
    {
        private readonly PShopDbContext _context;

        public SlideService(PShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<SlideVm>> GetAll()
        {
            var result = await _context.Slides.OrderBy(x => x.SortOrder).Select(x => new SlideVm()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Url = x.Url,
                SortOrder = x.SortOrder,
                Image = x.Image
            }).ToListAsync();

            return result;
        }
    }
}