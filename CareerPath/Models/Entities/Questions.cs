using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class Questions
    {
        public Questions()
        {
            QuestExam = new HashSet<QuestionExam>();

        }


        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestId { get; set; }

        //[Required]
        [MaxLength(150)]
        public string QuestName { get; set; }


        //[Required]
        public int? Grade { get; set; }

        //[Required]
        [MaxLength(150)]
        public string A { get; set; }


        //[Required]
        [MaxLength(150)]
        public string B { get; set; }



        //[Required]
        [MaxLength(150)]
        public string C { get; set; }


        //[Required]
        [MaxLength(50)]
        public string RightAns { get; set; }
        public virtual ICollection<QuestionExam> QuestExam { get; set; }

        [ForeignKey("Course")]
        public int courseIdRef { get; set; }
        public virtual Course Course { get; set; }
    }
}
