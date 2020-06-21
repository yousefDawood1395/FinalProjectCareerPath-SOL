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

        public async Task<List<CoursesWithSubCareers>> GetAllCoursesWithSubCareers()
        {

            var data =await (from s in DB.SubCareer
                        join sc in DB.SubCareerCourse on s.SubCareerId equals sc.SubCareerId
                        join c in DB.Course on sc.CourseId equals c.CourseId
                        select  new {courseId=c.CourseId, courseName=c.CourseName, subCareer=s.SubCareerId , Description = c.Description }).ToListAsync();

         List<CoursesWithSubCareers> coursesWithSub = new List<CoursesWithSubCareers>();

           foreach(var item in data)
            {

                CoursesWithSubCareers obj = new CoursesWithSubCareers()
                {
                    courseID = item.courseId,
                    courseName = item.courseName,
                    subCareerID = item.subCareer,
                    Description = item.Description
                };

                coursesWithSub.Add(obj);
                
            }
            

            return coursesWithSub;
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
