using CareerPath.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Repository.IManager
{
    public  interface ICourseRepo
    {
        public Task<List<Course>> GetAllCourses();

        public Task<Course> GetCourseById(int id);

        public void AddCourse(Course _course);

        public void UpdateCourse(int id, Course _course);

        public void DeleteCourse(int id);
    }
}
