using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using System.Data;
using BizCare.Model;


namespace BizCare.Repository.Mapping
{
    public class BillReceiptMapper : IDataMapper<BillReceipt> 
    {
        public BillReceipt Map(IDataReader rdr)
        {
            var billReceipt = new BillReceipt();

            billReceipt.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            billReceipt.Code = rdr["BillReceiptCode"] is DBNull ? string.Empty : (string)rdr["BillReceiptCode"];
            billReceipt.BillReceiptDate = rdr["BillReceiptDate"] is DBNull ? DateTime.Now : (DateTime)rdr["BillReceiptDate"];
            billReceipt.GrandTotal = rdr["GrandTotal"] is DBNull ? 0 : (decimal)rdr["GrandTotal"];
            billReceipt.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];

            billReceipt.SalesmanId = rdr["SalesmanId"] is DBNull ? Guid.Empty : (Guid)rdr["SalesmanId"];
            if (billReceipt.Salesman == null) billReceipt.Salesman = new Salesman();

            billReceipt.Salesman.Name = rdr["SalesmanName"] is DBNull ? string.Empty : (string)rdr["SalesmanName"];

            billReceipt.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            billReceipt.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];
            billReceipt.CreatedBy = rdr["CreatedBy"] is DBNull ? string.Empty : (string)rdr["CreatedBy"];
            billReceipt.ModifiedBy = rdr["ModifiedBy"] is DBNull ? string.Empty : (string)rdr["ModifiedBy"];

            billReceipt.PrintCounter = rdr["PrintCounter"] is DBNull ? 0 : (int)rdr["PrintCounter"];


            return billReceipt;
        }
    }
}
