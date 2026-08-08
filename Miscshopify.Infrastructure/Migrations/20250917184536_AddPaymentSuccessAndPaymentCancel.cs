using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miscshopify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentSuccessAndPaymentCancel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
