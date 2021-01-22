using Microsoft.EntityFrameworkCore.Migrations;

namespace shop_backend.Migrations
{
    public partial class Changeshopsettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ab79135c-3417-43a7-9505-cc6395739979");

            migrationBuilder.DropColumn(
                name: "LeadingColor",
                table: "ShopSettings");

            migrationBuilder.DropColumn(
                name: "SecondaryColor",
                table: "ShopSettings");

            migrationBuilder.RenameColumn(
                name: "TertiaryColor",
                table: "ShopSettings",
                newName: "Regulations");

            migrationBuilder.AddColumn<int>(
                name: "ThemeId",
                table: "ShopSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryBackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryTextColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadingBackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadingTextColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavbarBackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavbarTextColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainBackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainTextColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterBackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterTextColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e634f84c-3cd0-4441-a6e5-bc351d0045a4", 0, "7684c30b-3347-490b-8f8c-61a23e3b6c53", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "833466f7-5def-4166-9ff0-470cfc6c34f4", false, "admin@test.pl" });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "FooterBackgroundColor", "FooterTextColor", "LeadingBackgroundColor", "LeadingTextColor", "MainBackgroundColor", "MainTextColor", "Name", "NavbarBackgroundColor", "NavbarTextColor", "SecondaryBackgroundColor", "SecondaryTextColor" },
                values: new object[] { 1, "#ffffff", "#000000", "#02d463", "#000000", "#ffffff", "#000000", "Green, grey and white", "#ffffff", "#000000", "#f1f1f1", "#000000" });

            migrationBuilder.UpdateData(
                table: "ShopSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Regulations", "ThemeId" },
                values: new object[] { null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ShopSettings_ThemeId",
                table: "ShopSettings",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopSettings_Themes_ThemeId",
                table: "ShopSettings",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopSettings_Themes_ThemeId",
                table: "ShopSettings");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_ShopSettings_ThemeId",
                table: "ShopSettings");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e634f84c-3cd0-4441-a6e5-bc351d0045a4");

            migrationBuilder.DropColumn(
                name: "ThemeId",
                table: "ShopSettings");

            migrationBuilder.RenameColumn(
                name: "Regulations",
                table: "ShopSettings",
                newName: "TertiaryColor");

            migrationBuilder.AddColumn<string>(
                name: "LeadingColor",
                table: "ShopSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryColor",
                table: "ShopSettings",
                type: "nvarchar(max)",
                nullable: true);

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
