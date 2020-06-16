using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class Career
    {
        public Career()
        {
            SubCareer = new HashSet<SubCareer>();
        }

        [Required]

        public int CareerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CareerName { get; set; }


        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        public virtual ICollection<SubCareer> SubCareer { get; set; }
    }
}
