using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerPath.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using CareerPath.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CareerPath.Data;
using Microsoft.AspNetCore.Authorization;
using CareerPath.Models.Repository.IManager;

namespace CareerPath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerController : ControllerBase
    {


        private readonly ICareerRepo Rp;

        public CareerController(ICareerRepo _Rp)
        {
            Rp = _Rp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCareers()
        {
            return Ok(await Rp.GetAllCareers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Career>> GetCareerById(int id)
        {
            Career career = await Rp.GetCareerById(id);
            if (career == null)
                return NotFound();
            else
                return Ok(career);
        }

        [HttpPost]
        public async Task<ActionResult> AddCareer(Career _career)
        {
            Rp.AddCareer(_career);
            return Created("Career Table", _career);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditCareer(int id, Career _career)
        {
            if (_career == null || _career.CareerId != id)
                return BadRequest();

            var oldCareer = await Rp.GetCareerById(id);
            if (oldCareer == null)
                return NotFound();


            Rp.EditCareer(id, _career);
            return Ok(_career);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCareer(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var career = await Rp.GetCareerById(id);
            if (career == null)
                return NotFound();
            Rp.DeleteCareer(id);
            return Ok();
        }



    }

}
