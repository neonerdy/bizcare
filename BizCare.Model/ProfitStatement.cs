using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class ProfitStatement
    {
        public Guid ID { get; set; }

        public int RowNumber { get; set; }
        public string SalesItem { get; set; }
        public string PayablePaymentItem { get; set; }
        public decimal ThisMonth { get; set; }
        public decimal LastMonth { get; set; }
        public decimal Cumulative { get; set; }
        
    }
}
