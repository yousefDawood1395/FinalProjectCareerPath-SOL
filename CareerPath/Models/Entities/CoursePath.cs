using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class CoursePath
    {
        public int Id { get; set; }
        public string Paths { get; set; }

        [Column(TypeName = "Money")]
        public decimal Payment { get; set; }

        public virtual Course Course { get; set; }
    }
}
