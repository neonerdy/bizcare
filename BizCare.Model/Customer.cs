using System;
using System.Collections.Generic;

namespace BizCare.Model
{
    public class Customer
    {
        public Guid ID { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string ContactPerson { get; set; }

        public string Notes { get; set; }

        public bool IsActive { get; set; }

        public decimal Plafon { get; set; }

        public int TermOfPayment { get; set; }

        public decimal FirstBalance { get; set; }

        public decimal LastBalance { get; set; }

        public decimal LastMonthPayment { get; set; }

        public decimal ThisMonthPayment { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
