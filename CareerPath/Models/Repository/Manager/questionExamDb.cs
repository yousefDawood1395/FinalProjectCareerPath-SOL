using CareerPath.Data;
using CareerPath.Models.Entities;
using CareerPath.Models.Repository.IManager;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Repository.Manager
{
    public class questionExamDb: IquestionExam
    {
        ApplicationDbContext Db;

        public questionExamDb(ApplicationDbContext _Db)
        {
            Db = _Db;
        }

        public void AddQuestExam(QuestionExam QuestExam)
        {
            Db.QuestExam.Add(QuestExam);
            Db.SaveChanges();
        }

        //Correct Exam
        public async Task<List<UserGrade>> CorrectExam(AnswerExam obj)
        {
            var examID = obj.ExamID;
            var userID = obj.UserID;
            var ans1 = obj.Ans1;
            var q1 = obj.Q1;
            var ans2 = obj.Ans2;
            var q2 = obj.Q2;
            var ans3 = obj.Ans3;
            var q3 = obj.Q3;
            var ans4 = obj.Ans4;
            var q4 = obj.Q4;
            var ans5 = obj.Ans5;
            var q5 = obj.Q5;
            var ans6 = obj.Ans6;
            var q6 = obj.Q6;
            var ans7 = obj.Ans7;
            var q7 = obj.Q7;
            var ans8 = obj.Ans8;
            var q8 = obj.Q8;
            var ans9 = obj.Ans9;
            var q9 = obj.Q9;
            var ans10 = obj.Ans10;
            var q10 = obj.Q10;


            var param1 = new SqlParameter("@userID", userID);
            var param2 = new SqlParameter("@examID", examID);

            var param3 = new SqlParameter("@ans1", ans1);
            var param4 = new SqlParameter("@q1", q1);

            var param5 = new SqlParameter("@ans2", ans2);
            var param6 = new SqlParameter("@q2", q2);

            var param7 = new SqlParameter("@ans3", ans3);
            var param8 = new SqlParameter("@q3", q3);

            var param9 = new SqlParameter("@ans4", ans4);
            var param10 = new SqlParameter("@q4", q4);

            var param11 = new SqlParameter("@ans5", ans5);
            var param12 = new SqlParameter("@q5", q5);

            var param13 = new SqlParameter("@ans6", ans6);
            var param14 = new SqlParameter("@q6", q6);

            var param15 = new SqlParameter("@ans7", ans7);
            var param16 = new SqlParameter("@q7", q7);

            var param17 = new SqlParameter("@ans8", ans8);
            var param18 = new SqlParameter("@q8", q8);

            var param19 = new SqlParameter("@ans9", ans9);
            var param20 = new SqlParameter("@q9", q9);

            var param21 = new SqlParameter("@ans10", ans10);
            var param22 = new SqlParameter("@q10", q10);

            var Grade = await Db.UserGrades.FromSqlRaw("AnswerExam  @userID,@examID, @ans1, @q1, @ans2, @q2, @ans3, @q3, @ans4, @q4, @ans5 ,@q5 ,@ans6, @q6 ,@ans7, @q7 ,@ans8, @q8 ,@ans9, @q9 ,@ans10, @q10", param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14 , param15 , param16 , param17 , param18 , param19 , param20,param21,param22).ToListAsync();
            return Grade;
        }

        //Create Exam
        public async Task<List<QuestionExam>> CreateExam(CreateExam createExam)
        {
            var userID = createExam.UserID;
            var CourseName = createExam.CourseName;



            var param1 = new SqlParameter("@CourseName", CourseName);
            param1.SqlDbType = System.Data.SqlDbType.NVarChar;

            var param2 = new SqlParameter("@UserID", userID);
            param2.SqlDbType = System.Data.SqlDbType.NVarChar;


            var param3 = new SqlParameter("@data", DateTime.Now);
            param3.SqlDbType = System.Data.SqlDbType.DateTime;

            var exam = await Db.QuestExam.FromSqlRaw("CreateExam  @CourseName, @UserID , @data", param1, param2, param3).ToListAsync();
            return exam;
        }

        public void EditQuestExam(int id, QuestionExam questExam)
        {
            Db.Entry(questExam).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Db.SaveChanges();

        }

        public async Task<List<QuestionExam>> GetAllQuestExam()
        {
            return await Db.QuestExam.ToListAsync();
        }

        public async Task<QuestionExam> GetQuestExamById(int id)
        {
            return await Db.QuestExam.FindAsync(id);
        }
    }
}
