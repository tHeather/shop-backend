using Microsoft.EntityFrameworkCore.Migrations;

namespace shop_backend.Migrations
{
    public partial class changeshopSettingsfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ab79135c-3417-43a7-9505-cc6395739979");

            migrationBuilder.RenameColumn(
                name: "TertiaryColor",
                table: "ShopSettings",
                newName: "NavbarColor");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundColor",
                table: "ShopSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterColor",
                table: "ShopSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5efbbb10-445a-4141-9011-ae5afcc332da", 0, "2abe40c3-42df-4d08-ab4a-65ecc4ef50f5", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "5a7dceb4-fb0d-49b4-93c4-100fca00c284", false, "admin@test.pl" });

            migrationBuilder.UpdateData(
                table: "ShopSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BackgroundColor", "FooterColor", "LeadingColor", "NavbarColor", "SecondaryColor" },
                values: new object[] { "#ffffff", "#f1f1f1", "#02d463", "#ffffff", "#f1f1f1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5efbbb10-445a-4141-9011-ae5afcc332da");

            migrationBuilder.DropColumn(
                name: "BackgroundColor",
                table: "ShopSettings");

            migrationBuilder.DropColumn(
                name: "FooterColor",
                table: "ShopSettings");

            migrationBuilder.RenameColumn(
                name: "NavbarColor",
                table: "ShopSettings",
                newName: "TertiaryColor");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ab79135c-3417-43a7-9505-cc6395739979", 0, "55a307e8-0d15-4a00-9a6b-f1cb1a24e069", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "7c4b955b-1656-4228-8bc1-248bbe5ad542", false, "admin@test.pl" });

            migrationBuilder.UpdateData(
                table: "ShopSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LeadingColor", "SecondaryColor", "TertiaryColor" },
                values: new object[] { "#002137", "#2137ff", "#ff2137" });
        }
    }
}
