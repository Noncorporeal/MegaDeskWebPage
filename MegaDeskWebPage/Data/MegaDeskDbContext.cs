using MegaDeskWebPage.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaDeskWebPage.Data
{
    public class MegaDeskDbContext : DbContext
    {
        public MegaDeskDbContext(DbContextOptions<MegaDeskDbContext> options)
            : base(options)
        {
        }

        public DbSet<DeliveryOption> DeliveryOptions { get; set; } = default!;
        public DbSet<Desk> Desk { get; set; } = default!;
        public DbSet<DeskMaterial> DeskMaterial { get; set; } = default!;
        public DbSet<Quote> Quote { get; set; } = default!;
    }
}