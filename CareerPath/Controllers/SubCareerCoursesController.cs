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











        // PUT: api/SubCareerCourses/id
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateSubCareerCourse(int id, SubCareerCourse subCareerCourse)
        //{
        //    if (id != subCareerCourse.SubCareerId || id == null)
        //    {
        //        return BadRequest();
        //    }

        //    var data =await Context.SubCareerCourse.FindAsync(subCareerCourse.SubCareerId);
        //    if (data == null)
        //        return NotFound();


        //    try
        //    {
        //        Db.UpdateSubCareerCourse(id, subCareerCourse);
        //    }
        //    catch (Exception e)
        //    {

        //        Console.WriteLine(e);
        //        throw new TimeoutException("time exception out in subCareerCourse Controller Update");
        //    }

        //    return Ok(subCareerCourse);
        //}





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
