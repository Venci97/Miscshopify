using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miscshopify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductCreationTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "582490e1-db7b-4136-830a-ed1745e9a664", "f7db165c-f97a-46a4-9c19-359e81d356ec" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "582490e1-db7b-4136-830a-ed1745e9a664");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7db165c-f97a-46a4-9c19-359e81d356ec");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1086ab2-d369-4d5b-bf66-d45604de8d18", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9597d865-b92e-4e33-ad1e-610090fc8487", 0, "Admin", "Admin", "a903a54f-961e-46ec-a03a-36489c1bf563", new DateTime(2025, 11, 6, 13, 34, 8, 882, DateTimeKind.Local).AddTicks(4821), "admin@admin.com", true, "Admin", 1, "uploads/userImg/userPhoto.png", true, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEAUxBKL6KLiT6jqJSnLOJGCpz/JxUDvxuJnpvxyFsLh7lfQbzmvCOwP1MfDbo/jnlA==", "1234567890", false, "1234", "ccd0fa6f-45a2-4abf-a650-30426e0271f9", false, "admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b188390-8db6-4783-135b-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 6, 11, 34, 8, 878, DateTimeKind.Utc).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("56532f98-112b-474a-1361-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 6, 11, 34, 8, 878, DateTimeKind.Utc).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5709db41-e129-490b-135e-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 6, 11, 34, 8, 878, DateTimeKind.Utc).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6468f6ad-5de5-4a34-1362-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 6, 11, 34, 8, 878, DateTimeKind.Utc).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8355a0dd-a683-42ae-135f-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 6, 11, 34, 8, 878, DateTimeKind.Utc).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8747cde3-f434-45ee-389f-08dadfe174ee"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 6, 11, 34, 8, 878, DateTimeKind.Utc).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9086399c-0be5-42ff-135c-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 6, 11, 34, 8, 878, DateTimeKind.Utc).AddTicks(8636));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ab40e33a-24d3-47d4-b570-08dadfcc0e2c"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 6, 11, 34, 8, 878, DateTimeKind.Utc).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b4b4eaf9-0a08-45c8-d150-08dae03a344b"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 6, 11, 34, 8, 878, DateTimeKind.Utc).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ceac6396-3da0-4944-135d-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 6, 11, 34, 8, 878, DateTimeKind.Utc).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4796ccb-b909-468b-135a-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 6, 11, 34, 8, 878, DateTimeKind.Utc).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("df12aeb6-18be-4385-1360-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 6, 11, 34, 8, 878, DateTimeKind.Utc).AddTicks(9198));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e1086ab2-d369-4d5b-bf66-d45604de8d18", "9597d865-b92e-4e33-ad1e-610090fc8487" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e1086ab2-d369-4d5b-bf66-d45604de8d18", "9597d865-b92e-4e33-ad1e-610090fc8487" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1086ab2-d369-4d5b-bf66-d45604de8d18");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9597d865-b92e-4e33-ad1e-610090fc8487");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "582490e1-db7b-4136-830a-ed1745e9a664", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f7db165c-f97a-46a4-9c19-359e81d356ec", 0, "Admin", "Admin", "f30480c6-8c4a-495b-8736-1a4c1b8a7717", new DateTime(2025, 10, 27, 14, 19, 6, 174, DateTimeKind.Local).AddTicks(1075), "admin@admin.com", true, "Admin", 1, "uploads/userImg/userPhoto.png", true, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEL5KG0LmyvLwreyCEKG5T3PdnjoujaQX1Bh/HMWqqcuIuS8wpM96dQZphosXLs8OYw==", "1234567890", false, "1234", "15578d57-ce5e-4364-9af2-56bd63140b3d", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "582490e1-db7b-4136-830a-ed1745e9a664", "f7db165c-f97a-46a4-9c19-359e81d356ec" });
        }
    }
}
