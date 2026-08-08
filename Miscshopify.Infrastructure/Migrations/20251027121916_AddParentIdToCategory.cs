using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miscshopify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddParentIdToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "582490e1-db7b-4136-830a-ed1745e9a664", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f7db165c-f97a-46a4-9c19-359e81d356ec", 0, "Admin", "Admin", "f30480c6-8c4a-495b-8736-1a4c1b8a7717", new DateTime(2025, 10, 27, 14, 19, 6, 174, DateTimeKind.Local).AddTicks(1075), "admin@admin.com", true, "Admin", 1, "uploads/userImg/userPhoto.png", true, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEL5KG0LmyvLwreyCEKG5T3PdnjoujaQX1Bh/HMWqqcuIuS8wpM96dQZphosXLs8OYw==", "1234567890", false, "1234", "15578d57-ce5e-4364-9af2-56bd63140b3d", false, "admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0a681278-e942-47f9-0c19-08dae1128df6"),
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("266a6cbb-56cd-4500-efd8-08dadfcbf404"),
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a7d777ad-9b16-48be-4dba-08dae039c34b"),
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("be2ed17b-0c49-4a87-4db8-08dae039c34b"),
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cf06817a-292e-458d-4db9-08dae039c34b"),
                column: "ParentId",
                value: null);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "582490e1-db7b-4136-830a-ed1745e9a664", "f7db165c-f97a-46a4-9c19-359e81d356ec" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentId",
                table: "Categories");

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

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Categories");

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
    }
}
