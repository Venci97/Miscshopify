using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miscshopify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalAmountAndOrderDateToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b4b2e41b-2b51-4bec-9df2-d68c3469f477", "2a91b7c0-26a9-4383-8e4d-25b75b74b6aa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4b2e41b-2b51-4bec-9df2-d68c3469f477");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a91b7c0-26a9-4383-8e4d-25b75b74b6aa");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4b2e41b-2b51-4bec-9df2-d68c3469f477", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a91b7c0-26a9-4383-8e4d-25b75b74b6aa", 0, "Admin", "Admin", "161f1adb-d893-4e49-948d-b82f1f2a61ff", new DateTime(2025, 9, 17, 19, 45, 35, 349, DateTimeKind.Local).AddTicks(385), "admin@admin.com", true, "Admin", 1, "uploads/userImg/userPhoto.png", true, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEIS6VNuTRyQgzAMiCPoY5RLt1c31uP1314xQAq5jTXqo2huTaKlX+A8PMRwnt3GSJg==", "1234567890", false, "1234", "c683d880-50ff-4e0d-bfd0-7532aa77be6f", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b4b2e41b-2b51-4bec-9df2-d68c3469f477", "2a91b7c0-26a9-4383-8e4d-25b75b74b6aa" });
        }
    }
}
