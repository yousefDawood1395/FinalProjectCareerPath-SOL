using CareerPath.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Repository.IManager
{
    public interface ICoursePathRepo
    {
        public Task<List<CoursePath>> GetAllCoursePath();

        public Task<CoursePath> GetCoursePathById(int id);

        public void AddCoursePath(CoursePath _coursePath);

        public void UpdateCoursePath(int id, CoursePath _coursePath);

        public void DeleteCoursePath(int id);
    }
}
