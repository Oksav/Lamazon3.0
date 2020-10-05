using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addingAdminUserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f044b6b8-6247-4c19-b5de-ebb1b1fdbe97", "ab733697-98dc-4273-a39b-2a13cd22e241", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd62e17d-4b5e-4cc7-81a7-a6780fe4d392", "5d06e2a8-a8f3-4894-9fa9-c52ab39689a8", "customer", "CUSTOMER" });
        }
    }
}
