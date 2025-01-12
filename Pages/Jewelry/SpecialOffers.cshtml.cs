using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlamTreasures.Data;
using GlamTreasures.Models;

namespace GlamTreasures.Pages.Jewelry
{
    public class SpecialOffersModel : PageModel
    {
        private readonly GlamTreasuresContext _context;

        public SpecialOffersModel(GlamTreasuresContext context)
        {
            _context = context;
        }

        public IList<JewelryItem> JewelryItems { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.JewelryItem != null)
            {
                JewelryItems = await _context.JewelryItem
                    .Include(j => j.Category)
                    .Where(j => j.IsSpecialOffer)
                    .ToListAsync();
            }
        }
    }
}