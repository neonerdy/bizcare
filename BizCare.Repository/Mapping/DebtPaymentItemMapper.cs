using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityMap;
using System.Data;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    class DebtPaymentItemMapper : IDataMapper<DebtPaymentItem>
    {
        public DebtPaymentItem Map(IDataReader rdr)
        {
            var debtPaymentItem = new DebtPaymentItem();

            debtPaymentItem.DebtPaymentId = rdr["DebtPaymentId"] is DBNull ? Guid.Empty : (Guid)rdr["DebtPaymentId"];

            debtPaymentItem.PurchaseId = rdr["PurchaseId"] is DBNull ? Guid.Empty : (Guid)rdr["PurchaseId"];
            if (debtPaymentItem.Purchase == null) debtPaymentItem.Purchase = new Purchase();

            debtPaymentItem.Purchase.Code = rdr["PurchaseCode"] is DBNull ? string.Empty : (string)rdr["PurchaseCode"];
            debtPaymentItem.Purchase.Date = rdr["PurchaseDate"] is DBNull ? DateTime.Now : (DateTime)rdr["PurchaseDate"];
            debtPaymentItem.Purchase.GrandTotal = rdr["GrandTotal"] is DBNull ? 0 : (decimal)rdr["GrandTotal"];

            debtPaymentItem.Cash = rdr["Cash"] is DBNull ? 0 : (decimal)rdr["Cash"];
            debtPaymentItem.Bank = rdr["Bank"] is DBNull ? 0 : (decimal)rdr["Bank"];
            debtPaymentItem.Giro = rdr["Giro"] is DBNull ? 0 : (decimal)rdr["Giro"];
            debtPaymentItem.Correction = rdr["Correction"] is DBNull ? 0 : (decimal)rdr["Correction"];
            debtPaymentItem.Total = rdr["Total"] is DBNull ? 0 : (decimal)rdr["Total"];
            debtPaymentItem.GiroNumber = rdr["GiroNumber"] is DBNull ? string.Empty : (string)rdr["GiroNumber"];
            debtPaymentItem.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];

            return debtPaymentItem;
        }

    }
}
