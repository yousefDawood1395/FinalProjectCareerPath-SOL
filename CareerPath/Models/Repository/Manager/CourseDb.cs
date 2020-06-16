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
    public class CourseDb:ICourseRepo
    {
        ApplicationDbContext Db;

        public CourseDb(ApplicationDbContext _Db)
        {
            Db = _Db;
        }

        public async void AddCourse(Course _course)
        {
            await Db.Course.AddAsync(_course);
            Db.SaveChanges();
        }

        public async void DeleteCourse(int id)
        {

            Db.Course.Remove(await Db.Course.FindAsync(id));
            Db.SaveChanges();
        }

        public void UpdateCourse(int id, Course _course)
        {


            Db.Entry(_course).State = EntityState.Modified;

            Db.SaveChanges();
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await Db.Course.ToListAsync();
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await Db.Course.FindAsync(id);
        }
    }
}
