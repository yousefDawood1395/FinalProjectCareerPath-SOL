using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Repository.IGeneral
{
   public interface IGeneral<T>
    {
        public Task<List<T>> GetAll();
        public Task<T> GetByID(int id);

        public Task<T> GetByName(string Name);

        public void Add(T obj);
        public void Update(int? id, T obj);
        public void Delete(int id);
    }
}
