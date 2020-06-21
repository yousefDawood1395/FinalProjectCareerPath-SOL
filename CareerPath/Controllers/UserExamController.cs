using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerPath.Data;
using CareerPath.Models.Entities;
using CareerPath.Models.Repository.IManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CareerPath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExamController : ControllerBase
    {
        IUserExamRepo Db;
        ApplicationDbContext context;
        private readonly UserManager<MyUser> userManager;

        public UserExamController(IUserExamRepo _Db , ApplicationDbContext _context, UserManager<MyUser> _userManager)
        {
            Db = _Db;
            context = _context;
            userManager = _userManager;

        }

        [HttpGet("getExamsOfUser/{userName}")]

        public async Task<IActionResult> getExamsOfUser(string userName)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await userManager.FindByNameAsync(userName);

            if (user == null)
                return NotFound(new { message = "There is no user with this userName" });

            return Ok(await Db.GetAllExamInfoAboutUser(userName));
        }
    }
}
