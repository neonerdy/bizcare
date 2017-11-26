using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class Inventory
    {
        public Guid ID { get; set; }

        public int ActiveMonth { get; set; }
        public int ActiveYear { get; set; }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public string CategoryName { get; set; }

        public int QtyBegin { get; set; }
        public decimal ValueBegin { get; set; }

        public int QtyIn { get; set; }
        public decimal PurchasePrice { get; set; }

        public int QtyAvailable { get; set; }
        public decimal ValueAverage { get; set; }
        public decimal ValueAvailable { get; set; }

        public int QtyOut { get; set; }
        public decimal SalesPrice { get; set; }

        public int QtyEnd { get; set; }
        public decimal ValueEnd { get; set; }

        public int QtyPlusCorrection { get; set; }
        public int QtyMinusCorrection { get; set; }
        public decimal ValuePlusCorrection { get; set; }
        public decimal ValueMinusCorrection { get; set; }
    }
}
