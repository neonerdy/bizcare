using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class StockCorrectionItem
    {
        public Guid ID { get; set; }

        public Guid StockCorrectionId { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public int QtyPlus { get; set; }

        public int QtyMinus { get; set; }

        public decimal ValuePlus { get; set; }

        public decimal ValueMinus { get; set; }

        public string Notes { get; set; }
    }
}
