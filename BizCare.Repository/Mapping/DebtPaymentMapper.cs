using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using System.Data;
using BizCare.Model;


namespace BizCare.Repository.Mapping
{
    class DebtPaymentMapper : IDataMapper<DebtPayment> 
    {
        public DebtPayment Map(IDataReader rdr)
        {
            var debtPayment = new DebtPayment();

            debtPayment.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            debtPayment.PaymentCode = rdr["PaymentCode"] is DBNull ? string.Empty : (string)rdr["PaymentCode"];
            debtPayment.PaymentDate = rdr["PaymentCode"] is DBNull ? DateTime.Now : (DateTime)rdr["PaymentDate"];
            debtPayment.TotalCash = rdr["TotalCash"] is DBNull ? 0 : (decimal)rdr["TotalCash"];
            debtPayment.TotalBank = rdr["TotalBank"] is DBNull ? 0 : (decimal)rdr["TotalBank"];
            debtPayment.TotalGiro = rdr["TotalGiro"] is DBNull ? 0 : (decimal)rdr["TotalGiro"];
            debtPayment.TotalCorrection = rdr["TotalCorrection"] is DBNull ? 0 : (decimal)rdr["TotalCorrection"];
            debtPayment.GrandTotal = rdr["GrandTotal"] is DBNull ? 0 : (decimal)rdr["GrandTotal"];
            debtPayment.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];

            debtPayment.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            debtPayment.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];
            debtPayment.ModifiedBy = rdr["ModifiedBy"] is DBNull ? string.Empty : (string)rdr["ModifiedBy"];
            debtPayment.CreatedBy = rdr["CreatedBy"] is DBNull ? string.Empty : (string)rdr["CreatedBy"];


            return debtPayment;
        }
    }
}
