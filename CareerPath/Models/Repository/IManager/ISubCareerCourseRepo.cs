using CareerPath.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Repository.IManager
{
    public interface ISubCareerCourseRepo
    {
        public void Add(SubCareerCourse obj);

        public void DeleteSubCareerIDAndCourseID(SubCareerCourse subCareerCourse);
        public Task<List<SubCareerCourse>> GetAllSubCareerCourses();
        //public Task<SubCareerCourse> GetSubCareerCourseByID(int id);
        //public Task<SubCareerCourse> GetSubCareerCourseByName(string name);

        public void UpdateSubCareerCourse(int? id, SubCareerCourse subCareerCourse);


        public Task<List<CoursesWithSubCareers>> GetAllCoursesWithSubCareers();

    }
}
