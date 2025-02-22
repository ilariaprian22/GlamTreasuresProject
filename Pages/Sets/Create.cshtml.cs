using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GlamTreasures.Data;
using GlamTreasures.Models;

namespace GlamTreasures.Pages.Sets
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
        public Set Set { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Set.Add(Set);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
