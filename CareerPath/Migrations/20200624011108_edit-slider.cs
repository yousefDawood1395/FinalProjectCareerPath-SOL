using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Migrations
{
    public partial class editslider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Slider");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Slider");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Slider",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Slider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Slider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Slider",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Slider");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Slider");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Slider");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Slider",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Slider",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Slider",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
