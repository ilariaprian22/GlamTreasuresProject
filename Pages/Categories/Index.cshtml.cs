using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlamTreasures.Data;
using GlamTreasures.Models;

namespace GlamTreasures.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly GlamTreasuresContext _context;

        public IndexModel(GlamTreasuresContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IList<Category> Categories { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Categories = await _context.Categories.ToListAsync();
            }
        }
    }
}