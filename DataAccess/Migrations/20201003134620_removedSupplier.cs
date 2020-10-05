using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class removedSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f044b6b8-6247-4c19-b5de-ebb1b1fdbe97", "ab733697-98dc-4273-a39b-2a13cd22e241", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd62e17d-4b5e-4cc7-81a7-a6780fe4d392", "5d06e2a8-a8f3-4894-9fa9-c52ab39689a8", "customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "bd62e17d-4b5e-4cc7-81a7-a6780fe4d392", "5d06e2a8-a8f3-4894-9fa9-c52ab39689a8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f044b6b8-6247-4c19-b5de-ebb1b1fdbe97", "ab733697-98dc-4273-a39b-2a13cd22e241" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9240dd18-5d6f-4779-856c-f5556167ec8f", "7cecca2a-0943-446f-8bf6-24005903961c", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d42593d-309e-430e-b8b8-2559797060fd", "0adc5467-6313-4f35-b420-62f6e112c041", "suplier", "SUPLIER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e7116e7-add2-46d1-a431-7928470c98a0", "8f9ee27c-12cb-4700-9aae-e81e7c29519f", "customer", "CUSTOMER" });
        }
    }
}
