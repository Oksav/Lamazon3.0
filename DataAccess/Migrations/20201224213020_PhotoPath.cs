using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class PhotoPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "afcca235-0f64-405b-afab-a3b2de99a8a6", "9b3678d3-8207-4b00-a590-e676e6815c5d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "0caa7d28-b700-48c0-b42e-d20b0e725656", "4474c70a-2554-4629-9b12-b03657474983" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4474c70a-2554-4629-9b12-b03657474983", "1e15a9b8-8997-4f96-94bd-3829f18a3029" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0caa7d28-b700-48c0-b42e-d20b0e725656", "d94b55c2-b444-40a8-93a4-eb214c3aa2a0" });

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Products",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c555cd9-237d-482c-82a6-46a2fc6e5600", "8592e49f-8ddb-4582-b389-28f36c5795b4", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8c46af5-7712-4f13-9c9e-3331cd4622c1", "87d6aff3-19d7-47bd-b6a8-38e6135ff52d", "customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4c9860f9-2be1-47d4-b5f6-ff7c495ebc75", 0, "8879730a-750b-442e-9ba2-60a58897d512", "theman@theman.com", true, "TheMan", false, null, "THEMAN@THEMAN.COM", "THEMAN", "AQAAAAEAACcQAAAAEDZxdCBflt80eOtz/CSblfQqYGXv/47glVOb2pVptMO4DK32vCOgS78hUj6tx6DXyQ==", null, false, "", false, "theman" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "4c9860f9-2be1-47d4-b5f6-ff7c495ebc75", "6c555cd9-237d-482c-82a6-46a2fc6e5600" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a8c46af5-7712-4f13-9c9e-3331cd4622c1", "87d6aff3-19d7-47bd-b6a8-38e6135ff52d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4c9860f9-2be1-47d4-b5f6-ff7c495ebc75", "6c555cd9-237d-482c-82a6-46a2fc6e5600" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6c555cd9-237d-482c-82a6-46a2fc6e5600", "8592e49f-8ddb-4582-b389-28f36c5795b4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4c9860f9-2be1-47d4-b5f6-ff7c495ebc75", "8879730a-750b-442e-9ba2-60a58897d512" });

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4474c70a-2554-4629-9b12-b03657474983", "1e15a9b8-8997-4f96-94bd-3829f18a3029", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "afcca235-0f64-405b-afab-a3b2de99a8a6", "9b3678d3-8207-4b00-a590-e676e6815c5d", "customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0caa7d28-b700-48c0-b42e-d20b0e725656", 0, "d94b55c2-b444-40a8-93a4-eb214c3aa2a0", "theman@theman.com", true, "TheMan", false, null, "THEMAN@THEMAN.COM", "THEMAN", "AQAAAAEAACcQAAAAENWj8obTh/0mBHj1Q67QHUlvxWZkTJmZYxNvFyYrXgjG76K5s+IISyZBz6pesLPPrA==", null, false, "", false, "theman" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "0caa7d28-b700-48c0-b42e-d20b0e725656", "4474c70a-2554-4629-9b12-b03657474983" });
        }
    }
}
