using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class UserExam
    {
        [Required]

        public int ExamId { get; set; }



        



        [Required]

        public int CourseId { get; set; }

        //[Required]
        public int? UserGrade { get; set; }

        //[Required]
        [MaxLength(10)]
        public string UserAnswer { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateTime { get; set; }

        public virtual Course Course { get; set; }
        public virtual Exams Exam { get; set; }


        [Required]
        [ForeignKey("MyUser")]
        public string UserId { get; set; }
        public virtual MyUser User { get; set; }
    }
}
