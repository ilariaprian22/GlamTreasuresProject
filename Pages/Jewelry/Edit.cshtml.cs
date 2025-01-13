using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlamTreasures.Data;
using GlamTreasures.Models;

namespace GlamTreasures.Pages.Jewelry
{
    public class EditModel : PageModel
    {
        private readonly GlamTreasuresContext _context;

        public EditModel(GlamTreasuresContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JewelryItem JewelryItem { get; set; } = default!;

        public SelectList CategoryList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jewelryitem = await _context.JewelryItem
                .FirstOrDefaultAsync(m => m.ID == id);

            if (jewelryitem == null)
            {
                return NotFound();
            }

            JewelryItem = jewelryitem;
            CategoryList = new SelectList(_context.Categories, "ID", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CategoryList = new SelectList(_context.Categories, "ID", "Name");
                return Page();
            }

            _context.Attach(JewelryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JewelryItemExists(JewelryItem.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JewelryItemExists(int id)
        {
            return _context.JewelryItem.Any(e => e.ID == id);
        }
    }
}