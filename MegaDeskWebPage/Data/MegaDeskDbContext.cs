using MegaDeskWebPage.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryOption>()
                .Property(d => d.ShippingTime)
                .HasConversion<long>();
            modelBuilder.Entity<DeliveryOption>()
                .HasData(
                new { Id = 1, DeliveryType = "Three Day", Cost = });
        }
    }
}
