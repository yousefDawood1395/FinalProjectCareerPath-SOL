using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Migrations
{
    public partial class editpayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paths",
                table: "CoursePaths");

            migrationBuilder.RenameColumn(
                name: "userGrade",
                table: "Exams",
                newName: "UserGrade");

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Exams",
                newName: "DateTime");

            migrationBuilder.AlterColumn<string>(
                name: "Payment",
                table: "CoursePaths",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "CoursePaths",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "CoursePaths");

            migrationBuilder.RenameColumn(
                name: "UserGrade",
                table: "Exams",
                newName: "userGrade");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Exams",
                newName: "dateTime");

            migrationBuilder.AlterColumn<decimal>(
                name: "Payment",
                table: "CoursePaths",
                type: "Money",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Paths",
                table: "CoursePaths",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
