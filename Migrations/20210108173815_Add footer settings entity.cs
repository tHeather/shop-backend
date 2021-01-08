using Microsoft.EntityFrameworkCore.Migrations;

namespace shop_backend.Migrations
{
    public partial class Addfootersettingsentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "436bba9f-d0fa-4ec9-af0a-8f3485cf269c");

            migrationBuilder.CreateTable(
                name: "FooterSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekWorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekendWorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterSettings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6541c257-ddfc-4ae2-a2fb-21bb59a80970", 0, "48f43195-a5e9-48d2-89de-8724101ccb25", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "20f28b7c-9603-4b8b-8dcd-f170a83b311f", false, "admin@test.pl" });

            migrationBuilder.InsertData(
                table: "FooterSettings",
                columns: new[] { "Id", "Email", "PhoneNumber", "Text", "WeekWorkingHours", "WeekendWorkingHours" },
                values: new object[] { 1, "", "", "", "", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FooterSettings");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6541c257-ddfc-4ae2-a2fb-21bb59a80970");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "436bba9f-d0fa-4ec9-af0a-8f3485cf269c", 0, "dd0f2a30-c860-4a3c-b01d-bb72dd92dd84", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "d9bed0cf-fc3f-4cbe-b9e4-7a641ee76cae", false, "admin@test.pl" });
        }
    }
}
