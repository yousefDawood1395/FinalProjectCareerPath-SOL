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
    public class CareerDb : ICareerRepo
    {

        ApplicationDbContext Db;

        public CareerDb(ApplicationDbContext _Db)
        {
            Db = _Db;
        }

        public async void AddCareer(Career _career)
        {
            await Db.Career.AddAsync(_career);
            Db.SaveChanges();
        }

        public async void DeleteCareer(int id)
        {
            Db.Career.Remove(await Db.Career.FindAsync(id));
            Db.SaveChanges();
        }

        public async void EditCareer(int id, Career _career)
        {
            var oldCareer = await Db.Career.FindAsync(id);
            oldCareer.CareerName = _career.CareerName;
            oldCareer.Description = _career.Description;
            //Db.Entry(_career).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public async Task<List<Career>> GetAllCareers()
        {
            return await Db.Career.ToListAsync();
        }

        public async Task<Career> GetCareerById(int id)
        {
            return await Db.Career.FindAsync(id);
        }

    }
}
