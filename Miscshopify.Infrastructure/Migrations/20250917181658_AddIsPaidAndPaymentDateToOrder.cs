using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miscshopify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsPaidAndPaymentDateToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6608f09f-5112-4e35-8451-07bf78b97af5", "87a3d0b8-01be-488f-a903-2e424de4b10b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6608f09f-5112-4e35-8451-07bf78b97af5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87a3d0b8-01be-488f-a903-2e424de4b10b");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8273e97e-69ef-48fe-96b6-d8af28567bf3", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b8f8ca3e-0288-4005-88a8-5ecc4d24429c", 0, "Admin", "Admin", "27a4c061-2ecd-4c4b-b1a0-16441ea63eb9", new DateTime(2025, 9, 17, 19, 16, 57, 437, DateTimeKind.Local).AddTicks(9181), "admin@admin.com", true, "Admin", 1, "uploads/userImg/userPhoto.png", true, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEO3d6rqOqOtZIAq1NQD/32rp8mRWPtHDzIHkByk7n1TFiUPN4kwbt9oAy6pAam+ESQ==", "1234567890", false, "1234", "1e5a13ec-d1e4-4b47-bc56-4ab8c2243fd4", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8273e97e-69ef-48fe-96b6-d8af28567bf3", "b8f8ca3e-0288-4005-88a8-5ecc4d24429c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8273e97e-69ef-48fe-96b6-d8af28567bf3", "b8f8ca3e-0288-4005-88a8-5ecc4d24429c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8273e97e-69ef-48fe-96b6-d8af28567bf3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8f8ca3e-0288-4005-88a8-5ecc4d24429c");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6608f09f-5112-4e35-8451-07bf78b97af5", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "87a3d0b8-01be-488f-a903-2e424de4b10b", 0, "Admin", "Admin", "9df58699-55da-478f-9752-a89a5f195c86", new DateTime(2024, 6, 12, 18, 55, 38, 369, DateTimeKind.Local).AddTicks(7828), "admin@admin.com", true, "Admin", 1, "uploads/userImg/userPhoto.png", true, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEMdauLlame1rJ5wIHi7nwmKWBRH1Gkyp0LA+BYPzwdZYbfJzhfdR408GnJvjSr4Ibg==", "1234567890", false, "1234", "09efc767-4ea2-4001-b66e-90c7796cd424", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6608f09f-5112-4e35-8451-07bf78b97af5", "87a3d0b8-01be-488f-a903-2e424de4b10b" });
        }
    }
}
