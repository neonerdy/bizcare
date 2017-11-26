using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class Company
    {
        public Guid ID { get; set; }
        
        public string Code { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string Phone1 { get; set; }
        
        public string Phone2 { get; set; }
        
        public string Fax { get; set; }
        
        public string Email { get; set; }

        public string Notes { get; set; }
        
        public int ReportDivider { get; set; }
        
        public DateTime FirstUsedDate { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime ModifiedDate { get; set; }
    }
}
