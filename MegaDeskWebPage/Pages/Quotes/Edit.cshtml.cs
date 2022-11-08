using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWebPage.Data;
using MegaDeskWebPage.Models;

namespace MegaDeskWebPage.Pages.Quotes
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskWebPage.Data.MegaDeskDbContext _context;

        public EditModel(MegaDeskWebPage.Data.MegaDeskDbContext context)
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
                            .Include(m => m.Desk)
                                .ThenInclude(d => d.DeskMaterial)
                            .Include(m => m.DeliveryOption)
                            .FirstOrDefaultAsync(m => m.Id == id)
                ;
            if (quote == null)
            {
                return NotFound();
            }
            Quote = quote;

            List<string> allDeliveryTypes = (from del in _context.DeliveryOptions
                                             select del.DeliveryType).Distinct().ToList();

            ViewData["DeliveryOption"] = new SelectList(allDeliveryTypes);
            ViewData["DeskMaterial"] = new SelectList(_context.DeskMaterial, "MaterialName", "MaterialName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            const int baseDeskCost = 200;
            const int drawerPrice = 50;
            const int pricePerSqInAbove1000 = 1;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Desk dbDesk = (from d in _context.Desk
                               where d.Id == Quote.Desk.Id
                               select d)
                           .Include(m => m.DeskMaterial)
                           .First();
                DeskMaterial dbMaterial = (from dm in _context.DeskMaterial
                                           where dm.MaterialName == Quote.Desk.DeskMaterial.MaterialName
                                           select dm).First();

                dbDesk.Width = Quote.Desk.Width;
                dbDesk.Depth = Quote.Desk.Depth;
                dbDesk.NumberOfDrawers = Quote.Desk.NumberOfDrawers;
                dbDesk.DeskMaterial = dbMaterial;
                dbDesk.DeskMaterialId = dbMaterial.Id;

                _context.Update(dbDesk);
                await _context.SaveChangesAsync();

                Quote.Desk = dbDesk;
                Quote.DeskId = dbDesk.Id;

                decimal deskArea = dbDesk.Width * dbDesk.Depth;

                DeliveryOption dbDeliveryOption = (from del in _context.DeliveryOptions
                                                   where del.DeliveryType == Quote.DeliveryOption.DeliveryType
                                                   where (int)deskArea >= del.MinSize
                                                   orderby del.MinSize descending
                                                   select del).First();

                Quote.Price = baseDeskCost
                            + (drawerPrice * dbDesk.NumberOfDrawers)
                            + (deskArea > 1000 ? pricePerSqInAbove1000 * (deskArea - 1000) : 0)
                            + dbDeliveryOption.Cost
                            + dbDesk.DeskMaterial.Cost;

                Quote.DeliveryOption = dbDeliveryOption;
                Quote.DeliveryOptionId = dbDeliveryOption.Id;

                _context.Update(Quote);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(Quote.Id))
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

        private bool QuoteExists(int id)
        {
            return (_context.Quote?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
