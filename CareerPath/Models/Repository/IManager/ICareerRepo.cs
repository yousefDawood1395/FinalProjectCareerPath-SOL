using CareerPath.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Repository.IManager
{
  public  interface ICareerRepo
    {
        public Task<List<Career>> GetAllCareers();

        public Task<Career> GetCareerById(int id);

        public void AddCareer(Career _career);

        public void EditCareer(int id, Career _career);

        public void DeleteCareer(int id);
    }
}
