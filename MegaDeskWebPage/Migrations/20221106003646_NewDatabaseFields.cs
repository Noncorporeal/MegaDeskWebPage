using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDeskWebPage.Migrations
{
    public partial class NewDatabaseFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "DeliveryOptions");

            migrationBuilder.AddColumn<int>(
                name: "MinSize",
                table: "DeliveryOptions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ShippingTime",
                table: "DeliveryOptions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinSize",
                table: "DeliveryOptions");

            migrationBuilder.DropColumn(
                name: "ShippingTime",
                table: "DeliveryOptions");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "DeliveryOptions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
