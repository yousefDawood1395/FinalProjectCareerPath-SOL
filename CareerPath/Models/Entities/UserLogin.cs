using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities
{
    public class UserLogin
    {
        public string UserName { get; set; }



        public string Password { get; set; }
    }
}
