using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class Course
    {
        public Course()
        {
            SubCareerCourses = new HashSet<SubCareerCourse>();
            UserCourse = new HashSet<UserCourse>();
            UserExam = new HashSet<UserExam>();
            Exams = new HashSet<Exams>();
            Questions = new HashSet<Questions>();
            CoursePaths = new HashSet<CoursePath>();
        }

        [Required]
        public int CourseId { get; set; }


        //[Required]
        [MaxLength(50)]
        public string CourseName { get; set; }


        //[Required]
        [MaxLength(250)]
        public string CourseContent { get; set; }


        //[Required]
        [MaxLength(250)]
        public string Description { get; set; }


        //[Required]
        [MaxLength(50)]
        public string Duration { get; set; }

        public string Level { get; set; }
        public int OrderNumber { get; set; }

        public virtual ICollection<SubCareerCourse> SubCareerCourses { get; set; }
        public virtual ICollection<UserCourse> UserCourse { get; set; }
        public virtual ICollection<UserExam> UserExam { get; set; }

        public virtual ICollection<Exams> Exams { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<CoursePath> CoursePaths { get; set; }
    }
}
