using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using EntityMap;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class ExpenseMapper : IDataMapper<Expense>
    {
        public Expense Map(IDataReader rdr)
        {
            var expense = new Expense();

            expense.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            expense.Code = rdr["ExpenseCode"] is DBNull ? string.Empty : (string)rdr["ExpenseCode"];
            expense.Date = rdr["ExpenseDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ExpenseDate"];
            expense.AccountType = rdr["AccountType"] is DBNull ? string.Empty : (string)rdr["AccountType"];
            expense.AccountName = rdr["AccountName"] is DBNull ? string.Empty : (string)rdr["AccountName"];
            expense.AccountNumber = rdr["AccountNumber"] is DBNull ? string.Empty : (string)rdr["AccountNumber"];
            expense.GrandTotal = rdr["GrandTotal"] is DBNull ? 0 : (decimal)rdr["GrandTotal"];
            expense.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];
            expense.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            expense.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];
            expense.ModifiedBy = rdr["ModifiedBy"] is DBNull ? string.Empty : (string)rdr["ModifiedBy"];
            expense.CreatedBy = rdr["CreatedBy"] is DBNull ? string.Empty : (string)rdr["CreatedBy"];

            expense.AmountInWords = rdr["AmountInWords"] is DBNull ? string.Empty : (string)rdr["AmountInWords"];
            expense.PrintCounter = rdr["PrintCounter"] is DBNull ? 0 : (int)rdr["PrintCounter"];


            return expense;
        }
    }
}
