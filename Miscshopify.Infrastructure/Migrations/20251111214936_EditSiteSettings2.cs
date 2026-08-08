using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miscshopify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditSiteSettings2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "WarrantyInformation",
                table: "SiteSettings",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "TermsAndConditions",
                table: "SiteSettings",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "SiteName",
                table: "SiteSettings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "SiteDescription",
                table: "SiteSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ShippingInformation",
                table: "SiteSettings",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "ReturnPolicy",
                table: "SiteSettings",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "PrivacyPolicy",
                table: "SiteSettings",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "MetaKeywords",
                table: "SiteSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "SiteSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "MaintenanceMessage",
                table: "SiteSettings",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "HeroTitle",
                table: "SiteSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "HeroSubtitle",
                table: "SiteSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "HeroImagePath",
                table: "SiteSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ContactPhone",
                table: "SiteSettings",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "SiteSettings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3097a6a-a73d-4ee4-890c-1620940944fd", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "055cc4ff-e9a4-426b-be06-b36304783962", 0, "Admin", "Admin", "0d942b7a-50c2-4b22-bacc-eb9504608ab0", new DateTime(2025, 11, 11, 23, 49, 34, 955, DateTimeKind.Local).AddTicks(7079), "admin@admin.com", true, "Admin", 1, "uploads/userImg/userPhoto.png", true, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEHa73lBzipKXRzlHaA13tFWy9EGe9cOx/ir8RxPqTzQhekdgdzAwv/7/OLjbRlxLbw==", "1234567890", false, "1234", "53ba82eb-b163-450c-a17d-2c4661475a06", false, "admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b188390-8db6-4783-135b-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 49, 34, 948, DateTimeKind.Utc).AddTicks(9356));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("56532f98-112b-474a-1361-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 49, 34, 949, DateTimeKind.Utc).AddTicks(649));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5709db41-e129-490b-135e-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 49, 34, 949, DateTimeKind.Utc).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6468f6ad-5de5-4a34-1362-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 49, 34, 949, DateTimeKind.Utc).AddTicks(839));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8355a0dd-a683-42ae-135f-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 49, 34, 949, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8747cde3-f434-45ee-389f-08dadfe174ee"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 49, 34, 948, DateTimeKind.Utc).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9086399c-0be5-42ff-135c-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 49, 34, 948, DateTimeKind.Utc).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ab40e33a-24d3-47d4-b570-08dadfcc0e2c"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 49, 34, 948, DateTimeKind.Utc).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b4b4eaf9-0a08-45c8-d150-08dae03a344b"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 49, 34, 948, DateTimeKind.Utc).AddTicks(8947));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ceac6396-3da0-4944-135d-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 49, 34, 948, DateTimeKind.Utc).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4796ccb-b909-468b-135a-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 49, 34, 948, DateTimeKind.Utc).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("df12aeb6-18be-4385-1360-08dae0fd13bc"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 11, 21, 49, 34, 949, DateTimeKind.Utc).AddTicks(459));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e3097a6a-a73d-4ee4-890c-1620940944fd", "055cc4ff-e9a4-426b-be06-b36304783962" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e3097a6a-a73d-4ee4-890c-1620940944fd", "055cc4ff-e9a4-426b-be06-b36304783962" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3097a6a-a73d-4ee4-890c-1620940944fd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "055cc4ff-e9a4-426b-be06-b36304783962");

            migrationBuilder.AlterColumn<string>(
                name: "WarrantyInformation",
                table: "SiteSettings",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TermsAndConditions",
                table: "SiteSettings",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SiteName",
                table: "SiteSettings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SiteDescription",
                table: "SiteSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShippingInformation",
                table: "SiteSettings",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReturnPolicy",
                table: "SiteSettings",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrivacyPolicy",
                table: "SiteSettings",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaKeywords",
                table: "SiteSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "SiteSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaintenanceMessage",
                table: "SiteSettings",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeroTitle",
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
                name: "HeroSubtitle",
                table: "SiteSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeroImagePath",
                table: "SiteSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactPhone",
                table: "SiteSettings",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "SiteSettings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

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
    }
}
