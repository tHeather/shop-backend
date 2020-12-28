using Microsoft.EntityFrameworkCore.Migrations;

namespace shop_backend.Migrations
{
    public partial class Addsectionentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ad4a7f1b-1c6b-4b15-85f1-aaafcdc954cd");

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSection",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSection", x => new { x.ProductsId, x.ProductsId1 });
                    table.ForeignKey(
                        name: "FK_ProductSection_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSection_Sections_ProductsId1",
                        column: x => x.ProductsId1,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6139805a-3612-4210-90ef-7526de8cbf25", 0, "75466555-3a38-48ab-91ce-34f38790fdf4", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "177b3c8e-8e90-4bef-8286-ab80006e8966", false, "admin@test.pl" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSection_ProductsId1",
                table: "ProductSection",
                column: "ProductsId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSection");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6139805a-3612-4210-90ef-7526de8cbf25");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ad4a7f1b-1c6b-4b15-85f1-aaafcdc954cd", 0, "4199552d-a425-4f2d-9282-26712e09aea7", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "0cab0064-5c7c-48ec-9ed1-da3a899e307e", false, "admin@test.pl" });
        }
    }
}
