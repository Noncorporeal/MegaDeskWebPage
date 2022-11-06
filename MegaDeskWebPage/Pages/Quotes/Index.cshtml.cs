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
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWebPage.Data.MegaDeskDbContext _context;

        public IndexModel(MegaDeskWebPage.Data.MegaDeskDbContext context)
        {
            _context = context;
        }

        public IList<Quote> Quote { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Quote != null)
            {
                Quote = await _context.Quote
                .Include(q => q.DeliveryOption)
                .Include(q => q.Desk).ToListAsync();
            }
        }
    }
}
