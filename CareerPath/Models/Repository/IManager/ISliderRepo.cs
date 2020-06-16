using CareerPath.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Repository.IManager
{
    public interface ISliderRepo
    {
        public Task<List<Slider>> GetAllSliders();

        public Task<Slider> GetSliderById(int id);

        public void AddSlider(Slider _slider);

        public void UpdateSlider(int id, Slider _slider);

        public void DeleteSlider(int id);
    }
}
