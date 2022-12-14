// <auto-generated />
using System;
using MegaDeskWebPage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MegaDeskWebPage.Migrations
{
    [DbContext(typeof(MegaDeskDbContext))]
    [Migration("20221106003749_NewStaticValues")]
    partial class NewStaticValues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("MegaDeskWebPage.Models.DeliveryOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("DeliveryType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("MinSize")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ShippingTime")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DeliveryOptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 60m,
                            DeliveryType = "Three Day",
                            MinSize = 0,
                            ShippingTime = 2592000000000L
                        },
                        new
                        {
                            Id = 2,
                            Cost = 70m,
                            DeliveryType = "Three Day",
                            MinSize = 1000,
                            ShippingTime = 2592000000000L
                        },
                        new
                        {
                            Id = 3,
                            Cost = 80m,
                            DeliveryType = "Three Day",
                            MinSize = 2000,
                            ShippingTime = 2592000000000L
                        },
                        new
                        {
                            Id = 4,
                            Cost = 40m,
                            DeliveryType = "Five Day",
                            MinSize = 0,
                            ShippingTime = 4320000000000L
                        },
                        new
                        {
                            Id = 5,
                            Cost = 50m,
                            DeliveryType = "Five Day",
                            MinSize = 1000,
                            ShippingTime = 4320000000000L
                        },
                        new
                        {
                            Id = 6,
                            Cost = 60m,
                            DeliveryType = "Five Day",
                            MinSize = 2000,
                            ShippingTime = 4320000000000L
                        },
                        new
                        {
                            Id = 7,
                            Cost = 30m,
                            DeliveryType = "Seven Day",
                            MinSize = 0,
                            ShippingTime = 6048000000000L
                        },
                        new
                        {
                            Id = 8,
                            Cost = 35m,
                            DeliveryType = "Seven Day",
                            MinSize = 1000,
                            ShippingTime = 6048000000000L
                        },
                        new
                        {
                            Id = 9,
                            Cost = 40m,
                            DeliveryType = "Seven Day",
                            MinSize = 2000,
                            ShippingTime = 6048000000000L
                        },
                        new
                        {
                            Id = 10,
                            Cost = 0m,
                            DeliveryType = "Fourteen Day",
                            MinSize = 0,
                            ShippingTime = 12096000000000L
                        });
                });

            modelBuilder.Entity("MegaDeskWebPage.Models.Desk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Depth")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeskMaterialId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfDrawers")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Width")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeskMaterialId");

                    b.ToTable("Desk");
                });

            modelBuilder.Entity("MegaDeskWebPage.Models.DeskMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DeskMaterial");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 200m,
                            MaterialName = "Oak"
                        },
                        new
                        {
                            Id = 2,
                            Cost = 100m,
                            MaterialName = "Laminate"
                        },
                        new
                        {
                            Id = 3,
                            Cost = 50m,
                            MaterialName = "Pine"
                        },
                        new
                        {
                            Id = 4,
                            Cost = 300m,
                            MaterialName = "Rosewood"
                        },
                        new
                        {
                            Id = 5,
                            Cost = 125m,
                            MaterialName = "Veneer"
                        });
                });

            modelBuilder.Entity("MegaDeskWebPage.Models.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DeliveryOptionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeskId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("QuoteDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryOptionId");

                    b.HasIndex("DeskId");

                    b.ToTable("Quote");
                });

            modelBuilder.Entity("MegaDeskWebPage.Models.Desk", b =>
                {
                    b.HasOne("MegaDeskWebPage.Models.DeskMaterial", "DeskMaterial")
                        .WithMany()
                        .HasForeignKey("DeskMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeskMaterial");
                });

            modelBuilder.Entity("MegaDeskWebPage.Models.Quote", b =>
                {
                    b.HasOne("MegaDeskWebPage.Models.DeliveryOption", "DeliveryOption")
                        .WithMany()
                        .HasForeignKey("DeliveryOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaDeskWebPage.Models.Desk", "Desk")
                        .WithMany()
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryOption");

                    b.Navigation("Desk");
                });
#pragma warning restore 612, 618
        }
    }
}
