using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GlamTreasures.Data;
using GlamTreasures.Models;

namespace GlamTreasures.Pages.Jewelry
{
    public class CreateModel : PageModel
    {
        private readonly GlamTreasures.Data.GlamTreasuresContext _context;

        public CreateModel(GlamTreasures.Data.GlamTreasuresContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JewelryItem JewelryItem { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.JewelryItem.Add(JewelryItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
