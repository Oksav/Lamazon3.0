using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SeedingProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9240dd18-5d6f-4779-856c-f5556167ec8f", "7cecca2a-0943-446f-8bf6-24005903961c", "admin", "ADMIN" },
                    { "9d42593d-309e-430e-b8b8-2559797060fd", "0adc5467-6313-4f35-b420-62f6e112c041", "suplier", "SUPLIER" },
                    { "1e7116e7-add2-46d1-a431-7928470c98a0", "8f9ee27c-12cb-4700-9aae-e81e7c29519f", "customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 2, "A small tool for removing unwanted hair in unwanted places", "Epilator", 30.0 },
                    { 2, 2, "For IPhone X", "Headphones", 5.0 },
                    { 3, 4, "A board game", "Exploding Kittens", 20.0 },
                    { 4, 1, "A cool drink delivered to your door", "Martini", 10.0 },
                    { 5, 0, "Meat, Salads, Fries", "Hamburger", 5.0 },
                    { 6, 3, "by Gregor Hohpe and Bobby Woolf", "Enterprise Integration Patterns", 50.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1e7116e7-add2-46d1-a431-7928470c98a0", "8f9ee27c-12cb-4700-9aae-e81e7c29519f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9240dd18-5d6f-4779-856c-f5556167ec8f", "7cecca2a-0943-446f-8bf6-24005903961c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9d42593d-309e-430e-b8b8-2559797060fd", "0adc5467-6313-4f35-b420-62f6e112c041" });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
