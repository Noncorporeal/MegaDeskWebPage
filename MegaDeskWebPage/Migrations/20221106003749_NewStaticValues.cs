using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDeskWebPage.Migrations
{
    public partial class NewStaticValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DeliveryOptions",
                columns: new[] { "Id", "Cost", "DeliveryType", "MinSize", "ShippingTime" },
                values: new object[] { 1, 60m, "Three Day", 0, 2592000000000L });

            migrationBuilder.InsertData(
                table: "DeliveryOptions",
                columns: new[] { "Id", "Cost", "DeliveryType", "MinSize", "ShippingTime" },
                values: new object[] { 2, 70m, "Three Day", 1000, 2592000000000L });

            migrationBuilder.InsertData(
                table: "DeliveryOptions",
                columns: new[] { "Id", "Cost", "DeliveryType", "MinSize", "ShippingTime" },
                values: new object[] { 3, 80m, "Three Day", 2000, 2592000000000L });

            migrationBuilder.InsertData(
                table: "DeliveryOptions",
                columns: new[] { "Id", "Cost", "DeliveryType", "MinSize", "ShippingTime" },
                values: new object[] { 4, 40m, "Five Day", 0, 4320000000000L });

            migrationBuilder.InsertData(
                table: "DeliveryOptions",
                columns: new[] { "Id", "Cost", "DeliveryType", "MinSize", "ShippingTime" },
                values: new object[] { 5, 50m, "Five Day", 1000, 4320000000000L });

            migrationBuilder.InsertData(
                table: "DeliveryOptions",
                columns: new[] { "Id", "Cost", "DeliveryType", "MinSize", "ShippingTime" },
                values: new object[] { 6, 60m, "Five Day", 2000, 4320000000000L });

            migrationBuilder.InsertData(
                table: "DeliveryOptions",
                columns: new[] { "Id", "Cost", "DeliveryType", "MinSize", "ShippingTime" },
                values: new object[] { 7, 30m, "Seven Day", 0, 6048000000000L });

            migrationBuilder.InsertData(
                table: "DeliveryOptions",
                columns: new[] { "Id", "Cost", "DeliveryType", "MinSize", "ShippingTime" },
                values: new object[] { 8, 35m, "Seven Day", 1000, 6048000000000L });

            migrationBuilder.InsertData(
                table: "DeliveryOptions",
                columns: new[] { "Id", "Cost", "DeliveryType", "MinSize", "ShippingTime" },
                values: new object[] { 9, 40m, "Seven Day", 2000, 6048000000000L });

            migrationBuilder.InsertData(
                table: "DeliveryOptions",
                columns: new[] { "Id", "Cost", "DeliveryType", "MinSize", "ShippingTime" },
                values: new object[] { 10, 0m, "Fourteen Day", 0, 12096000000000L });

            migrationBuilder.InsertData(
                table: "DeskMaterial",
                columns: new[] { "Id", "Cost", "MaterialName" },
                values: new object[] { 1, 200m, "Oak" });

            migrationBuilder.InsertData(
                table: "DeskMaterial",
                columns: new[] { "Id", "Cost", "MaterialName" },
                values: new object[] { 2, 100m, "Laminate" });

            migrationBuilder.InsertData(
                table: "DeskMaterial",
                columns: new[] { "Id", "Cost", "MaterialName" },
                values: new object[] { 3, 50m, "Pine" });

            migrationBuilder.InsertData(
                table: "DeskMaterial",
                columns: new[] { "Id", "Cost", "MaterialName" },
                values: new object[] { 4, 300m, "Rosewood" });

            migrationBuilder.InsertData(
                table: "DeskMaterial",
                columns: new[] { "Id", "Cost", "MaterialName" },
                values: new object[] { 5, 125m, "Veneer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryOptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeliveryOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeliveryOptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DeliveryOptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DeliveryOptions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DeliveryOptions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DeliveryOptions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DeliveryOptions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DeliveryOptions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DeliveryOptions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DeskMaterial",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeskMaterial",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeskMaterial",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DeskMaterial",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DeskMaterial",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
