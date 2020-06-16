using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class UserCourse
    {
        [Required]

        public int UserId { get; set; }


        [Required]

        public int CourseId { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual Status Status { get; set; }
        public virtual MyUser User { get; set; }
    }
}
