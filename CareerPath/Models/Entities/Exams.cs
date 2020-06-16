using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class Exams
    {
        public Exams()
        {
            QuestExam = new HashSet<QuestionExam>();
            UserExam = new HashSet<UserExam>();
        }

        [Required]

        public int ExamId { get; set; }



        //[Required]
        [MaxLength(50)]
        public string ExamName { get; set; }


        //[Required]
        public int? TotalGrade { get; set; }


        //[Required]
        public int? ExamDuration { get; set; }

        public int? userGrade { get; set; }

        [Required]
        public DateTime dateTime { get; set; }

        public virtual ICollection<QuestionExam> QuestExam { get; set; }
        public virtual ICollection<UserExam> UserExam { get; set; }

        public virtual Course Course { get; set; }
    }
}
