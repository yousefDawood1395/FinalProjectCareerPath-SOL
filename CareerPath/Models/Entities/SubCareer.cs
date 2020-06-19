using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class SubCareer
    {
        public SubCareer()
        {
            SubCareerCourses = new HashSet<SubCareerCourse>();
            Users = new HashSet<MyUser>();
        }



        [Required]
        public int SubCareerId { get; set; }



        //[Required]
        [MaxLength(50)]
        public string SubCareerName { get; set; }



        //[Required]
        [MaxLength(200)]
        public string Description { get; set; }


        [ForeignKey("Career")]
        public int CareerIdRef { get; set; }

        public virtual Career Career { get; set; }

        public virtual ICollection<MyUser> Users { get; set; }

        public virtual ICollection<SubCareerCourse> SubCareerCourses { get; set; }
    }
}
