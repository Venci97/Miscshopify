using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miscshopify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PaymentMethodAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e7e030c9-1eab-464f-a78a-cb0281ebddce", "125b4b46-ce64-4c7f-965c-2637843c7b82" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7e030c9-1eab-464f-a78a-cb0281ebddce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "125b4b46-ce64-4c7f-965c-2637843c7b82");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7e030c9-1eab-464f-a78a-cb0281ebddce", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "125b4b46-ce64-4c7f-965c-2637843c7b82", 0, "Admin", "Admin", "ae992a30-5f7b-42c2-8528-ec115384d2a2", new DateTime(2024, 2, 17, 2, 42, 58, 336, DateTimeKind.Local).AddTicks(5160), "admin@admin.com", true, "Admin", 1, "uploads/userImg/userPhoto.png", true, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEOf84Zo+1d9vSeQMjLtIu7F0eTkyLt2zqz38KdN3sR1Ae97AbF4xludz1fUk1hX+tA==", "1234567890", false, "1234", "8b5703ea-d18c-4145-8f7c-088f39ebbe09", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e7e030c9-1eab-464f-a78a-cb0281ebddce", "125b4b46-ce64-4c7f-965c-2637843c7b82" });
        }
    }
}
