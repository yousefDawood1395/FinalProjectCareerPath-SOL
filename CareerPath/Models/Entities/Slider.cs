using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class Slider
    {
        public int SliderID { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        public string Image { get; set; }

    }
}
