using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using System.Data;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    class PayablePaymentMapper : IDataMapper<PayablePayment> 
    {
        public PayablePayment Map(IDataReader rdr)
        {
            var payablePayment = new PayablePayment();

            payablePayment.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            payablePayment.PaymentCode = rdr["PaymentCode"] is DBNull ? string.Empty : (string)rdr["PaymentCode"];
            payablePayment.PaymentDate = rdr["PaymentCode"] is DBNull ? DateTime.Now : (DateTime)rdr["PaymentDate"];
            payablePayment.TotalCash = rdr["TotalCash"] is DBNull ? 0 : (decimal)rdr["TotalCash"];
            payablePayment.TotalBank = rdr["TotalBank"] is DBNull ? 0 : (decimal)rdr["TotalBank"];
            payablePayment.TotalGiro = rdr["TotalGiro"] is DBNull ? 0 : (decimal)rdr["TotalGiro"];
            payablePayment.TotalCorrection = rdr["TotalCorrection"] is DBNull ? 0 : (decimal)rdr["TotalCorrection"];
            payablePayment.GrandTotal = rdr["GrandTotal"] is DBNull ? 0 : (decimal)rdr["GrandTotal"];
            payablePayment.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];


            payablePayment.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            payablePayment.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];
            payablePayment.ModifiedBy = rdr["ModifiedBy"] is DBNull ? string.Empty : (string)rdr["ModifiedBy"];
            payablePayment.CreatedBy = rdr["CreatedBy"] is DBNull ? string.Empty : (string)rdr["CreatedBy"];


            return payablePayment;
        }

    }
}
