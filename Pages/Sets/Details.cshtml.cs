using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlamTreasures.Data;
using GlamTreasures.Models;

namespace GlamTreasures.Pages.Sets
{
    public class DetailsModel : PageModel
    {
        private readonly GlamTreasures.Data.GlamTreasuresContext _context;

        public DetailsModel(GlamTreasures.Data.GlamTreasuresContext context)
        {
            _context = context;
        }

        public Set Set { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var set = await _context.Set.FirstOrDefaultAsync(m => m.ID == id);
            if (set == null)
            {
                return NotFound();
            }
            else
            {
                Set = set;
            }
            return Page();
        }
    }
}
