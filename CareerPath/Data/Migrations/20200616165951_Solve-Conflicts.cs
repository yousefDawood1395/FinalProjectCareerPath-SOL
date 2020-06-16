using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Data.Migrations
{
    public partial class SolveConflicts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Course_CourseId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CourseId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "QuestID",
                table: "Questions",
                newName: "QuestId");

            migrationBuilder.AddColumn<int>(
                name: "courseIdRef",
                table: "Questions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_courseIdRef",
                table: "Questions",
                column: "courseIdRef");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Course_courseIdRef",
                table: "Questions",
                column: "courseIdRef",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Course_courseIdRef",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_courseIdRef",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "courseIdRef",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "QuestId",
                table: "Questions",
                newName: "QuestID");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CourseId",
                table: "Questions",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Course_CourseId",
                table: "Questions",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
