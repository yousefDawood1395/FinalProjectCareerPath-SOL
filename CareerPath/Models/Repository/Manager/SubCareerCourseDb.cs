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
    public class SubCareerCourseDb: ISubCareerCourseRepo
    {
        ApplicationDbContext DB;

        public SubCareerCourseDb(ApplicationDbContext _Db)
        {
            DB = _Db;
        }

        public async void Add(SubCareerCourse obj)
        {

            await DB.AddAsync(obj);
            DB.SaveChanges();

        }






        public async void DeleteSubCareerIDAndCourseID(SubCareerCourse subCareerCourse)
        {


            var idSubcareer = subCareerCourse.SubCareerId;
            var idCourse = subCareerCourse.CourseId;

            DB.SubCareerCourse.Remove(await DB.SubCareerCourse.FindAsync(idCourse, idSubcareer));
            DB.SaveChanges();



        }



        public async Task<List<SubCareerCourse>> GetAllSubCareerCourses()
        {
            return await DB.SubCareerCourse.ToListAsync();

        }






        public void UpdateSubCareerCourse(int? id, SubCareerCourse subCareerCourse)
        {
            DB.Entry(subCareerCourse).State = EntityState.Modified;
            DB.SaveChanges();
        }
    }
}
