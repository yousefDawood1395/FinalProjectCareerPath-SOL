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

            var Grade = await Db.UserGrades.FromSqlRaw("AnswerExam  @userID,@examID, @ans1, @q1, @ans2, @q2, @ans3, @q3, @ans4, @q4, @ans5 ,@q5 ,@ans6, @q6", param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14).ToListAsync();
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
            param2.SqlDbType = System.Data.SqlDbType.Int;


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
