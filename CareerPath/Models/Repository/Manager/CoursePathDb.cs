using CareerPath.Data;
using CareerPath.Models.Entities;
using CareerPath.Models.Repository.IManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerPath.Models.Repository.IManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CareerPath.Models.Repository.Manager
{
    public class CoursePathDb : ICoursePathRepo
    {
        ApplicationDbContext Db;

        public CoursePathDb(ApplicationDbContext _Db)
        {
            Db = _Db;
        }

        public async void AddCoursePath(CoursePath _coursePath)
        {
            await Db.CoursePaths.AddAsync(_coursePath);
            Db.SaveChanges();
        }

        public async void DeleteCoursePath(int id)
        {
            Db.CoursePaths.Remove(await Db.CoursePaths.FindAsync(id));
            Db.SaveChanges();
        }

        public async Task<List<CoursePath>> GetAllCoursePath()
        {
            return await Db.CoursePaths.ToListAsync();
        }

        public async Task<CoursePath> GetCoursePathById(int id)
        {
            return await Db.CoursePaths.FindAsync(id);
        }

        public async void UpdateCoursePath(int id, CoursePath _coursePath)
        {
            Db.Entry(_coursePath).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }
    }
}
