using System;
using System.Collections.Generic;

namespace BizCare.Model
{
    public class Product
    {
        public Guid ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public string Unit { get; set; }

        public string Notes { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public List<ProductQty> ProductQty { get; set; }

        
    }
}
