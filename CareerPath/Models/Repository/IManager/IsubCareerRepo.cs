using CareerPath.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Repository.IManager
{
    public interface IsubCareerRepo
    {
        public Task<List<SubCareer>> GettallSubcareer();
        public Task<SubCareer> GetSubcareerById(int id);

        public void AddSubcareer(SubCareer subCareer);
        public void UpdateSubcareer(int? id, SubCareer subCareer);
        public void deleteSubcareer(int id);
    }
}
