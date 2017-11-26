using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityMap;
using System.Data;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class PayableBalanceItemMapper : IDataMapper<PayableBalanceItem>
    {
        public PayableBalanceItem Map(IDataReader rdr)
        {
            var payableBalanceItem = new PayableBalanceItem();

            payableBalanceItem.PayableBalanceId = rdr["PayableBalanceId"] is DBNull ? Guid.Empty : (Guid)rdr["PayableBalanceId"];
            payableBalanceItem.ProductId = rdr["ProductId"] is DBNull ? Guid.Empty : (Guid)rdr["ProductId"];

            if (payableBalanceItem.Product == null) payableBalanceItem.Product = new Product();
            payableBalanceItem.Product.Name = rdr["ProductName"] is DBNull ? string.Empty : (string)rdr["ProductName"];
            payableBalanceItem.Product.Unit = rdr["Unit"] is DBNull ? string.Empty : (string)rdr["Unit"];

            payableBalanceItem.Qty = rdr["Qty"] is DBNull ? 0 : (int)rdr["Qty"];
            payableBalanceItem.Price = rdr["Price"] is DBNull ? 0 : (decimal)rdr["Price"];


            return payableBalanceItem;
        
        }
    }
}
