using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Migrations
{
    public partial class removesubcarerIdFromMyRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_SubCareer_SubCareerId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_SubCareerId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "SubCareerId",
                table: "AspNetRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCareerId",
                table: "AspNetRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_SubCareerId",
                table: "AspNetRoles",
                column: "SubCareerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_SubCareer_SubCareerId",
                table: "AspNetRoles",
                column: "SubCareerId",
                principalTable: "SubCareer",
                principalColumn: "SubCareerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
