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
    public class SubcareerDb: IsubCareerRepo
    {
        ApplicationDbContext Db;

        public SubcareerDb(ApplicationDbContext _Db)
        {
            Db = _Db;
        }

        public async void AddSubcareer(SubCareer subCareer)
        {
            //SubCareer NewSubCareer = new SubCareer();
            //{
            //    NewSubCareer.CareerIdRef=subCareer.CareerIdRef ,

            //    NewSubCareer.

            //};
            Db.SubCareer.Add(subCareer);
            //await  Db.SubCareer.AddAsync(subCareer);
            Db.SaveChanges();
        }

        public async void deleteSubcareer(int id)
        {
            Db.SubCareer.Remove(await Db.SubCareer.FindAsync(id));
            Db.SaveChanges();

        }

        public async Task<List<SubCareer>> GetSubcareerByCareerID(int id)
        {
            //var data =await (from d in Db.SubCareer
            //            where d.Career.CareerId == id)
            //           .select d => new { }).ToListAsync();

            var data =await Db.SubCareer.Where(ww => ww.Career.CareerId == id)
                        .Select(ww => new SubCareer() { SubCareerId = ww.SubCareerId, SubCareerName = ww.SubCareerName, Description = ww.Description }).ToListAsync();

          

            return data;
        }

        public async Task<SubCareer> GetSubcareerById(int id)
        {
            return await Db.SubCareer.FindAsync(id);
        }

        public async Task<List<SubCareer>> GettallSubcareer()
        {
            return await Db.SubCareer.ToListAsync();
        }

        public void UpdateSubcareer(int? id, SubCareer subCareer)
        {
            Db.Entry(subCareer).State = EntityState.Modified;
            Db.SaveChanges();
        }


    }
}
