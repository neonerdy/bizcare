using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public enum AccountType
    {
        Cash, Bank, CreditCard, Giro
    }

    public class ExpenseItem
    {
        public Guid ID { get; set; }

        public Guid ExpenseId { get; set; }

        public decimal Total { get; set; }

        public string Notes { get; set; }

    }
}
