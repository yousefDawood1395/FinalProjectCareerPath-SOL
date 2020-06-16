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
    public class QuestionDb:IquestionRepo
    {
        ApplicationDbContext Db;

        public QuestionDb(ApplicationDbContext _Db)
        {
            Db = _Db;
        }

        public void AddQuestName(Questions questions)
        {
            Db.Questions.Add(questions);
            Db.SaveChanges();
        }

        public async void deleteQuestion(int id)
        {
            Db.Questions.Remove(await Db.Questions.FindAsync(id));
            Db.SaveChanges();
        }

        public async Task<Questions> GetQuestNameById(int id)
        {
            return await Db.Questions.FindAsync(id);
        }

        public async Task<List<Questions>> GettallQuestName()
        {
            return await Db.Questions.ToListAsync();
        }

        public void UpdateQuestion(int id, Questions questions)
        {
            Db.Entry(questions).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
