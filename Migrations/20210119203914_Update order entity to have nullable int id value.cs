using Microsoft.EntityFrameworkCore.Migrations;

namespace shop_backend.Migrations
{
    public partial class Updateorderentitytohavenullableintidvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_PersonalPickupBranches_PersonalPickupBranchId",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a522bbef-13b8-4f52-9ab0-273aad012d3d");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalPickupBranchId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0f1d3675-ae1e-4c72-abf8-958f4b1207b7", 0, "76a0541c-416d-4332-9bdc-9fbecf0ca3cd", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "d8cbd5b9-53b7-4f46-9c16-583ad0e2a467", false, "admin@test.pl" });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_PersonalPickupBranches_PersonalPickupBranchId",
                table: "Order",
                column: "PersonalPickupBranchId",
                principalTable: "PersonalPickupBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_PersonalPickupBranches_PersonalPickupBranchId",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f1d3675-ae1e-4c72-abf8-958f4b1207b7");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalPickupBranchId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a522bbef-13b8-4f52-9ab0-273aad012d3d", 0, "c7e94a21-6904-43df-8bd1-739624573389", "admin@test.pl", false, false, null, "ADMIN@TEST.PL", "ADMIN@TEST.PL", "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", null, false, "abe2823f-4344-4891-ae47-dcbd76b1c65f", false, "admin@test.pl" });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_PersonalPickupBranches_PersonalPickupBranchId",
                table: "Order",
                column: "PersonalPickupBranchId",
                principalTable: "PersonalPickupBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
