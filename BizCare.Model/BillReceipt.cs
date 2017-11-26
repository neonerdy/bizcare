using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class BillReceipt
    {
        public Guid ID { get; set; }

        public string Code { get; set; }

        public DateTime BillReceiptDate { get; set; }

        public Guid SalesmanId { get; set; }

        public Salesman Salesman { get; set; }

        public decimal GrandTotal { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public int PrintCounter { get; set; }

        public List<BillReceiptItem> BillReceiptItems { get; set; }
    }
}
