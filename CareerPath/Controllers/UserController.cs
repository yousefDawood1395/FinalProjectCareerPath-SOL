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
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace CareerPath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors]
    public class UserController : ControllerBase
    {

        private readonly SignInManager<MyUser> _signInManager;
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<MyRole> _roleManager;
        private readonly ApplicationSetting _AppSetting;
        private readonly ApplicationDbContext _Db;





        public UserController(
            SignInManager<MyUser> signInManage,
            UserManager<MyUser> userManager,
            RoleManager<MyRole> roleManage,
            IOptions<ApplicationSetting> AppSetting,
            ApplicationDbContext Db)
        {
            _signInManager = signInManage;
            _userManager = userManager;
            _roleManager = roleManage;
            _AppSetting = AppSetting.Value;
            _Db = Db;

        }



        [HttpPost]
        [Route("Register")]
        //[EnableCors]
        // Post api/user/register
        public async Task<object> Register([FromBody] MyUser model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { messaget = "invalid registeration info"});

            var user = new MyUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Fname = model.Fname,
                Lname = model.Lname,
                PhoneNumber = model.PhoneNumber,
                UserLevel = model.UserLevel,
                Country = model.Country,
                Description = model.Description,
                Image = model.Image
            };

        var result =await _userManager.CreateAsync(user, model.PasswordHash);

            //Assign Roles 

            var userdata = await _userManager.FindByNameAsync(model.UserName);


          var createdRole =  await _userManager.AddToRoleAsync(userdata, "student");





            if(result.Succeeded && createdRole.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);


            //Assign Token 

            var key = Encoding.UTF8.GetBytes(_AppSetting.JWT_Secret);

            var retrievedUser = await _userManager.FindByNameAsync(model.UserName);

            //var r = await _roleManager.FindByNameAsync(model.UserName);

                if (retrievedUser != null && await _userManager.CheckPasswordAsync(retrievedUser, model.PasswordHash))
            {
                var token = TokenHelper.CreateToken(retrievedUser, key);
                var roleOfUser = "student";
                return Ok(new { Token = token, role = roleOfUser });
            }

            }

            return BadRequest("UserName Already Exist .. Try Again");


        }


        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] MyUser model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { messaget = "invalid registeration info" });

            var key = Encoding.UTF8.GetBytes(_AppSetting.JWT_Secret);

            var retrievedUser = await _userManager.FindByNameAsync(model.UserName);

            if(retrievedUser != null && await _userManager.CheckPasswordAsync(retrievedUser,model.PasswordHash))
            {
                var token = TokenHelper.CreateToken(retrievedUser, key);
                var roleOfUser = "student";
                return Ok(new { Token = token, role = roleOfUser });
            }

            else
            {
                return BadRequest(new { message = "Login Information Not Valid" });
            }
        }

        [HttpGet]
        [Route("GetProfile")]
        [Authorize]

        public async Task <Object> GetProfile()
        {
            string UserId = User.Claims.FirstOrDefault(ww => ww.Type == "UserId").Value;
            var UserData = await _userManager.FindByIdAsync(UserId);
            return UserData;
        }


        [HttpPut]
        [Route("EditProfile")]
        [Authorize]

        public async Task<IActionResult> UpdateProfile([FromBody]MyUser model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "invalid Edited Information" });


            var user =await  _userManager.FindByIdAsync(model.Id);
            if (user == null)
                return NotFound(new { message = "invalid Edited Information User Not Found" });

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Fname = model.Fname;
            user.Lname = model.Lname;
            user.PhoneNumber = model.PhoneNumber;
            user.UserLevel = model.UserLevel;
            user.Country = model.Country;
            user.Description = model.Description;
            user.Image = model.Image;


            var EditedUser = await _userManager.UpdateAsync(user);
            return Ok(EditedUser);

        }


        [HttpGet]
        [Route("GetAllUsers")]

        public async Task<IActionResult> GetAllUsers()
        {
         List<MyUser> AllUsers=  await _Db.Users.ToListAsync();

            return Ok(AllUsers);
        }


        [HttpDelete("{id}")]
        [Route("DeleteUser")]

        public async Task<IActionResult> DeleteUser([FromHeader] string id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //var user =await _Db.Users.FindAsync(id);

            var user =await _userManager.FindByIdAsync(id);

            

            if (user == null)
                return NotFound();

           

            return Ok(await _userManager.DeleteAsync(user));
        }

       

    }

}
