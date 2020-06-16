using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class QuestionExam
    {
        [Required]

        public int ExamId { get; set; }



        [Required]

        public int QuestId { get; set; }


        public string UserAnswer { get; set; }



        [MaxLength(150)]
        public string QuestName { get; set; }


        [MaxLength(50)]
        public string RightAns { get; set; }


        public virtual Exams Exam { get; set; }

        public virtual Questions Quest { get; set; }
    }
}
