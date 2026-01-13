using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediaMarktProjectApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6050e3c9-5b15-406f-a9a5-077e64da2cff"), "Consolas" },
                    { new Guid("a11111e9-2ba9-473a-a40f-e38cb54f9b35"), "Hogar" },
                    { new Guid("bee061d2-d289-4ab3-b012-4aa4e30457cb"), "Telefonía" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Televisión" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0eae58f4-0066-4d45-8537-bb71a9afcd62"), new Guid("6050e3c9-5b15-406f-a9a5-077e64da2cff"), "Switch 2 256GB en color negro, azul y rojo Neón", "Switch 2 256GB + MarioBROS", 509m },
                    { new Guid("2094c4a2-4f10-454c-a1ef-711b92b807c2"), new Guid("a11111e9-2ba9-473a-a40f-e38cb54f9b35"), "Bombilla LED de larga duración con más de 20.000 horas.", "Bombilla luz LED 20W White", 21.99m },
                    { new Guid("2fab0ea9-2321-439d-bef1-10b6e24720ff"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "60 pulgadas OLED", "Televisor 4K Samsung QLED", 499.99m },
                    { new Guid("2feb7bd9-c759-479a-aa7c-55787034cc68"), new Guid("bee061d2-d289-4ab3-b012-4aa4e30457cb"), "El Samsung Galaxy A56 5G es un dispositivo potente y equilibrado que ofrece un excelente rendimiento, conectividad avanzada y una experiencia visual envolvente. Con un procesador Exynos 1580", "Samsung Galaxy A56 5G, 8GB RAM", 509m },
                    { new Guid("48297667-adcf-49f6-9dc9-ee6331744c1f"), new Guid("6050e3c9-5b15-406f-a9a5-077e64da2cff"), "Playstation 5 con 1 mando incluido, color blanco", "PS5 Slim", 499m },
                    { new Guid("b741490a-5240-4428-a55e-1b970c07992f"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "65 pulgadas OLED", "Televisor 4K LG LED", 699.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0eae58f4-0066-4d45-8537-bb71a9afcd62"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2094c4a2-4f10-454c-a1ef-711b92b807c2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2fab0ea9-2321-439d-bef1-10b6e24720ff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2feb7bd9-c759-479a-aa7c-55787034cc68"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48297667-adcf-49f6-9dc9-ee6331744c1f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b741490a-5240-4428-a55e-1b970c07992f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6050e3c9-5b15-406f-a9a5-077e64da2cff"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a11111e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bee061d2-d289-4ab3-b012-4aa4e30457cb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));
        }
    }
}
