using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class DebtPayment
    {
        public Guid ID { get; set; }

        public string PaymentCode { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal TotalCash { get; set; }

        public decimal TotalBank { get; set; }

        public decimal TotalGiro { get; set; }

        public decimal TotalCorrection { get; set; }

        public decimal GrandTotal { get; set; }


        public string Notes { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public List<DebtPaymentItem> DebtPaymentItems { get; set; }

    }
}
