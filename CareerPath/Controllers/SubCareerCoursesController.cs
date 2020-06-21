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
    public class SubCareerCoursesController : ControllerBase
    {
        ISubCareerCourseRepo Db;
        ApplicationDbContext Context;

        public SubCareerCoursesController(ISubCareerCourseRepo _Db , ApplicationDbContext _Context)
        {
            Db = _Db;
            Context = _Context;

        }

        // GET: api/SubCareerCourses
        [HttpGet]
        //[Route]
        public async Task<IActionResult> GetSubCareerCourse()
        {
            return Ok(await Db.GetAllSubCareerCourses());
        }


        [HttpGet("withSubCareer")]

        public async Task<IActionResult> GetAllCoursesWithSubCareers()
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(await Db.GetAllCoursesWithSubCareers());
        }













        [HttpPost]

        public async Task<IActionResult> AddSubCareerCourse(SubCareerCourse subCareerCourse)
        {
            if (subCareerCourse == null)
                return BadRequest();

            var subCareer = await Context.SubCareer.FindAsync(subCareerCourse.SubCareerId);

            var course = await Context.Course.FindAsync(subCareerCourse.CourseId);

            if (subCareer == null || course == null)
            {
                return NotFound();
            }

            var data = await Context.SubCareerCourse.SingleOrDefaultAsync(ww => ww.SubCareerId == subCareerCourse.SubCareerId && ww.CourseId == subCareerCourse.CourseId);

            if (data != null)
                return BadRequest("sub career course already exist");

            Db.Add(subCareerCourse);
            return Ok(subCareerCourse);

        }




        // DELETE: api/SubCareerCourses/id
        [HttpDelete]
        public async Task<IActionResult> DeleteAndSubCareerIDByCourseID(SubCareerCourse subCareerCourse)
        {
            if (subCareerCourse == null)
                return BadRequest();


            var subCareer = await Context.SubCareer.FindAsync(subCareerCourse.SubCareerId);

            var course = await Context.Course.FindAsync(subCareerCourse.CourseId);

            if (subCareer == null || course == null)
            {
                return NotFound();
            }

            var data = await Context.SubCareerCourse.SingleOrDefaultAsync(ww => ww.SubCareerId == subCareerCourse.SubCareerId && ww.CourseId == subCareerCourse.CourseId);

            if (data == null)
                return NotFound();


            Db.DeleteSubCareerIDAndCourseID(subCareerCourse);
            return Ok(data);


        }

    }
}
