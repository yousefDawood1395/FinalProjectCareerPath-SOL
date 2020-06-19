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
    public class CoursePathController : ControllerBase
    {
        ICoursePathRepo Db;
        ApplicationDbContext Context;

        public CoursePathController(ICoursePathRepo _Db, ApplicationDbContext _context)
        {
            Db = _Db;
            Context = _context;
        }

        // GET: api/Sliders
        [HttpGet]
        public async Task<IActionResult> GetCoursePaths()
        {
            return Ok(await Db.GetAllCoursePath());
        }

        // GET: api/Sliders/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoursePath(int id)
        {
            if (id == null)
                return BadRequest();

            var course = await Db.GetCoursePathById(id);

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public IActionResult UpdateCoursePath(int id, CoursePath _coursePath)
        {
            if (id != _coursePath.Id || id == null)
                return BadRequest();

            try
            {
                Db.UpdateCoursePath(id, _coursePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new TimeoutException("time exception out in CoursePath Controller Update");
            }

            return Ok(_coursePath);
        }

        // POST: api/Courses
        [HttpPost]
        public IActionResult AddCoursePath(CoursePath _coursePath)
        {
            if (_coursePath == null)
                return BadRequest();

            Db.AddCoursePath(_coursePath);
            return Created("CoursePath has been added", _coursePath);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoursePath(int id)
        {
            if (id == null)
                return BadRequest();

            var data = await Context.CoursePaths.SingleOrDefaultAsync(ww => ww.Id == id);

            if (data == null)
                return NotFound();

            Db.DeleteCoursePath(id);
            return Ok(data);
        }
    }
}