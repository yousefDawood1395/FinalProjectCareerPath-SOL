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
    public class questionController : ControllerBase
    {
        IquestionRepo Q;
        public questionController(IquestionRepo _Q)
        {
            Q = _Q;

        }

        [HttpGet]
        public async Task<ActionResult> GettallQuestName()
        {
            return Ok(await Q.GettallQuestName());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetQuestNameById(int id)
        {
            if (id == null)
                return BadRequest();

            var s = await Q.GetQuestNameById(id);
            if (s == null)
            {
                return NotFound();
            }

            return Ok(s);
        }



        [HttpPost]

        public IActionResult AddQuestName(Questions questions)
        {
            if (questions == null)
                return BadRequest();

            Q.AddQuestName(questions);
            return Created("added", questions);
        }



        [HttpPut("{id}")]
        public ActionResult UpdateQuestion(int id, Questions questions)
        {
            if (id != questions.QuestId || id == null)
            {
                return BadRequest();
            }

            try
            {
                Q.UpdateQuestion(id, questions);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new TimeoutException("time exception out in Cource Controller Update");

            }
            return Ok(questions);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestions(int id)
        {
            if (id == null)
                return BadRequest();

            var question = await Q.GetQuestNameById(id);
            if (question == null)
                return NotFound();

            Q.deleteQuestion(id);
            return Ok(question);
        }
    }
}
