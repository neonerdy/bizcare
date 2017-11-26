using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityMap;
using System.Data;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class SalesItemMapper : IDataMapper<SalesItem>
    {
        public SalesItem Map(IDataReader rdr)
        {
            var salesItem = new SalesItem();

            salesItem.SalesId = rdr["SalesId"] is DBNull ? Guid.Empty : (Guid)rdr["SalesId"];
            salesItem.ProductId = rdr["ProductId"] is DBNull ? Guid.Empty : (Guid)rdr["ProductId"];

            if (salesItem.Product == null) salesItem.Product = new Product();
            salesItem.Product.Name = rdr["ProductName"] is DBNull ? string.Empty : (string)rdr["ProductName"];
            salesItem.Product.Unit = rdr["Unit"] is DBNull ? string.Empty : (string)rdr["Unit"];

            salesItem.Qty = rdr["Qty"] is DBNull ? 0 : (int)rdr["Qty"];
            salesItem.Price = rdr["Price"] is DBNull ? 0 : (decimal)rdr["Price"];


            return salesItem;
        
        }
    }
}
