using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWebPage.Data;
using MegaDeskWebPage.Models;

namespace MegaDeskWebPage.Pages.Quotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWebPage.Data.MegaDeskDbContext _context;

        public CreateModel(MegaDeskWebPage.Data.MegaDeskDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeliveryOptionId"] = new SelectList(_context.DeliveryOptions, "Id", "Id");
        ViewData["DeskId"] = new SelectList(_context.Desk, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Quote Quote { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Quote == null || Quote == null)
            {
                return Page();
            }

            _context.Quote.Add(Quote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
