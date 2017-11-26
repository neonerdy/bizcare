using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using System.Data;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    class BillReceiptItemMapper : IDataMapper<BillReceiptItem>
    {
        public BillReceiptItem Map(IDataReader rdr)
        {
            var billReceiptItem = new BillReceiptItem();

            billReceiptItem.BillReceiptId = rdr["BillReceiptId"] is DBNull ? Guid.Empty : (Guid)rdr["BillReceiptId"];

            billReceiptItem.SalesId = rdr["SalesId"] is DBNull ? Guid.Empty : (Guid)rdr["SalesId"];
            if (billReceiptItem.Sales == null) billReceiptItem.Sales = new Sales();

            billReceiptItem.Sales.Code = rdr["SalesCode"] is DBNull ? string.Empty : (string)rdr["SalesCode"];
            billReceiptItem.Sales.Date = rdr["SalesDate"] is DBNull ? DateTime.Now : (DateTime)rdr["SalesDate"];
            billReceiptItem.Sales.GrandTotal = rdr["GrandTotal"] is DBNull ? 0 : (decimal)rdr["GrandTotal"];

            billReceiptItem.Sales.CustomerId = rdr["CustomerId"] is DBNull ? Guid.Empty : (Guid)rdr["CustomerId"];

            if (billReceiptItem.Sales.Customer == null) billReceiptItem.Sales.Customer = new Customer();
            billReceiptItem.Sales.Customer.Name = rdr["CustomerName"] is DBNull ? string.Empty : (string)rdr["CustomerName"];

            if (billReceiptItem.Sales.Salesman == null) billReceiptItem.Sales.Salesman = new Salesman();
            billReceiptItem.Sales.SalesmanId = rdr["SalesmanId"] is DBNull ? Guid.Empty : (Guid)rdr["SalesmanId"];
            billReceiptItem.Sales.Salesman.Name = rdr["SalesmanName"] is DBNull ? string.Empty : (string)rdr["SalesmanName"];

            billReceiptItem.Total = rdr["Total"] is DBNull ? 0 : (decimal)rdr["Total"];
            billReceiptItem.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];

            return billReceiptItem;
        }
    }
}
