using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CareerPath.Data;
using CareerPath.Models.Entities;
using CareerPath.Models.Repository.IManager;
using CareerPath.Models.Upload;
using Microsoft.AspNetCore.Hosting;
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
        public static IWebHostEnvironment _environment;


        public SliderController(ISliderRepo _Db, ApplicationDbContext _context , IWebHostEnvironment environment)
        {
            Db = _Db;
            Context = _context;
            _environment = environment;
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
        public async Task<IActionResult>  AddSlider([FromForm] FileUpload obj,[FromForm] Slider _slider)
        {
            string imageName = null;
            if (_slider == null)
                return BadRequest();

            if (obj.Files == null)
                return BadRequest(new { message = "you should enter a picture for your slider" });

            if (obj.Files != null)
            {
                string Ext = Path.GetExtension(obj.Files.FileName);

                if ((Ext == ".jpg" || Ext == ".png"))
                {


                    if (!Directory.Exists(_environment.WebRootPath + "\\Slider\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Slider\\");
                    }

                    imageName = Guid.NewGuid().ToString() + "-" + obj.Files.FileName;
                    //var FilePath = Path.Combine(uploadDir)
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Slider\\" + imageName))
                    {
                        await obj.Files.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();

                        //imageName = obj.Files.FileName;

                    }
                }

            }

            var slider = new Slider()
            {
                Image = imageName,
                Description = _slider.Description,
                Link = _slider.Link,
                Title = _slider.Title,

            };

            Db.AddSlider(slider);
            return Created("Slider has been added", slider);
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