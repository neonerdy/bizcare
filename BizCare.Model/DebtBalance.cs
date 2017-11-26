using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class DebtBalance
    {
        public Guid ID { get; set; }
        public int BalanceYear { get; set; }
        public int BalanceMonth { get; set; }
        public string PurchaseCode { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int PaymentMethod { get; set; }
        public decimal GrandTotal { get; set; }
        public bool IsStatus { get; set; }
        public string Notes { get; set; }       
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string AmountInWords { get; set; }
        public DateTime DueDate { get; set; }
        public int TermOfPayment { get; set; }
    }
}
