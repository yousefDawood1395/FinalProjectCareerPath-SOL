using CareerPath.Data;
using CareerPath.Models.Entities;
using CareerPath.Models.Repository.IManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Repository.Manager
{
    public class UserExamDb: IUserExamRepo
    {
        ApplicationDbContext DB;

        public UserExamDb(ApplicationDbContext _Db)
        {
            DB = _Db;
        }

        public async void Add(UserExam obj)
        {
            await DB.UserExam.AddAsync(obj);
            DB.SaveChanges();

        }

        public void Delete(int id)
        {
            DB.UserExam.Remove(DB.UserExam.SingleOrDefault(ww => ww.ExamId == id));
            DB.SaveChanges();
        }

        public async Task<List<UserExam>> GetAll()
        {
            return await DB.UserExam.ToListAsync();
        }

        public async Task<List<ExamInfoAboutUser>> GetAllExamInfoAboutUser(string UserName)
        {
            string IdOfUser = await (from u in DB.Users
                               where u.UserName == UserName
                               select u.Id).SingleOrDefaultAsync();

            var data =await (from u in DB.Users
                        join ue in DB.UserExam on
                        u.Id equals ue.UserId
                        join e in DB.Exams on ue.ExamId equals e.ExamId
                        join c in DB.Course on ue.CourseId equals c.CourseId
                        where u.Id == IdOfUser
                        select new
                        {
                            ExamID = e.ExamId,
                            ExamName = e.ExamName,
                            UserName = UserName,
                            CourseID = c.CourseId,
                            UserGrade = ue.UserGrade,                            
                            CourseName = c.CourseName,
                            DateTime = e.DateTime
                            

                        }).ToListAsync();


            List<ExamInfoAboutUser> examInfoAboutUsers = new List<ExamInfoAboutUser>();

            foreach(var item in data)
            {
                ExamInfoAboutUser obj = new ExamInfoAboutUser()
                {
                    UserName = item.UserName,
                    ExamID = item.ExamID,
                    ExamName = item.ExamName,
                    CourseID = item.CourseID,
                    CourseName = item.CourseName,
                    DateTime = item.DateTime,
                    UserGrade = item.UserGrade
                };

                examInfoAboutUsers.Add(obj);
            }

            return examInfoAboutUsers;


        }

        public async Task<UserExam> GetByID(int id)
        {
            return await DB.UserExam.FindAsync(id);
        }

        public async Task<UserExam> GetByName(string Name)
        {
            return await DB.UserExam.FirstOrDefaultAsync(ww => ww.User.Fname == Name);
        }

        public void Update(int? id, UserExam obj)
        {
            DB.Entry(obj).State = EntityState.Modified;
            DB.SaveChanges();
        }




    }
}
