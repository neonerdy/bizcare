using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class SalesmanFee
    {
        public Guid ID { get; set; }

        public int ActiveYear { get; set; }
        
        public int ActiveMonth { get; set; }
        
        public Guid SalesmanId { get; set; }
        
        public Salesman Salesman { get; set; }
        
        public int FeePercentage { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime ModifiedDate { get; set; }
    
    }
}
