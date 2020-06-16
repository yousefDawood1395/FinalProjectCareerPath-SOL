using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Migrations
{
    public partial class CreateExamSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var SP = @"create proc [dbo].[CreateExam] @CourseName varchar(50) , @userId int , @Date datetime2(7)
                           as 
                           BEGIN
                           
                           Declare  @IDOfCourse int ;
                           set @IDOfCourse =( select CourseId
                           					from Course
                           					where CourseName = @CourseName)
                           
                           
                           
                           insert into Exams (ExamName , TotalGrade ,ExamDuration , CourseId ,dateTime)
                           values (@CourseName +' '+ 'Exam'  , 50 , 1 , @IDOfCourse , @Date)
                           
                           declare @IDOfExam int ;
                           set @IDOfExam = (
                           select ExamId
                           from Exams where Exams.CourseId = @IDOfCourse and Exams.dateTime = @Date )
                           
                           		
                           	
                           insert into UserExam (ExamId , UserId , CourseId , DateTime)
                           values (@IDOfExam , @userId , @IDOfCourse , @Date)
                            
                           
                           insert into dbo.QuestExam(ExamId , QuestId ,QuestName ,RightAns)
                           select @IDOfExam , QuestId ,QuestName ,RightAns
                           from (
                           	select  Questions.QuestId ,Questions.QuestName , Questions.RightAns  ,DENSE_RANK() over(order by (ABS(CHECKSUM(NEWID())) % 1000000 + 100) ) as 'Drank'
                           	from Questions inner join Course on Questions.courseIdRef = Course.CourseId AND CourseName = @CourseName
                           					--inner join Exams on Exams.CourseId = Course.CourseId
                           ) as newTable
                           where Drank<=6
                           
                           
                           select * 
                            from QuestExam
                             where QuestExam.ExamId = @IDOfExam	
                           END";
            migrationBuilder.Sql(SP);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropSP = @"Drop procedure CreateExam";
            migrationBuilder.Sql(dropSP);
        }
    }
}
