using Microsoft.EntityFrameworkCore.Migrations;

namespace shop_backend.Migrations
{
    public partial class Addpurchasesettingsentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6541c257-ddfc-4ae2-a2fb-21bb59a80970");

            migrationBuilder.CreateTable(
                name: "PersonalPickupBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalPickupBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsShippingAvaible = table.Column<bool>(type: "bit", nullable: false),
                    IsPersonalPickupAvaible = table.Column<bool>(type: "bit", nullable: false),
                    IsDotpayAvaible = table.Column<bool>(type: "bit", nullable: false),
                    IsCashAvaible = table.Column<bool>(type: "bit", nullable: false),
                    IsTransferAvaible = table.Column<bool>(type: "bit", nullable: false),
                    TransferNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseSettings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fa4eb5fc-29e1-4f6e-aaef-efb39ca87d0c", 0, "3486bd1f-81f3-4892-8cf1-c09a4988871d", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "225ade53-6d52-4214-bf7b-555124b8a7a0", false, "admin@test.pl" });

            migrationBuilder.InsertData(
                table: "PurchaseSettings",
                columns: new[] { "Id", "IsCashAvaible", "IsDotpayAvaible", "IsPersonalPickupAvaible", "IsShippingAvaible", "IsTransferAvaible", "TransferNumber" },
                values: new object[] { 1, false, false, false, true, true, "Testing transfer number" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalPickupBranches");

            migrationBuilder.DropTable(
                name: "PurchaseSettings");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa4eb5fc-29e1-4f6e-aaef-efb39ca87d0c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6541c257-ddfc-4ae2-a2fb-21bb59a80970", 0, "48f43195-a5e9-48d2-89de-8724101ccb25", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "20f28b7c-9603-4b8b-8dcd-f170a83b311f", false, "admin@test.pl" });
        }
    }
}
