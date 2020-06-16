using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class MyRole:IdentityRole
    {
        public MyRole() : base()
        {
            UserCourse = new HashSet<UserCourse>();
            UserExam = new HashSet<UserExam>();
        }

        public MyRole(string roleName) : base(roleName)
        {

        }

        public string Description { get; set; }

        public virtual ICollection<UserCourse> UserCourse { get; set; }
        public virtual ICollection<UserExam> UserExam { get; set; }
        //public virtual SubCareer SubCareer { get; set; }
    }
}
