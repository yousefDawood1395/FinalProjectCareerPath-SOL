using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Data.Migrations
{
    public partial class addEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCareerId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCareerId",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Career",
                columns: table => new
                {
                    CareerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CareerName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Career", x => x.CareerId);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(maxLength: 50, nullable: true),
                    CourseContent = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Duration = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "UserGrades",
                columns: table => new
                {
                    GradeOfUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGrades", x => x.GradeOfUser);
                });

            migrationBuilder.CreateTable(
                name: "SubCareer",
                columns: table => new
                {
                    SubCareerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCareerName = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CareerIdREf = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCareer", x => x.SubCareerId);
                    table.ForeignKey(
                        name: "FK_SubCareer_Career_CareerIdREf",
                        column: x => x.CareerIdREf,
                        principalTable: "Career",
                        principalColumn: "CareerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(maxLength: 50, nullable: true),
                    TotalGrade = table.Column<int>(nullable: true),
                    ExamDuration = table.Column<int>(nullable: true),
                    userGrade = table.Column<int>(nullable: true),
                    dateTime = table.Column<DateTime>(nullable: false),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_Exams_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestName = table.Column<string>(maxLength: 150, nullable: true),
                    Grade = table.Column<int>(nullable: true),
                    A = table.Column<string>(maxLength: 150, nullable: true),
                    B = table.Column<string>(maxLength: 150, nullable: true),
                    C = table.Column<string>(maxLength: 150, nullable: true),
                    RightAns = table.Column<string>(maxLength: 50, nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestD);
                    table.ForeignKey(
                        name: "FK_Questions_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCourse",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    MyRoleId = table.Column<string>(nullable: true),
                    MyUserId = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourse", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_UserCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourse_AspNetRoles_MyRoleId",
                        column: x => x.MyRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCourse_AspNetUsers_MyUserId",
                        column: x => x.MyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCourse_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCareerCourse",
                columns: table => new
                {
                    SubCareerId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCareerCourse", x => new { x.CourseId, x.SubCareerId });
                    table.ForeignKey(
                        name: "FK_SubCareerCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubCareerCourse_SubCareer_SubCareerId",
                        column: x => x.SubCareerId,
                        principalTable: "SubCareer",
                        principalColumn: "SubCareerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExam",
                columns: table => new
                {
                    ExamId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    UserGrade = table.Column<int>(nullable: true),
                    UserAnswer = table.Column<string>(maxLength: 10, nullable: true),
                    DateTime = table.Column<DateTime>(nullable: true),
                    UserId1 = table.Column<string>(nullable: true),
                    MyRoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExam", x => new { x.UserId, x.ExamId });
                    table.ForeignKey(
                        name: "FK_UserExam_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExam_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExam_AspNetRoles_MyRoleId",
                        column: x => x.MyRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserExam_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestExam",
                columns: table => new
                {
                    ExamId = table.Column<int>(nullable: false),
                    QuestId = table.Column<int>(nullable: false),
                    UserAnswer = table.Column<string>(nullable: true),
                    QuestName = table.Column<string>(maxLength: 150, nullable: true),
                    RightAns = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestExam", x => new { x.ExamId, x.QuestId });
                    table.ForeignKey(
                        name: "FK_QuestExam_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestExam_Questions_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Questions",
                        principalColumn: "QuestD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SubCareerId",
                table: "AspNetUsers",
                column: "SubCareerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_SubCareerId",
                table: "AspNetRoles",
                column: "SubCareerId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CourseId",
                table: "Exams",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestExam_QuestId",
                table: "QuestExam",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CourseId",
                table: "Questions",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCareer_CareerIdREf",
                table: "SubCareer",
                column: "CareerIdREf");

            migrationBuilder.CreateIndex(
                name: "IX_SubCareerCourse_SubCareerId",
                table: "SubCareerCourse",
                column: "SubCareerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_CourseId",
                table: "UserCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_MyRoleId",
                table: "UserCourse",
                column: "MyRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_MyUserId",
                table: "UserCourse",
                column: "MyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_StatusId",
                table: "UserCourse",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExam_CourseId",
                table: "UserExam",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExam_ExamId",
                table: "UserExam",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExam_MyRoleId",
                table: "UserExam",
                column: "MyRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExam_UserId1",
                table: "UserExam",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_SubCareer_SubCareerId",
                table: "AspNetRoles",
                column: "SubCareerId",
                principalTable: "SubCareer",
                principalColumn: "SubCareerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SubCareer_SubCareerId",
                table: "AspNetUsers",
                column: "SubCareerId",
                principalTable: "SubCareer",
                principalColumn: "SubCareerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_SubCareer_SubCareerId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SubCareer_SubCareerId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "QuestExam");

            migrationBuilder.DropTable(
                name: "SubCareerCourse");

            migrationBuilder.DropTable(
                name: "UserCourse");

            migrationBuilder.DropTable(
                name: "UserExam");

            migrationBuilder.DropTable(
                name: "UserGrades");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "SubCareer");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Career");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SubCareerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_SubCareerId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "SubCareerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SubCareerId",
                table: "AspNetRoles");
        }
    }
}
