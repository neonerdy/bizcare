using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class UserLogin
    {
        public Guid ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public bool IsAdministrator { get; set; }

        public string Notes { get; set; }

        public DateTime LastLogin { get; set; }

        public DateTime CreatedDate { get; set; }
        
    }
}
