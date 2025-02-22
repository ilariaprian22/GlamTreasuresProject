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
    public class IndexModel : PageModel
    {
        private readonly GlamTreasures.Data.GlamTreasuresContext _context;

        public IndexModel(GlamTreasures.Data.GlamTreasuresContext context)
        {
            _context = context;
        }

        public IList<Set> Set { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Set = await _context.Set.ToListAsync();
        }
    }
}
