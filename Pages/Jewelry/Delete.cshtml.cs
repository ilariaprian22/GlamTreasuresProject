using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlamTreasures.Data;
using GlamTreasures.Models;

namespace GlamTreasures.Pages.Jewelry
{
    public class DeleteModel : PageModel
    {
        private readonly GlamTreasures.Data.GlamTreasuresContext _context;

        public DeleteModel(GlamTreasures.Data.GlamTreasuresContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JewelryItem JewelryItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jewelryitem = await _context.JewelryItem.FirstOrDefaultAsync(m => m.ID == id);

            if (jewelryitem == null)
            {
                return NotFound();
            }
            else
            {
                JewelryItem = jewelryitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jewelryitem = await _context.JewelryItem.FindAsync(id);
            if (jewelryitem != null)
            {
                JewelryItem = jewelryitem;
                _context.JewelryItem.Remove(JewelryItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
