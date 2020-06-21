using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class ReturnedExamCreated
    {
        public int ExamId { get; set; }
        public int QuestId { get; set; }
        public string UserAnswer { get; set; }
    }
}
