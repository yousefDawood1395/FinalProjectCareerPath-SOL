using CareerPath.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Repository.IManager
{
    public interface IquestionExam
    {
        public Task<List<QuestionExam>> GetAllQuestExam();

        public Task<QuestionExam> GetQuestExamById(int id);

        public void AddQuestExam(QuestionExam questExam);

        public void EditQuestExam(int id, QuestionExam questExam);

        public Task<List<QuestionExam>> CreateExam(CreateExam createExam);

        public Task<List<UserGrade>> CorrectExam(AnswerExam obj);
    }
}
