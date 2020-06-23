using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class MyUser:IdentityUser
    {
        public MyUser() : base()
        {
            UserCourse = new HashSet<UserCourse>();
            UserExam = new HashSet<UserExam>();
        }

        public MyUser(string name) : base(name)
        {

        }


        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Fname { get; set; }

        //[Required]
        [MaxLength(50)] // for DB
        [StringLength(50)] // for FrontEnd
        public string Lname { get; set; }


        //[Required(AllowEmptyStrings =true)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }


        [MaxLength(20)]
        public string UserLevel { get; set; }



        [MaxLength(250)]
        public string Description { get; set; }


        [Required]
        public string Country { get; set; }


        public string Image { get; set; }

        public virtual ICollection<UserCourse> UserCourse { get; set; }
        public virtual ICollection<UserExam> UserExam { get; set; }

        [ForeignKey("SubCareer")]
        public int SubCareerId { get; set; }
        public virtual SubCareer SubCareer { get; set; }
    }
}

