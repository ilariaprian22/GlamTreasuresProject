using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GlamTreasures.Data;
using GlamTreasures.Models;

namespace GlamTreasures.Pages.Jewelry
{
    public class CreateModel : PageModel
    {
        private readonly GlamTreasuresContext _context;

        public CreateModel(GlamTreasuresContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Load categories for dropdown
            CategoryList = new SelectList(_context.Categories, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public JewelryItem JewelryItem { get; set; } = default!;

        public SelectList CategoryList { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CategoryList = new SelectList(_context.Categories, "ID", "Name");
                return Page();
            }

            // Set the creation date
            JewelryItem.DateAdded = DateTime.Now;

            _context.JewelryItem.Add(JewelryItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}