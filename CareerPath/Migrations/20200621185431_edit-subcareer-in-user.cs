using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Migrations
{
    public partial class editsubcareerinuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SubCareer_SubCareerId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "SubCareerId",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SubCareer_SubCareerId",
                table: "AspNetUsers",
                column: "SubCareerId",
                principalTable: "SubCareer",
                principalColumn: "SubCareerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SubCareer_SubCareerId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "SubCareerId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SubCareer_SubCareerId",
                table: "AspNetUsers",
                column: "SubCareerId",
                principalTable: "SubCareer",
                principalColumn: "SubCareerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
