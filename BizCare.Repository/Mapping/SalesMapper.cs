using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityMap;
using System.Data;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class SalesMapper : IDataMapper<Sales> 
    {
        public Sales Map(IDataReader rdr)
        {
            var sales = new Sales();

            sales.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            sales.Code = rdr["SalesCode"] is DBNull ? string.Empty : (string)rdr["SalesCode"];
            sales.Date = rdr["SalesDate"] is DBNull ? DateTime.Now : (DateTime)rdr["SalesDate"];

            sales.CustomerId = rdr["CustomerId"] is DBNull ? Guid.Empty : (Guid)rdr["CustomerId"];
            sales.SalesmanId = rdr["SalesmanId"] is DBNull ? Guid.Empty : (Guid)rdr["SalesmanId"];

            if (sales.Customer == null) sales.Customer = new Customer();
            sales.Customer.Name = rdr["CustomerName"] is DBNull ? string.Empty : (string)rdr["CustomerName"];
            sales.Customer.Address = rdr["Address"] is DBNull ? string.Empty : (string)rdr["Address"];

            if (sales.Salesman == null) sales.Salesman = new Salesman();
            sales.Salesman.Name = rdr["SalesmanName"] is DBNull ? string.Empty : (string)rdr["SalesmanName"];

            sales.PaymentMethod = rdr["PaymentMethod"] is DBNull ? 0 : (int)rdr["PaymentMethod"];
            sales.Status = rdr["Status"] is DBNull ? false : (bool)rdr["Status"];
            sales.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];

            sales.GrandTotal = rdr["GrandTotal"] is DBNull ? 0 : (decimal)rdr["GrandTotal"];

            sales.DueDate = rdr["DueDate"] is DBNull ? DateTime.Now : (DateTime)rdr["DueDate"];
            sales.AmountInWords = rdr["AmountInWords"] is DBNull ? string.Empty : (string)rdr["AmountInWords"];
            sales.PrintCounter = rdr["PrintCounter"] is DBNull ? 0 : (int)rdr["PrintCounter"];
            sales.TermOfPayment = rdr["TermOfPayment"] is DBNull ? 0 : (int)rdr["TermOfPayment"];
            
            sales.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            sales.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];
            sales.CreatedBy = rdr["CreatedBy"] is DBNull ? string.Empty : (string)rdr["CreatedBy"];
            sales.ModifiedBy = rdr["ModifiedBy"] is DBNull ? string.Empty : (string)rdr["ModifiedBy"];

            
            return sales;
        }
    }
}
