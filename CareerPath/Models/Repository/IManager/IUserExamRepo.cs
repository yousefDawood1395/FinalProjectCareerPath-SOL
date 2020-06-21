using CareerPath.Models.Entities;
using CareerPath.Models.Repository.IGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Repository.IManager
{
    public interface IUserExamRepo: IGeneral<UserExam>
    {
        public Task<List<ExamInfoAboutUser>> GetAllExamInfoAboutUser(string UserName);
    }
}
