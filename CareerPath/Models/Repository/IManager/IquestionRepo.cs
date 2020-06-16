using CareerPath.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Repository.IManager
{
    public interface IquestionRepo
    {
        public Task<List<Questions>> GettallQuestName();
        public Task<Questions> GetQuestNameById(int id);

        public void AddQuestName(Questions questions);
        public void UpdateQuestion(int id, Questions questions);
        public void deleteQuestion(int id);

    }
}
