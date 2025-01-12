﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly GlamTreasures.Data.GlamTreasuresContext _context;

        public IndexModel(GlamTreasures.Data.GlamTreasuresContext context)
        {
            _context = context;
        }

        public IList<JewelryItem> JewelryItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            JewelryItem = await _context.JewelryItem.ToListAsync();
        }
    }
}
