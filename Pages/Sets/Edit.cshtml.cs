﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlamTreasures.Data;
using GlamTreasures.Models;

namespace GlamTreasures.Pages.Sets
{
    public class EditModel : PageModel
    {
        private readonly GlamTreasures.Data.GlamTreasuresContext _context;

        public EditModel(GlamTreasures.Data.GlamTreasuresContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Set Set { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var set =  await _context.Set.FirstOrDefaultAsync(m => m.ID == id);
            if (set == null)
            {
                return NotFound();
            }
            Set = set;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Set).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetExists(Set.ID))
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

        private bool SetExists(int id)
        {
            return _context.Set.Any(e => e.ID == id);
        }
    }
}
