using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class Status
    {
        public Status()
        {
            UserCourse = new HashSet<UserCourse>();
        }


        [Required]
        public int StatusId { get; set; }

        [Required]
        [MaxLength(20)]
        public string StatusName { get; set; }

        public virtual ICollection<UserCourse> UserCourse { get; set; }
    }
}
