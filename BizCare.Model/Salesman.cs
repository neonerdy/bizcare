using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class Salesman
    {
        public Guid ID { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string Phone1 { get; set; }
        
        public string Phone2 { get; set; }
        
        public string Notes { get; set; }
        
        public bool IsActive { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime ModifiedDate { get; set; }
    }
}
