using Microsoft.EntityFrameworkCore.Migrations;

namespace shop_backend.Migrations
{
    public partial class Addsliderentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSection_Sections_ProductsId1",
                table: "ProductSection");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42c54eb1-ab44-4dc8-a89a-3b1e7cd25557");

            migrationBuilder.RenameColumn(
                name: "ProductsId1",
                table: "ProductSection",
                newName: "SectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSection_ProductsId1",
                table: "ProductSection",
                newName: "IX_ProductSection_SectionsId");

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstSlide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondSlide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdSlide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthSlide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FifthSlide = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "436bba9f-d0fa-4ec9-af0a-8f3485cf269c", 0, "dd0f2a30-c860-4a3c-b01d-bb72dd92dd84", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "d9bed0cf-fc3f-4cbe-b9e4-7a641ee76cae", false, "admin@test.pl" });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "FifthSlide", "FirstSlide", "FourthSlide", "SecondSlide", "ThirdSlide" },
                values: new object[] { 1, "", "", "", "", "" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSection_Sections_SectionsId",
                table: "ProductSection",
                column: "SectionsId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSection_Sections_SectionsId",
                table: "ProductSection");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "436bba9f-d0fa-4ec9-af0a-8f3485cf269c");

            migrationBuilder.RenameColumn(
                name: "SectionsId",
                table: "ProductSection",
                newName: "ProductsId1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSection_SectionsId",
                table: "ProductSection",
                newName: "IX_ProductSection_ProductsId1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "42c54eb1-ab44-4dc8-a89a-3b1e7cd25557", 0, "2dee1197-9185-4031-9d9e-59b6d281df3d", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "f2aa23d9-f6c3-4d11-87e9-9d31b0b9003e", false, "admin@test.pl" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSection_Sections_ProductsId1",
                table: "ProductSection",
                column: "ProductsId1",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
