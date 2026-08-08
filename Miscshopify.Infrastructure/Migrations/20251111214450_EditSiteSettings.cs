using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miscshopify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditSiteSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a6ec6068-12b0-4c29-a949-f251fe275db0", "ba8593b5-f719-473b-8a46-c2c8feec8990" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6ec6068-12b0-4c29-a949-f251fe275db0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba8593b5-f719-473b-8a46-c2c8feec8990");

            migrationBuilder.AlterColumn<string>(
                name: "TwitterUrl",
                table: "SiteSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "InstagramUrl",
                table: "SiteSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "FacebookUrl",
                table: "SiteSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "TikTokUrl",
                table: "SiteSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d12751da-7c5c-40d1-afc2-e13644897b4b", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1f55826b-0619-441f-8066-4b2802acf92f", 0, "Admin", "Admin", "91bb8bd2-4d83-49ab-a235-754e402a9592", new DateTime(2025, 11, 11, 23, 44, 49, 327, DateTimeKind.Local).AddTicks(9791), "admin@admin.com", true, "Admin", 1, "uploads/userImg/userPhoto.png", true, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEBmN1aw9tarKrIo3EbQehsz0JUrVmTTz8F5TXxgfUzrnpGvd2w/K2AVmaVBrzeDzVg==", "1234567890", false, "1234", "401cd8a4-5547-49f6-9bdf-b95bd3ad3152", false, "admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b188390-8db6-4783-135b-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 44, 49, 325, DateTimeKind.Utc).AddTicks(3684));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("56532f98-112b-474a-1361-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 44, 49, 325, DateTimeKind.Utc).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5709db41-e129-490b-135e-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 44, 49, 325, DateTimeKind.Utc).AddTicks(4002));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6468f6ad-5de5-4a34-1362-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 44, 49, 325, DateTimeKind.Utc).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8355a0dd-a683-42ae-135f-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 44, 49, 325, DateTimeKind.Utc).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8747cde3-f434-45ee-389f-08dadfe174ee"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 44, 49, 325, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9086399c-0be5-42ff-135c-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 44, 49, 325, DateTimeKind.Utc).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ab40e33a-24d3-47d4-b570-08dadfcc0e2c"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 44, 49, 325, DateTimeKind.Utc).AddTicks(3196));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b4b4eaf9-0a08-45c8-d150-08dae03a344b"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 44, 49, 325, DateTimeKind.Utc).AddTicks(3513));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ceac6396-3da0-4944-135d-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 44, 49, 325, DateTimeKind.Utc).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4796ccb-b909-468b-135a-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 44, 49, 325, DateTimeKind.Utc).AddTicks(3601));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("df12aeb6-18be-4385-1360-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 44, 49, 325, DateTimeKind.Utc).AddTicks(4167));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d12751da-7c5c-40d1-afc2-e13644897b4b", "1f55826b-0619-441f-8066-4b2802acf92f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d12751da-7c5c-40d1-afc2-e13644897b4b", "1f55826b-0619-441f-8066-4b2802acf92f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d12751da-7c5c-40d1-afc2-e13644897b4b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f55826b-0619-441f-8066-4b2802acf92f");

            migrationBuilder.DropColumn(
                name: "TikTokUrl",
                table: "SiteSettings");

            migrationBuilder.AlterColumn<string>(
                name: "TwitterUrl",
                table: "SiteSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstagramUrl",
                table: "SiteSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacebookUrl",
                table: "SiteSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6ec6068-12b0-4c29-a949-f251fe275db0", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ba8593b5-f719-473b-8a46-c2c8feec8990", 0, "Admin", "Admin", "4741d53e-683e-46d4-8d94-cf335cbca7a9", new DateTime(2025, 11, 11, 23, 38, 26, 145, DateTimeKind.Local).AddTicks(387), "admin@admin.com", true, "Admin", 1, "uploads/userImg/userPhoto.png", true, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEIHfiUJ2621ek29ZfQC0Ty0HlazdjKB7DHGv1jQLEcdnzzLXvBcU7UkmLhVH2IehtQ==", "1234567890", false, "1234", "fdc3a0c3-164a-468d-bbb9-a37cf3872def", false, "admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b188390-8db6-4783-135b-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 38, 26, 141, DateTimeKind.Utc).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("56532f98-112b-474a-1361-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 38, 26, 141, DateTimeKind.Utc).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5709db41-e129-490b-135e-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 38, 26, 141, DateTimeKind.Utc).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6468f6ad-5de5-4a34-1362-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 38, 26, 142, DateTimeKind.Utc).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8355a0dd-a683-42ae-135f-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 38, 26, 141, DateTimeKind.Utc).AddTicks(9738));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8747cde3-f434-45ee-389f-08dadfe174ee"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 38, 26, 141, DateTimeKind.Utc).AddTicks(8965));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9086399c-0be5-42ff-135c-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 38, 26, 141, DateTimeKind.Utc).AddTicks(9395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ab40e33a-24d3-47d4-b570-08dadfcc0e2c"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 38, 26, 141, DateTimeKind.Utc).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b4b4eaf9-0a08-45c8-d150-08dae03a344b"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 38, 26, 141, DateTimeKind.Utc).AddTicks(9065));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ceac6396-3da0-4944-135d-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 38, 26, 141, DateTimeKind.Utc).AddTicks(9548));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4796ccb-b909-468b-135a-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 38, 26, 141, DateTimeKind.Utc).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("df12aeb6-18be-4385-1360-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 38, 26, 141, DateTimeKind.Utc).AddTicks(9826));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a6ec6068-12b0-4c29-a949-f251fe275db0", "ba8593b5-f719-473b-8a46-c2c8feec8990" });
        }
    }
}
