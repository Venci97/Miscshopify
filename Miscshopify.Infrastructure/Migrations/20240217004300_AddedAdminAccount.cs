using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miscshopify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdminAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
