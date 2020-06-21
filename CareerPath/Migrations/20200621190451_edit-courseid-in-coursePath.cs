using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Migrations
{
    public partial class editcourseidincoursePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursePaths_Course_CourseId",
                table: "CoursePaths");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CoursePaths",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePaths_Course_CourseId",
                table: "CoursePaths",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursePaths_Course_CourseId",
                table: "CoursePaths");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CoursePaths",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePaths_Course_CourseId",
                table: "CoursePaths",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
