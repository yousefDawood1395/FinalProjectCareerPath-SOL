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
    public class ExamDb:IExamRepo
    {
        ApplicationDbContext Db;

        public ExamDb(ApplicationDbContext _Db)
        {
            Db = _Db;
        }

        public async void CreateExam(Exams _exam)
        {
            Db.Exams.Add(_exam);
            await Db.SaveChangesAsync();
        }

        public async Task<List<Exams>> GetAllExams()
        {
            return await Db.Exams.ToListAsync();
        }

        public async Task<Exams> GetExamById(int id)
        {
            return await Db.Exams.FindAsync(id);
        }

    }
}
