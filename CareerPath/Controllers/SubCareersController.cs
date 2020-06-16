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
    public class SubCareersController : ControllerBase
    {
        IsubCareerRepo Db;
        ApplicationDbContext Context;

        public SubCareersController(IsubCareerRepo _Db , ApplicationDbContext _Context)
        {
            Db = _Db;
            Context = _Context;
        }

        // GET: api/SubCareers
        [HttpGet]
        public async Task<IActionResult> GetSubCareer()
        {
            return Ok(await Db.GettallSubcareer());
        }

        // GET: api/SubCareers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCareer(int id)
        {
            if (id == null)
                return BadRequest();
            var data = await Db.GetSubcareerById(id);
            if (data == null)
                return NotFound();
            return Ok(data);

        }

        // PUT: api/SubCareers/5

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubCareer(int id, SubCareer subCareer)
        {
            //if (id == null)
            //    return BadRequest();

            if (id != subCareer.SubCareerId)
            {
                return BadRequest();
            }



            try
            {
                //var oldCarrer = await Context.SubCareer.SingleOrDefaultAsync(ww => ww.SubCareerId == id);
                //oldCarrer.Career.CareerId = subCareer.Career.CareerId;
                Db.UpdateSubcareer(id, subCareer);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new TimeoutException("time exception out in user Controller Update");

            }

            return Ok(subCareer);
        }

        // POST: api/SubCareers

        [HttpPost]
        public async Task<IActionResult> PostSubCareer(SubCareer subCareer)
        {
            if (subCareer == null)
                return BadRequest();

            var career = await Context.Career.SingleOrDefaultAsync(ww => ww.CareerId == subCareer.CareerIdRef);

            if (career == null)
                return NotFound();

            Db.AddSubcareer(subCareer);
            return Created("subCareer has been created", subCareer);
        }

        // DELETE: api/SubCareers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCareer(int id)
        {
            if (id == null)
                return BadRequest();

            var subCareer = await Db.GetSubcareerById(id);

            if (subCareer == null)
                return NotFound();

            Db.deleteSubcareer(id);
            return Ok(subCareer);
        }
    }
}
