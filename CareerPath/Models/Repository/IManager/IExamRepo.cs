using CareerPath.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Repository.IManager
{
    public interface IExamRepo
    {
        public Task<List<Exams>> GetAllExams();

        public Task<Exams> GetExamById(int id);

        public void CreateExam(Exams _exam);
    }
}
