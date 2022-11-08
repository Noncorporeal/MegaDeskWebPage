using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWebPage.Data;
using MegaDeskWebPage.Models;

namespace MegaDeskWebPage.Pages.Quotes
{
    public class DeleteModel : PageModel
    {
        private readonly MegaDeskWebPage.Data.MegaDeskDbContext _context;

        public DeleteModel(MegaDeskWebPage.Data.MegaDeskDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Quote Quote { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Quote == null)
            {
                return NotFound();
            }

            var quote = await _context.Quote
                .Include(q => q.Desk)
                    .ThenInclude(d => d.DeskMaterial)
                .Include(q => q.DeliveryOption)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (quote == null)
            {
                return NotFound();
            }
            else 
            {
                Quote = quote;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Quote == null)
            {
                return NotFound();
            }
            var quote = await _context.Quote.FindAsync(id);
            Desk desk = await _context.Desk.FindAsync(quote.DeskId);

            if (quote != null)
            {
                Quote = quote;
                _context.Quote.Remove(Quote);
                _context.Desk.Remove(desk);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
