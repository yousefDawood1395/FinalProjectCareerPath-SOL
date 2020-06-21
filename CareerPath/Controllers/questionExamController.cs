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
    public class questionExamController : ControllerBase
    {
        IquestionExam DB;
        ApplicationDbContext Context;
        public questionExamController(IquestionExam _DB , ApplicationDbContext _Context)
        {
            DB = _DB;
            Context = _Context;

        }

        [HttpGet]
        public async Task<ActionResult> GetAllQuestExam()
        {
            var s = await GetAllQuestExam();
            if (s == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(s);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetQuestExamById(int id)
        {
            var s = await DB.GetQuestExamById(id);
            if (s == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(s);
            }
        }




        [HttpPost("createExam")]

        public async Task<IActionResult> CreateExam([FromBody] CreateExam obj)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var course = await Context.Course.SingleOrDefaultAsync(ww => ww.CourseName == obj.CourseName);
            if (course == null)
                return NotFound(new { message = "there is no course with this name" });

                return Ok(await DB.CreateExam(obj));

            return BadRequest();


        }


        [HttpPost("answerExam")]
        public async Task<IActionResult> AnswerExam(AnswerExam obj)
        {
            if (ModelState.IsValid)
                return Ok(await DB.CorrectExam(obj));

            return BadRequest();
        }



    }
}
