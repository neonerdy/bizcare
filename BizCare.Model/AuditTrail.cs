using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class AuditTrail
    {
        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public string Action { get; set; }

        public string Module { get; set; }

        public string Description { get; set; }


    }
}
