using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class ExamInfoAboutUser
    {
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public string UserName { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public DateTime DateTime { get; set; }
    }
}
