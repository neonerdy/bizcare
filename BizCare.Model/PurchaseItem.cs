using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class PurchaseItem
    {
        public Guid ID { get; set; }

        public Guid PurchaseId { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public int Qty { get; set; }

        public decimal Price { get; set; }

        public string Notes { get; set; }
    }
}
