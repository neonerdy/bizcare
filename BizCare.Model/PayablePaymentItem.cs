using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class PayablePaymentItem
    {
        public Guid ID { get; set; }

        public Guid PayablePaymentId { get; set; }

        public Guid SalesId { get; set; }

        public Sales Sales { get; set; }

        public decimal Cash { get; set; }

        public decimal Bank { get; set; }

        public decimal Giro { get; set; }

        public string GiroNumber { get; set; }

        public decimal Correction { get; set; }

        public decimal Total { get; set; }

        public string Notes { get; set; }

    }
}
