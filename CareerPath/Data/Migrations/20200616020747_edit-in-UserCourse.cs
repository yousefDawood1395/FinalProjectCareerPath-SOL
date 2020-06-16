using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Data.Migrations
{
    public partial class editinUserCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourse_AspNetUsers_MyUserId",
                table: "UserCourse");

            migrationBuilder.DropIndex(
                name: "IX_UserCourse_MyUserId",
                table: "UserCourse");

            migrationBuilder.DropColumn(
                name: "MyUserId",
                table: "UserCourse");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "UserCourse",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserCourse",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_UserId1",
                table: "UserCourse",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourse_AspNetUsers_UserId1",
                table: "UserCourse",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourse_AspNetUsers_UserId1",
                table: "UserCourse");

            migrationBuilder.DropIndex(
                name: "IX_UserCourse_UserId1",
                table: "UserCourse");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "UserCourse");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserCourse");

            migrationBuilder.AddColumn<string>(
                name: "MyUserId",
                table: "UserCourse",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_MyUserId",
                table: "UserCourse",
                column: "MyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourse_AspNetUsers_MyUserId",
                table: "UserCourse",
                column: "MyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
