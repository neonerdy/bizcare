using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class StockCorrection
    {
        public Guid ID { get; set; }

        public string Code { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public int PrintCounter { get; set; }
    
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public List<StockCorrectionItem> StockCorrectionItems { get; set; }
    }
}
