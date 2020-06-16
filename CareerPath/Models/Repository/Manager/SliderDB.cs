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
    public class SliderDb : ISliderRepo
    {
        ApplicationDbContext Db;

        public SliderDb(ApplicationDbContext _Db)
        {
            Db = _Db;
        }
        public async void AddSlider(Slider _slider)
        {
            await Db.Slider.AddAsync(_slider);
            Db.SaveChanges();
        }

        public async void DeleteSlider(int id)
        {
            Db.Slider.Remove(await Db.Slider.FindAsync(id));
            Db.SaveChanges();
        }

        public async Task<List<Slider>> GetAllSliders()
        {
            return await Db.Slider.ToListAsync();
        }

        public async Task<Slider> GetSliderById(int id)
        {
            return await Db.Slider.FindAsync(id);
        }

        public async void UpdateSlider(int id, Slider _slider)
        {
            Db.Entry(_slider).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }
    }
}
