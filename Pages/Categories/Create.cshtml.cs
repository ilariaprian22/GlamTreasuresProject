using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GlamTreasures.Models;
using GlamTreasures.Data;

namespace GlamTreasures.Pages.Categories
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
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Category created successfully!";
            return RedirectToPage("./Index");
        }
    }
}