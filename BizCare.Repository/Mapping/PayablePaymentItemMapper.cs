using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using EntityMap;
using System.Data;
using BizCare.Model;


namespace BizCare.Repository.Mapping
{
    public class PaymentItemQty
    {
        public int Qty { get; set; }

        public decimal Total { get; set; }
    }


    public class PaymentItemQtyMapper : IDataMapper<PaymentItemQty>
    {
        public PaymentItemQty Map(IDataReader rdr)
        {
            var paymentItemQty = new PaymentItemQty();

            paymentItemQty.Qty = rdr["Qty"] is DBNull ? 0 : (int)rdr["Qty"];
            paymentItemQty.Total = rdr["Total"] is DBNull ? 0 : (decimal)rdr["Total"];

            return paymentItemQty;
        }

       
    }


    public class PayablePaymentItemMapper : IDataMapper<PayablePaymentItem>
    {

        public PayablePaymentItem Map(IDataReader rdr)
        {
            var payablePaymentItem = new PayablePaymentItem();

            payablePaymentItem.PayablePaymentId = rdr["PayablePaymentId"] is DBNull ? Guid.Empty : (Guid)rdr["PayablePaymentId"];

            payablePaymentItem.SalesId = rdr["SalesId"] is DBNull ? Guid.Empty : (Guid)rdr["SalesId"];
            if (payablePaymentItem.Sales == null) payablePaymentItem.Sales = new Sales();

            payablePaymentItem.Sales.Code = rdr["SalesCode"] is DBNull ? string.Empty : (string)rdr["SalesCode"];
            payablePaymentItem.Sales.Date = rdr["SalesDate"] is DBNull ? DateTime.Now : (DateTime)rdr["SalesDate"];
            payablePaymentItem.Sales.GrandTotal = rdr["GrandTotal"] is DBNull ? 0 : (decimal)rdr["GrandTotal"];

            payablePaymentItem.Cash = rdr["Cash"] is DBNull ? 0 : (decimal)rdr["Cash"];
            payablePaymentItem.Bank = rdr["Bank"] is DBNull ? 0 : (decimal)rdr["Bank"];
            payablePaymentItem.Giro = rdr["Giro"] is DBNull ? 0 : (decimal)rdr["Giro"];
            payablePaymentItem.Correction = rdr["Correction"] is DBNull ? 0 : (decimal)rdr["Correction"];
            payablePaymentItem.Total = rdr["Total"] is DBNull ? 0 : (decimal)rdr["Total"];
            payablePaymentItem.GiroNumber = rdr["GiroNumber"] is DBNull ? string.Empty : (string)rdr["GiroNumber"];
            payablePaymentItem.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];

            return payablePaymentItem;
        }

    }
}
