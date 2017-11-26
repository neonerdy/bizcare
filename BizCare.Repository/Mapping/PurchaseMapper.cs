using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using System.Data;

namespace BizCare.Repository.Mapping
{
    public class PurchaseMapper : IDataMapper<Purchase> 
    {
        public Purchase Map(IDataReader rdr)
        {
            var purchase = new Purchase();

            purchase.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            purchase.Code = rdr["PurchaseCode"] is DBNull ? string.Empty : (string)rdr["PurchaseCode"];
            purchase.Date = rdr["PurchaseDate"] is DBNull ? DateTime.Now : (DateTime)rdr["PurchaseDate"];

            purchase.SupplierId = rdr["SupplierId"] is DBNull ? Guid.Empty : (Guid)rdr["SupplierId"];

            if (purchase.Supplier == null) purchase.Supplier = new Supplier();
            purchase.Supplier.Name = rdr["SupplierName"] is DBNull ? string.Empty : (string)rdr["SupplierName"];

            purchase.PaymentMethod = rdr["PaymentMethod"] is DBNull ? 0 : (int)rdr["PaymentMethod"];
            purchase.Status = rdr["Status"] is DBNull ? false : (bool)rdr["Status"];
            purchase.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];

            purchase.GrandTotal = rdr["GrandTotal"] is DBNull ? 0 : (decimal)rdr["GrandTotal"];

            purchase.DueDate = rdr["DueDate"] is DBNull ? DateTime.Now : (DateTime)rdr["DueDate"];
            purchase.AmountInWords = rdr["AmountInWords"] is DBNull ? string.Empty : (string)rdr["AmountInWords"];
            purchase.PrintCounter = rdr["PrintCounter"] is DBNull ? 0 : (int)rdr["PrintCounter"];
            purchase.TermOfPayment = rdr["TermOfPayment"] is DBNull ? 0 : (int)rdr["TermOfPayment"];
           
            purchase.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            purchase.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];
            purchase.CreatedBy = rdr["CreatedBy"] is DBNull ? string.Empty : (string)rdr["CreatedBy"];
            purchase.ModifiedBy = rdr["ModifiedBy"] is DBNull ? string.Empty : (string)rdr["ModifiedBy"];

            

            return purchase;
        }
    }
}
