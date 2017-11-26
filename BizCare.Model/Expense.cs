using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class Expense
    {
        public Guid ID { get; set; }

        public string Code { get; set; }

        public DateTime Date { get; set; }

        public String AccountType { get; set; }

        public string AccountName { get; set; }

        public string AccountNumber { get; set; }
        
        public decimal GrandTotal { get; set; }

        public string Notes { get; set; }

        public string AmountInWords { get; set; }

        public int PrintCounter { get; set; }
    
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public List<ExpenseItem> ExpenseItems { get; set; }

    }
}
