using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class PayableBalance
    {
        public Guid ID { get; set; }
        
        public int BalanceYear { get; set; }
        
        public int BalanceMonth { get; set; }
        
        public string SalesCode { get; set; }
        
        public DateTime SalesDate { get; set; }
        
        public Guid CustomerId { get; set; }
        
        public Customer Customer { get; set; }
        
        public Guid SalesmanId { get; set; }
        
        public Salesman Salesman { get; set; }
        
        public int PaymentMethod { get; set; }
        
        public decimal GrandTotal { get; set; }
        
        public bool IsStatus { get; set; }
        
        public string Notes { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime ModifiedDate { get; set; }
        
        public string AmountInWords { get; set; }
        
        public DateTime DueDate { get; set; }

        public int TermOfPayment { get; set; }

        public List<PayableBalanceItem> PayableBalanceItems { get; set; } 


    }
}
