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
    public class CoursesController : ControllerBase
    {
        ICourseRepo Db;
        ApplicationDbContext Context;
        public CoursesController(ICourseRepo _Db , ApplicationDbContext _Context)
        {
            Db = _Db;
            Context = _Context;
        }


        // GET: api/Courses
        [HttpGet]
        public async Task<IActionResult> GetCourse()
        {
            return Ok(await Db.GetAllCourses());
        }



        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            if (id == null)
                return BadRequest();

            var course = await Db.GetCourseById(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }



        // PUT: api/Courses/5

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, Course course)
        {
            if (id != course.CourseId || id == null)
            {
                return BadRequest();
            }

            try
            {
                Db.UpdateCourse(id, course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new TimeoutException("time exception out in Cource Controller Update");

            }

            return Ok(course);
        }




        // POST: api/Courses
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            if (course == null)
                return BadRequest();

            Db.AddCourse(course);
            return Created("course has been added", course);
        }



        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {

            if (id == null)
                return BadRequest();


            var data = await Context.Course.SingleOrDefaultAsync(ww => ww.CourseId == id);



            if (data == null)
                return NotFound();

            Db.DeleteCourse(id);
            return Ok(data);
        }

    }

}
