using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class RecordCounter
    {
        public Guid ID { get; set; }
        
        public int ActiveYear { get; set; }
       
        public int ActiveMonth { get; set; }
        
        public int SalesCounter { get; set; }
        
        public int PurchaseCounter { get; set; }
        
        public int ExpenseCounter { get; set; }
        
        public int PayablePaymentCounter { get; set; }
        
        public int DebtPaymentCounter { get; set; }
        
        public int BillReceiptCounter { get; set; }

        public int StockCorrectionCounter { get; set; }
        
        public bool ClosingStatus { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime ModifiedDate { get; set; }
    }
}
