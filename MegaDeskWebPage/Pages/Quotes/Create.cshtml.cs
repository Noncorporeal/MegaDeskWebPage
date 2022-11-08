using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWebPage.Data;
using MegaDeskWebPage.Models;
using System.Collections.Immutable;

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
            List<string> allDeliveryTypes = (from del in _context.DeliveryOptions
                                       select del.DeliveryType).Distinct().ToList();
                                           
        ViewData["DeliveryOption"] = new SelectList(allDeliveryTypes);
        ViewData["DeskMaterial"] = new SelectList(_context.DeskMaterial, "MaterialName", "MaterialName");
            return Page();
        }

        [BindProperty]
        public Quote Quote { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            const int baseDeskCost = 200;
            const int drawerPrice = 50;
            const int pricePerSqInAbove1000 = 1;

            if (!ModelState.IsValid || _context.Quote == null || Quote == null)
            {
                return Page();
            }

            DeskMaterial deskMaterial = (from dm in _context.DeskMaterial
                                         where dm.MaterialName == Quote.Desk.DeskMaterial.MaterialName
                                         select dm).First();

            Desk newDesk = new()
            {
                Depth = Quote.Desk.Depth,
                Width = Quote.Desk.Width,
                NumberOfDrawers = Quote.Desk.NumberOfDrawers,
                DeskMaterialId = deskMaterial.Id,
                DeskMaterial = deskMaterial
            };

            newDesk = _context.Desk.Add(newDesk).Entity;
            await _context.SaveChangesAsync();

            decimal deskArea = newDesk.Width * newDesk.Depth;

            DeliveryOption deliveryOption = (from del in _context.DeliveryOptions
                                             where del.DeliveryType == Quote.DeliveryOption.DeliveryType
                                             where (int)deskArea >= del.MinSize
                                             orderby del.MinSize descending
                                             select del).First();

            Quote.Price = baseDeskCost
                        + (drawerPrice * newDesk.NumberOfDrawers)
                        + (deskArea > 1000 ? pricePerSqInAbove1000 * (deskArea - 1000) : 0)
                        + deliveryOption.Cost
                        + newDesk.DeskMaterial.Cost;

            Quote.QuoteDate = DateTime.Now;
            Quote.Desk = newDesk;
            Quote.DeliveryOption = deliveryOption;
            Quote.DeskId = newDesk.Id;
            Quote.DeliveryOptionId = deliveryOption.Id;

            _context.Quote.Add(Quote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
