using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class BillReceiptItem
    {
        public Guid ID { get; set; }

        public Guid BillReceiptId { get; set; }

        public Guid SalesId { get; set; }

        public Sales Sales { get; set; }

        public decimal Total { get; set; }

        public string Notes { get; set; }
    }
}
