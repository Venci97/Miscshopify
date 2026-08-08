using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miscshopify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderShippingAddressFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "725ce2ae-baf3-4d0d-9c8c-de1e9dcc4934", "0b9dcdd8-c912-4315-ad37-c5efe9373fef" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "725ce2ae-baf3-4d0d-9c8c-de1e9dcc4934");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b9dcdd8-c912-4315-ad37-c5efe9373fef");

            migrationBuilder.AddColumn<string>(
                name: "OrderCustomerAddress",
                table: "Orders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderCustomerCity",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderCustomerEmail",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderCustomerPhoneNumber",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderCustomerPostCode",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0e2fa09-34c3-4578-99b2-af07c2607dbd", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "107e99ba-f68e-47d4-88b9-0a8333d9263d", 0, "Admin", "Admin", "4bac99dc-01be-49d0-9e8e-7855d266b8e0", new DateTime(2025, 10, 25, 2, 20, 17, 969, DateTimeKind.Local).AddTicks(6546), "admin@admin.com", true, "Admin", 1, "uploads/userImg/userPhoto.png", true, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEIfcTSYbHcPZC286Y8QiirpzBoVSiYviSW+whf31b3HmnPQH6uqhMegGKbVeVycTrA==", "1234567890", false, "1234", "e9fc9301-c35e-4ad9-827f-588ea822ec50", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e0e2fa09-34c3-4578-99b2-af07c2607dbd", "107e99ba-f68e-47d4-88b9-0a8333d9263d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e0e2fa09-34c3-4578-99b2-af07c2607dbd", "107e99ba-f68e-47d4-88b9-0a8333d9263d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0e2fa09-34c3-4578-99b2-af07c2607dbd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "107e99ba-f68e-47d4-88b9-0a8333d9263d");

            migrationBuilder.DropColumn(
                name: "OrderCustomerAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderCustomerCity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderCustomerEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderCustomerPhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderCustomerPostCode",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "725ce2ae-baf3-4d0d-9c8c-de1e9dcc4934", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0b9dcdd8-c912-4315-ad37-c5efe9373fef", 0, "Admin", "Admin", "bdf75410-b501-4d66-8b1b-9cd407bf653c", new DateTime(2025, 10, 22, 2, 30, 6, 949, DateTimeKind.Local).AddTicks(2973), "admin@admin.com", true, "Admin", 1, "uploads/userImg/userPhoto.png", true, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEBdxMqJ7+Y7AY/1NH45LFm7ciT/it90pIZjiUO5MR2DBZbwX550W8Ptc6gzOjoanew==", "1234567890", false, "1234", "8c6dc4ba-8fd6-4969-928c-d9fd3652e12b", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "725ce2ae-baf3-4d0d-9c8c-de1e9dcc4934", "0b9dcdd8-c912-4315-ad37-c5efe9373fef" });
        }
    }
}
