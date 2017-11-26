using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
	public class Purchase
	{
        public Guid ID { get; set; }

        public string Code { get; set; }

        public DateTime Date { get; set; }

        public Guid SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public int PaymentMethod { get; set; }

        public bool Status { get; set; }

        public string Notes { get; set; }

        public decimal GrandTotal { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string AmountInWords { get; set; }

        public DateTime DueDate { get; set; }

        public int TermOfPayment { get; set; }

        public int PrintCounter { get; set; }

        public List<PurchaseItem> PurchaseItems { get; set; }
	}
}

