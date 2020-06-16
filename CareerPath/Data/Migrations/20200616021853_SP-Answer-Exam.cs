using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Data.Migrations
{
    public partial class SPAnswerExam : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			var sp = @"create procedure [dbo].[AnswerExam]  @UserId int ,@examId int
                        ,@ans1 varchar , @Q1 int
                        ,@ans2 varchar, @Q2 int,@ans3 varchar, @Q3 int,@ans4 varchar, @Q4 int,@ans5 varchar, @Q5 int,
                         @ans6 varchar, @Q6 int

                            as
                            BEGIN
                            
         -----------------------------for insert user answer in table QuestExam----------------------------------------
								
									  update QuestExam 
									  set UserAnswer = @ans1
									 where QuestExam.QuestId=@Q1 and QuestExam.ExamId = @examId
								
									  update QuestExam 
									  set UserAnswer = @ans2
									  where QuestExam.QuestId=@Q2 and QuestExam.ExamId = @examId
								
									  update QuestExam 
									  set UserAnswer = @ans3
									 where QuestExam.QuestId=@Q3 and QuestExam.ExamId = @examId
								
									  
									  update QuestExam 
									  set UserAnswer = @ans4
									 where QuestExam.QuestId=@Q4 and QuestExam.ExamId = @examId
								
									  
									  update QuestExam 
									  set UserAnswer = @ans5
									 where QuestExam.QuestId=@Q5 and QuestExam.ExamId = @examId
								
									  
									  update QuestExam 
									  set UserAnswer = @ans6
									 where QuestExam.QuestId=@Q6 and QuestExam.ExamId = @examId
								
			 ------------------------------------------End of insert user answer in table QuestExam------------------------------
		
			 -------------------------------Cursor For Correcting User Exam-------------------------------------------------------
								
								    Declare @Grade int=5;
									Declare @Stusent_Mark int=0;
									Declare @UserAnswer nvarchar(5);
									Declare @RightAns nvarchar(5);
								
									declare Correct_EX cursor 
								
									for select UserAnswer , RightAns
									from QuestExam 
									where ExamId=@examId 
								
									open Correct_EX 
								
									fetch Correct_EX into @UserAnswer , @RightAns
											while(@@FETCH_STATUS=0)
											   begin
											    
												    if @UserAnswer = @RightAns
													begin
													  set @Stusent_Mark = @Stusent_Mark+@Grade
													 end 
													fetch Correct_EX into @UserAnswer , @RightAns
												
											    end
								
											select @Stusent_Mark as 'GradeOfUser' 
								
								close correct_ex
								deallocate correct_ex
								
		 --------------------------end of Cursor For Correcting User Exam-----------------------------------------------------
		 ----------------------------Insert User Grade In Table UserExam----------------------------------------------------
								
								
								update UserExam 
								set UserGrade = @Stusent_Mark
								where UserExam.UserId = @UserId and UserExam.ExamId = @examId

    
                            END";

			migrationBuilder.Sql(sp);


		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			var DropSP = @"DROP procedure AnswerExam";

			migrationBuilder.Sql(DropSP);

		}
	}
}
