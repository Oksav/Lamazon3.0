using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class modelChangesOnOrderProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "079ae52d-f74b-4678-9800-c3019b7fbf5f", "323c7115-1ea5-4372-a6d4-d19cbaf3f563" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "e838f7b5-5bb4-4d82-8d8e-b57fb99d891b", "6db3e339-3883-4677-a79b-d6a37eab8e46" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6db3e339-3883-4677-a79b-d6a37eab8e46", "d10d7069-5601-4470-8ae4-8e5f334e6936" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e838f7b5-5bb4-4d82-8d8e-b57fb99d891b", "c97d160a-295c-403d-889e-25483cdc9c3a" });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderProducts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_OrderProducts_Id",
                table: "OrderProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                columns: new[] { "ProductId", "OrderId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62ce939b-32ca-422f-ab1c-22f92cb51392", "d4d39181-7fa8-43bd-b68a-07f5cb79767f", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9de1af93-4494-417d-a139-343d883fac2b", "b033145c-a0ed-4709-90f5-843560ba540c", "customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7291392a-65f5-41e0-99ae-22288f10902f", 0, "d44bbd66-8d55-4760-b34d-cc1d569a4b87", "theman@theman.com", true, "TheMan", false, null, "THEMAN@THEMAN.COM", "THEMAN", "AQAAAAEAACcQAAAAEB1elZZ+fX9LXOeVvC/pTTg1wbtIwBFM7QDqySlPLt7URxIHF15B0EB7qsCcwQ1F+A==", null, false, "", false, "theman" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "7291392a-65f5-41e0-99ae-22288f10902f", "62ce939b-32ca-422f-ab1c-22f92cb51392" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_OrderProducts_Id",
                table: "OrderProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9de1af93-4494-417d-a139-343d883fac2b", "b033145c-a0ed-4709-90f5-843560ba540c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "7291392a-65f5-41e0-99ae-22288f10902f", "62ce939b-32ca-422f-ab1c-22f92cb51392" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "62ce939b-32ca-422f-ab1c-22f92cb51392", "d4d39181-7fa8-43bd-b68a-07f5cb79767f" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "7291392a-65f5-41e0-99ae-22288f10902f", "d44bbd66-8d55-4760-b34d-cc1d569a4b87" });

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6db3e339-3883-4677-a79b-d6a37eab8e46", "d10d7069-5601-4470-8ae4-8e5f334e6936", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "079ae52d-f74b-4678-9800-c3019b7fbf5f", "323c7115-1ea5-4372-a6d4-d19cbaf3f563", "customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e838f7b5-5bb4-4d82-8d8e-b57fb99d891b", 0, "c97d160a-295c-403d-889e-25483cdc9c3a", "theman@theman.com", true, "TheMan", false, null, "THEMAN@THEMAN.COM", "THEMAN", "AQAAAAEAACcQAAAAEFdyHey/mcR0QrkFTTxV0zzjspYQ5nalBQmaks1Qc0zW1fxjD3cwHG0J9T2hJ8MRFQ==", null, false, "", false, "theman" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "e838f7b5-5bb4-4d82-8d8e-b57fb99d891b", "6db3e339-3883-4677-a79b-d6a37eab8e46" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");
        }
    }
}
