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
    public class UserCourseDb: IUserCourseRepo
    {
        ApplicationDbContext DB;

        public UserCourseDb(ApplicationDbContext _Db)
        {
            DB = _Db;
        }


        public async void Add(UserCourse obj)
        {
            await DB.UserCourse.AddAsync(obj);
            DB.SaveChanges();

        }

        public void Delete(int id)
        {
            DB.UserCourse.Remove(DB.UserCourse.SingleOrDefault(ww => ww.CourseId == id));
            DB.SaveChanges();
        }

        public async Task<List<UserCourse>> GetAll()
        {
            return await DB.UserCourse.ToListAsync();
        }

        public async Task<UserCourse> GetByID(int id)
        {
            return await DB.UserCourse.FindAsync(id);
        }

        public async Task<UserCourse> GetByName(string Name)
        {
            return await DB.UserCourse.FirstOrDefaultAsync(ww => ww.Course.CourseName == Name);
        }

        public void Update(int? id, UserCourse obj)
        {
            DB.Entry(obj).State = EntityState.Modified;
            DB.SaveChanges();
        }

    }
}
