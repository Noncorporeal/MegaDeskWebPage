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
        private readonly MegaDeskDbContext _context;

        public IndexModel(MegaDeskDbContext context)
        {
            _context = context;
        }

        public IList<Quote> Quote { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchName { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Quote != null)
            {
                Quote = (from q in _context.Quote
                         select q)
                         .Include(a => a.Desk)
                            .ThenInclude(c => c.DeskMaterial)
                         .Include(a => a.DeliveryOption)
                         .ToList();

                if (!string.IsNullOrEmpty(SearchName))
                {
                    Quote = (from q in Quote
                             where q.CustomerName == SearchName
                             select q).ToList();
                }
            }
        }
    }
}
