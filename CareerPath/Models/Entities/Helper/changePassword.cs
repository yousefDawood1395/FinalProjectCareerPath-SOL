using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Entities.Helper
{
    public class changePassword
    {
        public string UserID { get; set; }
        public string  oldPassword { get; set; }
        public string newPassword { get; set; }

    }

}
