using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlamTreasures.Data;
using GlamTreasures.Models;

namespace GlamTreasures.Pages.Jewelry
{
    public class IndexModel : PageModel
    {
        private readonly GlamTreasuresContext _context;

        public IndexModel(GlamTreasuresContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IList<JewelryItem> JewelryItems { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CategoryFilter { get; set; }

        public SelectList? CategoriesList { get; set; }

        public async Task OnGetAsync()
        {
            // Get categories for the dropdown
            if (_context.Categories != null)
            {
                var categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
                CategoriesList = new SelectList(categories, "ID", "Name");
            }

            var query = _context.JewelryItem.Include(j => j.Category).AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
            {
                query = query.Where(j =>
                    j.Name.Contains(SearchString) ||
                    j.Description.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(CategoryFilter))
            {
                query = query.Where(j => j.Category.Name == CategoryFilter);
            }

            JewelryItems = await query.ToListAsync();
        }
    }
}
