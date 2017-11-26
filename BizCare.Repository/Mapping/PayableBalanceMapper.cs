using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using System.Data;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class PayableBalanceMapper : IDataMapper<PayableBalance>
    {

        public PayableBalance Map(IDataReader rdr)
        {
            var payableBalance = new PayableBalance();

            payableBalance.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];

            payableBalance.BalanceYear = rdr["BalanceYear"] is DBNull ? 0 : (int)rdr["BalanceYear"];
            payableBalance.BalanceMonth = rdr["BalanceMonth"] is DBNull ? 0 : (int)rdr["BalanceMonth"];
            

            payableBalance.SalesCode = rdr["SalesCode"] is DBNull ? string.Empty : (string)rdr["SalesCode"];
            payableBalance.SalesDate = rdr["SalesDate"] is DBNull ? DateTime.Now : (DateTime)rdr["SalesDate"];

            payableBalance.CustomerId = rdr["CustomerId"] is DBNull ? Guid.Empty : (Guid)rdr["CustomerId"];
            if (payableBalance.Customer == null) payableBalance.Customer = new Customer();
            payableBalance.Customer.Name = rdr["CustomerName"] is DBNull ? string.Empty : (string)rdr["CustomerName"];
            
            payableBalance.SalesmanId = rdr["SalesmanId"] is DBNull ? Guid.Empty : (Guid)rdr["SalesmanId"];
            if (payableBalance.Salesman == null) payableBalance.Salesman = new Salesman();
            payableBalance.Salesman.Name = rdr["SalesmanName"] is DBNull ? string.Empty : (string)rdr["SalesmanName"];

            payableBalance.PaymentMethod = rdr["PaymentMethod"] is DBNull ? 0 : (int)rdr["PaymentMethod"];
            payableBalance.GrandTotal = rdr["GrandTotal"] is DBNull ? 0 : (decimal)rdr["GrandTotal"];
            payableBalance.IsStatus = rdr["IsStatus"] is DBNull ? false : (bool)rdr["IsStatus"];
            payableBalance.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];
            payableBalance.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            payableBalance.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];

            payableBalance.DueDate = rdr["DueDate"] is DBNull ? DateTime.Now : (DateTime)rdr["DueDate"];
            payableBalance.AmountInWords = rdr["AmountInWords"] is DBNull ? string.Empty : (string)rdr["AmountInWords"];
            payableBalance.TermOfPayment = rdr["TermOfPayment"] is DBNull ? 0 : (int)rdr["TermOfPayment"];
            

            return payableBalance;

        }
    }
}
