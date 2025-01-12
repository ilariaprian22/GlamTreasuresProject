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

        public IList<JewelryItem> JewelryItems { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedCategory { get; set; }

        public SelectList CategoryList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Get all categories for the dropdown
            var categories = await _context.Categories.ToListAsync();
            CategoryList = new SelectList(categories, "ID", "Name");

            // Start with all jewelry items and include the Category navigation property
            var jewelryQuery = _context.JewelryItem
                .Include(j => j.Category)
                .AsQueryable();

            // Apply search filter if there's a search string
            if (!string.IsNullOrEmpty(SearchString))
            {
                jewelryQuery = jewelryQuery.Where(j =>
                    j.Name.Contains(SearchString) ||
                    j.Description.Contains(SearchString));
            }

            // Apply category filter if a category is selected
            if (SelectedCategory.HasValue && SelectedCategory.Value != 0)
            {
                jewelryQuery = jewelryQuery.Where(j => j.CategoryID == SelectedCategory.Value);
            }

            // Execute the query and get the results
            JewelryItems = await jewelryQuery.ToListAsync();
        }
    }
}