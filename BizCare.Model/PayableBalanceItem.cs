﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizCare.Model
{
    public class PayableBalanceItem
    {
        public Guid ID { get; set; }

        public Guid PayableBalanceId { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public int Qty { get; set; }

        public decimal Price { get; set; }
               
    }
}
