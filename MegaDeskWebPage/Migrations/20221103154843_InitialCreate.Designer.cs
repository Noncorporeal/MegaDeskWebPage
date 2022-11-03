﻿// <auto-generated />
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
    [Migration("20221103154843_InitialCreate")]
    partial class InitialCreate
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

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeliveryType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DeliveryOptions");
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
