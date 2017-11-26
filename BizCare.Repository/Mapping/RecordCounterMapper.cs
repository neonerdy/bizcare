using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using System.Data;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class RecordCounterMapper : IDataMapper<RecordCounter>
    {
        public RecordCounter Map(IDataReader rdr)
        {

            var recordCounter = new RecordCounter();
            
            recordCounter.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            recordCounter.ActiveYear = rdr["ActiveYear"] is DBNull ? 0 : (int)rdr["ActiveYear"];
            recordCounter.ActiveMonth = rdr["ActiveMonth"] is DBNull ? 0 : (int)rdr["ActiveMonth"];
            recordCounter.SalesCounter = rdr["SalesCounter"] is DBNull ? 0 : (int)rdr["SalesCounter"];
            recordCounter.PurchaseCounter = rdr["PurchaseCounter"] is DBNull ? 0 : (int)rdr["PurchaseCounter"];
            recordCounter.ExpenseCounter = rdr["ExpenseCounter"] is DBNull ? 0 : (int)rdr["ExpenseCounter"];
            recordCounter.PayablePaymentCounter = rdr["PayablePaymentCounter"] is DBNull ? 0 : (int)rdr["PayablePaymentCounter"];
            recordCounter.DebtPaymentCounter = rdr["DebtPaymentCounter"] is DBNull ? 0 : (int)rdr["DebtPaymentCounter"];
            recordCounter.BillReceiptCounter = rdr["BillReceiptCounter"] is DBNull ? 0 : (int)rdr["BillReceiptCounter"];
            recordCounter.StockCorrectionCounter = rdr["StockCorrectionCounter"] is DBNull ? 0 : (int)rdr["StockCorrectionCounter"];
           
            recordCounter.ClosingStatus = rdr["ClosingStatus"] is DBNull ? false : (bool)rdr["ClosingStatus"];
            recordCounter.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            recordCounter.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];


            return recordCounter;
        }
    }
}
