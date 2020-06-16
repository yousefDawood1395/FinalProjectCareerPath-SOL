using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerPath.Data;
using CareerPath.Models.Entities;
using CareerPath.Models.Repository.IManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareerPath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        ISliderRepo Db;
        ApplicationDbContext Context;

        public SliderController(ISliderRepo _Db, ApplicationDbContext _context)
        {
            Db = _Db;
            Context = _context;
        }

        // GET: api/Sliders
        [HttpGet]
        public async Task<IActionResult> GetSliders()
        {
            return Ok(await Db.GetAllSliders());
        }

        // GET: api/Sliders/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlider(int id)
        {
            if (id == null)
                return BadRequest();

            var course = await Db.GetSliderById(id);

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public IActionResult UpdateSlider(int id, Slider _slider)
        {
            if (id != _slider.SliderID || id == null)
                return BadRequest();

            try
            {
                Db.UpdateSlider(id, _slider);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new TimeoutException("time exception out in Slider Controller Update");
            }

            return Ok(_slider);
        }

        // POST: api/Courses
        [HttpPost]
        public IActionResult AddSlider(Slider _slider)
        {
            if (_slider == null)
                return BadRequest();

            Db.AddSlider(_slider);
            return Created("course has been added", _slider);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            if (id == null)
                return BadRequest();

            var data = await Context.Slider.SingleOrDefaultAsync(ww => ww.SliderID == id);

            if (data == null)
                return NotFound();

            Db.DeleteSlider(id);
            return Ok(data);
        }
    }
}