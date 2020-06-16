using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerPath.Models.Entities;
using CareerPath.Models.Repository.IManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerPath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        IExamRepo Rp;

        public ExamController(IExamRepo _Rp)
        {
            Rp = _Rp;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllExams()
        {
            return Ok(await Rp.GetAllExams());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exams>> GetExamById(int id)
        {
            Exams exam = await Rp.GetExamById(id);
            if (exam == null)
                return NotFound();
            else
                return exam;
        }

        [HttpPost]
        public async Task<ActionResult> AddExam(Exams _exam)
        {
            Rp.CreateExam(_exam);
            return Created("Career Table", _exam);
        }
    }
}
