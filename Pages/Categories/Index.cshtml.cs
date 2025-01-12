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
            _context = context;
        }

        public IList<JewelryItem> JewelryItem { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CategoryFilter { get; set; }

        public SelectList? Categories { get; set; }

        public async Task OnGetAsync()
        {
            // Get categories for the dropdown
            IQueryable<string> categoryQuery = from c in _context.Categories
                                               orderby c.Name
                                               select c.Name;

            Categories = new SelectList(await categoryQuery.ToListAsync());

            var jewelryItems = from j in _context.JewelryItems
                             .Include(j => j.Category)
                               select j;

            if (!string.IsNullOrEmpty(SearchString))
            {
                jewelryItems = jewelryItems.Where(j =>
                    j.Name.Contains(SearchString) ||
                    j.Description.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(CategoryFilter))
            {
                jewelryItems = jewelryItems.Where(j =>
                    j.Category.Name == CategoryFilter);
            }

            JewelryItem = await jewelryItems.ToListAsync();
        }
    }
}