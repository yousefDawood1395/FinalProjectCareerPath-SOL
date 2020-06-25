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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CareerPath.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using CareerPath.Models.Upload;
using CareerPath.Models.Entities.Helper;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

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
        public static IWebHostEnvironment _environment;





        public UserController(
            SignInManager<MyUser> signInManage,
            UserManager<MyUser> userManager,
            RoleManager<MyRole> roleManage,
            IOptions<ApplicationSetting> AppSetting,
            ApplicationDbContext Db,
            IWebHostEnvironment environment)
        {
            _signInManager = signInManage;
            _userManager = userManager;
            _roleManager = roleManage;
            _AppSetting = AppSetting.Value;
            _Db = Db;
            _environment = environment;


        }



        [HttpPost]
        [Route("Register")]
        //[EnableCors]
        // Post api/user/register
        public async Task<object> Register([FromForm] FileUpload obj, [FromForm] MyUser model)
        {
            string imageName = null;
            if (!ModelState.IsValid)
                return BadRequest(new { messaget = "invalid registeration info" });

            try
            {


                //var Len = obj.Files.Length;


                if (obj.Files != null)
                {
                    string Ext = Path.GetExtension(obj.Files.FileName);

                    if ((Ext == ".jpg" || Ext == ".png"))
                    {


                        if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                        {
                            Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                        }

                        imageName = Guid.NewGuid().ToString() + "-" + obj.Files.FileName;
                        //var FilePath = Path.Combine(uploadDir)
                        using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + imageName))
                        {
                            await obj.Files.CopyToAsync(fileStream);
                            await fileStream.FlushAsync();

                            //imageName = obj.Files.FileName;

                        }
                    }

                }
                //else
                //{
                //    //return BadRequest(new { message = "you should upload a photo" });

                //    imageName = null;
                //}

            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }

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
                Image = imageName,
                SubCareerId = model.SubCareerId,
                UserStatus = "UnCompleted",

            };

            var result = await _userManager.CreateAsync(user, model.PasswordHash);

            //Assign Roles 

            var userdata = await _userManager.FindByNameAsync(model.UserName);

            IdentityResult createdRole;

            if (userdata.UserName == "admin")
            {
                createdRole = await _userManager.AddToRoleAsync(userdata, "admin");
            }
            else
            {
                createdRole = await _userManager.AddToRoleAsync(userdata, "student");
            }


            if (result.Succeeded && createdRole.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);


                //Assign Token 

                var key = Encoding.UTF8.GetBytes(_AppSetting.JWT_Secret);

                var retrievedUser = await _userManager.FindByNameAsync(model.UserName);

                //var role = await _roleManager.FindByIdAsync("1");

                var role = await _userManager.GetRolesAsync(retrievedUser);

                if (retrievedUser != null && await _userManager.CheckPasswordAsync(retrievedUser, model.PasswordHash))
                {
                    var token = TokenHelper.CreateToken(retrievedUser, key);
                    var roleOfUser = role;
                    return Ok(new { UserId = userdata.Id, SubCareerId = userdata.SubCareerId, Token = token, role = roleOfUser });
                }

            }

            return BadRequest("UserName Already Exist .. Try Again");


        }


        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] UserLogin model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { messaget = "invalid registeration info" });

            var key = Encoding.UTF8.GetBytes(_AppSetting.JWT_Secret);

            var retrievedUser = await _userManager.FindByNameAsync(model.UserName);
            if (retrievedUser == null)
                return NotFound(new { message = "your userName is inCorrect" });

            var result = await _userManager.CheckPasswordAsync(retrievedUser, model.Password);
            if(!result)
            {
                return NotFound(new { message = "your password is incorrect" });
            }

            if (retrievedUser != null )
            {
                var token = TokenHelper.CreateToken(retrievedUser, key);
                var role = await _userManager.GetRolesAsync(retrievedUser);
                //var roleOfUser = ;
                return Ok(new { UserId = retrievedUser.Id, Token = token,  roleOfUser=role });
            }

            else
            {
                return BadRequest(new { message = "Login Information Not Valid" });
            }
        }

        [HttpGet]
        [Route("GetProfile")]
        [Authorize]

        public async Task<Object> GetProfile()
        {
            string UserId = User.Claims.FirstOrDefault(ww => ww.Type == "UserId").Value;
            var UserData = await _userManager.FindByIdAsync(UserId);

            var userCourse = (from u in _Db.Users
                              join uc in _Db.UserCourse on u.Id equals UserId
                              join c in _Db.Course on uc.CourseId equals c.CourseId
                              select c);

            string nullable = null;
            var courseName = nullable;
            var courseID = nullable;

            foreach (var d in userCourse)
            {
                courseName += d.CourseName + ", ";
                courseID += d.CourseId + ", ";
            }
            if (courseName == null || courseID == null)
            {
                return (new { UserData, Info = "User doesn't Have any Courses Yet ." });


            }

            var UserExam = (from e in _Db.UserExam
                            join u in _Db.Users on e.UserId equals u.Id
                            join c in _Db.Course on e.CourseId equals c.CourseId
                            select e);
            var examOfUser = nullable;
            var examCourseId = nullable;
            var examCourseName = nullable;

            foreach (var e in UserExam)
            {
                examOfUser += e.ExamId + ", ";
                examCourseId += e.CourseId + ", ";
                examCourseName += e.Course.CourseName + ", ";
            }
            if (examOfUser == null)
            {
                return (new { UserData, courseName = courseName, CourseId = courseID, Info = "User doesn't have any Exam Yet ." });
            }

            return (new { UserData, courseName = courseName, CourseId = courseID, userExam = examOfUser, ExamCourseId = examCourseId, ExamCourseName = examCourseName });
        }



        [HttpGet("GetUserByID/{id}")]

        public async Task<IActionResult> GetUserByID(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "there is no user with this ID" });

            return Ok(user);
        }


        [HttpPut]
        [Route("EditProfile")]
        [Authorize]

        public async Task<IActionResult> UpdateProfile([FromForm] FileUpload obj , [FromBody] MyUser model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "invalid Edited Information" });


            var retrievedUser =await  _userManager.FindByIdAsync(model.Id);
            if (retrievedUser == null)
                return NotFound(new { message = "invalid Edited Information User Not Found" });

            //var result = await _userManager.CheckPasswordAsync(retrievedUser, model.PasswordHash);
            

            string imageName = retrievedUser.Image;

            if(obj.Files!=null)
            {
                string Ext = Path.GetExtension(obj.Files.FileName);

                if ((Ext == ".jpg" || Ext == ".png"))
                {


                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }

                    imageName = Guid.NewGuid().ToString() + "-" + obj.Files.FileName;
                    //var FilePath = Path.Combine(uploadDir)
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + imageName))
                    {
                        await obj.Files.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();

                        //imageName = obj.Files.FileName;

                    }
                }

            }
            
           
            if(retrievedUser!= null  )
            {


                retrievedUser.UserName = model.UserName;
                //retrievedUser.PasswordHash = model.NewPassword;
                retrievedUser.Email = model.Email;
                retrievedUser.Fname = model.Fname;
                retrievedUser.Lname = model.Lname;
                retrievedUser.PhoneNumber = model.PhoneNumber;
                retrievedUser.UserLevel = model.UserLevel;
                retrievedUser.Country = model.Country;
                retrievedUser.Description = model.Description;
                retrievedUser.Image = imageName;
                retrievedUser.UserStatus = "UnCompleted";


                //await _userManager.ChangePasswordAsync(retrievedUser, model.PasswordHash, model.NewPassword);
                //model.NewPassword = null;

                   

            }
            try
            {

            var EditedUser = await _userManager.UpdateAsync(retrievedUser);

                if(EditedUser.Succeeded)
            return Ok( new {status= EditedUser , message="you have successfuly updated your profile information"});

                else
                {
                    return BadRequest("there is already userName with this name");
                }
            }catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }


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


        [HttpPut("EditUserLevel")]
        public async Task<IActionResult> EditUserLevel(EditUserLevel editUser)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = await _userManager.FindByIdAsync(editUser.UserID);

            if (user == null)
                return NotFound(new { message = "there is no user with this id" });

            user.UserLevel = editUser.UserLevel;

            try
            {


            var EditedUser = await _userManager.UpdateAsync(user);
            }catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }


            return Ok(editUser);

        }

        [HttpPut("EditUserStatus")]
        public async Task<IActionResult> EditUserStatus (EditUserStatus editUserStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = await _userManager.FindByIdAsync(editUserStatus.UserID);
            if (user == null)
                return NotFound(new { message = "there is no user with this id" });

            user.UserStatus = editUserStatus.UserStatus;

            try
            {


                var EditedUser = await _userManager.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }


            return Ok(editUserStatus);

        }


        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePassword(changePassword obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = await _userManager.FindByIdAsync(obj.UserID);

            if (user == null)
                return NotFound(new { messaeg = "there is no user with this id" });


            var result = await _userManager.CheckPasswordAsync(user, obj.oldPassword);

            if (!result)
                return BadRequest(new { message = "incorrect password" });


            //user.PasswordHash = obj.oldPassword;
            //user.NewPassword = obj.newPassword;


          IdentityResult checkedPasswordResult =  await _userManager.ChangePasswordAsync(user, obj.oldPassword,obj.newPassword);
            if(checkedPasswordResult.Succeeded)
            {

            //user.NewPassword = null;


            try
            {

                var EditedUser = await _userManager.UpdateAsync(user);

                return Ok(new { status = EditedUser, message = "you have successfuly updated your password" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
            }
            else
            {
                return BadRequest(new { message = "There is an problem Occured Please try again Later" });
            }


        }



    }

}
