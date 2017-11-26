using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class Sale
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int SalesmanId { get; set; }

        public Salesman Salesman { get; set; }

        public int PaymentMethod { get; set; }

        public bool Status { get; set; }

        public string Notes { get; set; }

        public decimal GrandTotal { get; set; }

        public DateTime CretedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public List<SalesItem> SalesItems { get; set; }

     
        

    }
}
