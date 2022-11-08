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
                    new { Id = 1, DeliveryType = "Three Day", Cost = 60m, ShippingTime = TimeSpan.FromDays(3), MinSize = 0},
                    new { Id = 2, DeliveryType = "Three Day", Cost = 70m, ShippingTime = TimeSpan.FromDays(3), MinSize = 1000},
                    new { Id = 3, DeliveryType = "Three Day", Cost = 80m, ShippingTime = TimeSpan.FromDays(3), MinSize = 2000},
                    new { Id = 4, DeliveryType = "Five Day", Cost = 40m, ShippingTime = TimeSpan.FromDays(5), MinSize = 0},
                    new { Id = 5, DeliveryType = "Five Day", Cost = 50m, ShippingTime = TimeSpan.FromDays(5), MinSize = 1000},
                    new { Id = 6, DeliveryType = "Five Day", Cost = 60m, ShippingTime = TimeSpan.FromDays(5), MinSize = 2000},
                    new { Id = 7, DeliveryType = "Seven Day", Cost = 30m, ShippingTime = TimeSpan.FromDays(7), MinSize = 0},
                    new { Id = 8, DeliveryType = "Seven Day", Cost = 35m, ShippingTime = TimeSpan.FromDays(7), MinSize = 1000},
                    new { Id = 9, DeliveryType = "Seven Day", Cost = 40m, ShippingTime = TimeSpan.FromDays(7), MinSize = 2000},
                    new { Id = 10, DeliveryType = "Fourteen Day", Cost = 0m, ShippingTime = TimeSpan.FromDays(14), MinSize = 0}
                );
            modelBuilder.Entity<DeskMaterial>()
                .HasData(
                    new { Id = 1, MaterialName = "Oak", Cost = 200m},
                    new { Id = 2, MaterialName = "Laminate", Cost = 100m},
                    new { Id = 3, MaterialName = "Pine", Cost = 50m},
                    new { Id = 4, MaterialName = "Rosewood", Cost = 300m},
                    new { Id = 5, MaterialName = "Veneer", Cost = 125m}
                );
            
        }
    }
}