using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityMap;
using System.Data;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class PurchaseItemMapper : IDataMapper<PurchaseItem>
    {
         public PurchaseItem Map(IDataReader rdr)
        {
            var purchaseItem = new PurchaseItem();

            purchaseItem.PurchaseId = rdr["PurchaseId"] is DBNull ? Guid.Empty : (Guid)rdr["PurchaseId"];
            purchaseItem.ProductId = rdr["ProductId"] is DBNull ? Guid.Empty : (Guid)rdr["ProductId"];

            if (purchaseItem.Product == null) purchaseItem.Product = new Product();
            purchaseItem.Product.Name = rdr["ProductName"] is DBNull ? string.Empty : (string)rdr["ProductName"];
            purchaseItem.Product.Unit = rdr["Unit"] is DBNull ? string.Empty : (string)rdr["Unit"];

            purchaseItem.Qty = rdr["Qty"] is DBNull ? 0 : (int)rdr["Qty"];
            purchaseItem.Price = rdr["Price"] is DBNull ? 0 : (decimal)rdr["Price"];


            return purchaseItem;

        }
    }
}
