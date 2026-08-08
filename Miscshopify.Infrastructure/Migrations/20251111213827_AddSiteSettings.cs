using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miscshopify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSiteSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SiteDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShowMaintenanceMessage = table.Column<bool>(type: "bit", nullable: false),
                    MaintenanceMessage = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MaintenanceStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaintenanceEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeroImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HeroTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HeroSubtitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PrivacyPolicy = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    TermsAndConditions = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    ReturnPolicy = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    ShippingInformation = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    WarrantyInformation = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    FacebookUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InstagramUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TwitterUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShowOutOfStockProducts = table.Column<bool>(type: "bit", nullable: false),
                    AllowPurchasingOutOfStock = table.Column<bool>(type: "bit", nullable: false),
                    LowStockThreshold = table.Column<int>(type: "int", nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteSettings");

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
    }
}
