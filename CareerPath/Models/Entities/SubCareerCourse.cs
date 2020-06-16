using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class SubCareerCourse
    {
        [Required]
        public int SubCareerId { get; set; }


        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual SubCareer SubCareer { get; set; }
    }
}
