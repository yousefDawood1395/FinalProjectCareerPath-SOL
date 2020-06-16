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
