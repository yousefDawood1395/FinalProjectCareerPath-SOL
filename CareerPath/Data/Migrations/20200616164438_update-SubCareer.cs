using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Data.Migrations
{
    public partial class updateSubCareer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCareer_Career_CareerIdREf",
                table: "SubCareer");

            migrationBuilder.RenameColumn(
                name: "CareerIdREf",
                table: "SubCareer",
                newName: "CareerIdRef");

            migrationBuilder.RenameIndex(
                name: "IX_SubCareer_CareerIdREf",
                table: "SubCareer",
                newName: "IX_SubCareer_CareerIdRef");

            migrationBuilder.AlterColumn<int>(
                name: "CareerIdRef",
                table: "SubCareer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCareer_Career_CareerIdRef",
                table: "SubCareer",
                column: "CareerIdRef",
                principalTable: "Career",
                principalColumn: "CareerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCareer_Career_CareerIdRef",
                table: "SubCareer");

            migrationBuilder.RenameColumn(
                name: "CareerIdRef",
                table: "SubCareer",
                newName: "CareerIdREf");

            migrationBuilder.RenameIndex(
                name: "IX_SubCareer_CareerIdRef",
                table: "SubCareer",
                newName: "IX_SubCareer_CareerIdREf");

            migrationBuilder.AlterColumn<int>(
                name: "CareerIdREf",
                table: "SubCareer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SubCareer_Career_CareerIdREf",
                table: "SubCareer",
                column: "CareerIdREf",
                principalTable: "Career",
                principalColumn: "CareerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
