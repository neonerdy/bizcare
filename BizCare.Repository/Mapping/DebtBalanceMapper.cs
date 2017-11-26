using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using System.Data;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class DebtBalanceMapper : IDataMapper<DebtBalance>
    {

        public DebtBalance Map(IDataReader rdr)
        {
            var debtBalance = new DebtBalance();

            debtBalance.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];

            debtBalance.BalanceYear = rdr["BalanceYear"] is DBNull ? 0 : (int)rdr["BalanceYear"];
            debtBalance.BalanceMonth = rdr["BalanceMonth"] is DBNull ? 0 : (int)rdr["BalanceMonth"];
            

            debtBalance.PurchaseCode = rdr["PurchaseCode"] is DBNull ? string.Empty : (string)rdr["PurchaseCode"];
            debtBalance.PurchaseDate = rdr["PurchaseDate"] is DBNull ? DateTime.Now : (DateTime)rdr["PurchaseDate"];

            debtBalance.SupplierId = rdr["SupplierId"] is DBNull ? Guid.Empty : (Guid)rdr["SupplierId"];
            if (debtBalance.Supplier == null) debtBalance.Supplier = new Supplier();
            debtBalance.Supplier.Name = rdr["SupplierName"] is DBNull ? string.Empty : (string)rdr["SupplierName"];

            debtBalance.PaymentMethod = rdr["PaymentMethod"] is DBNull ? 0 : (int)rdr["PaymentMethod"];
            debtBalance.GrandTotal = rdr["GrandTotal"] is DBNull ? 0 : (decimal)rdr["GrandTotal"];
            debtBalance.IsStatus = rdr["IsStatus"] is DBNull ? false : (bool)rdr["IsStatus"];
            debtBalance.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];
            debtBalance.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            debtBalance.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];

            debtBalance.DueDate = rdr["DueDate"] is DBNull ? DateTime.Now : (DateTime)rdr["DueDate"];
            debtBalance.AmountInWords = rdr["AmountInWords"] is DBNull ? string.Empty : (string)rdr["AmountInWords"];
            debtBalance.TermOfPayment = rdr["TermOfPayment"] is DBNull ? 0 : (int)rdr["TermOfPayment"];
            

            return debtBalance;

        }
    }
}
