using Microsoft.EntityFrameworkCore.Migrations;

namespace shop_backend.Migrations
{
    public partial class Changethemetoshopsettingsaddnewfieldstoit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6139805a-3612-4210-90ef-7526de8cbf25");

            migrationBuilder.CreateTable(
                name: "ShopSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadingColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TertiaryColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopSettings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2ffd22f6-a06d-42a1-882e-bfe6a2dc9dee", 0, "920fe0cd-ffcc-48b5-ae2b-943063f42b1f", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "23be4ada-2764-4f24-a923-5819ac9dd1ac", false, "admin@test.pl" });

            migrationBuilder.InsertData(
                table: "ShopSettings",
                columns: new[] { "Id", "Currency", "LeadingColor", "Logo", "SecondaryColor", "TertiaryColor" },
                values: new object[] { 1, 0, "#002137", "", "#2137ff", "#ff2137" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopSettings");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ffd22f6-a06d-42a1-882e-bfe6a2dc9dee");

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadingColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TertiaryColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6139805a-3612-4210-90ef-7526de8cbf25", 0, "75466555-3a38-48ab-91ce-34f38790fdf4", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "177b3c8e-8e90-4bef-8286-ab80006e8966", false, "admin@test.pl" });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "LeadingColor", "SecondaryColor", "TertiaryColor" },
                values: new object[] { 1, "#002137", "#2137ff", "#ff2137" });
        }
    }
}
