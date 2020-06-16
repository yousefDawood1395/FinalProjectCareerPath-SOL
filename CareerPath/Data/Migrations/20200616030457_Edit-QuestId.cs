using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Data.Migrations
{
    public partial class EditQuestId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestExam_Questions_QuestId",
                table: "QuestExam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestD",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestID",
                table: "Questions",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "QuestID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestExam_Questions_QuestId",
                table: "QuestExam",
                column: "QuestId",
                principalTable: "Questions",
                principalColumn: "QuestID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestExam_Questions_QuestId",
                table: "QuestExam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestID",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestD",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "QuestD");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestExam_Questions_QuestId",
                table: "QuestExam",
                column: "QuestId",
                principalTable: "Questions",
                principalColumn: "QuestD",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
