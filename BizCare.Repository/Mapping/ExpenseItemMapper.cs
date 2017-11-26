using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityMap;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    class ExpenseItemMapper : IDataMapper<ExpenseItem>
    {
        public ExpenseItem Map(IDataReader rdr)
        {
            var expenseItem = new ExpenseItem();
                        
            expenseItem.ExpenseId = rdr["ExpenseId"] is DBNull ? Guid.Empty : (Guid)rdr["ExpenseId"];
            expenseItem.Total = rdr["Total"] is DBNull ? 0 : (decimal)rdr["Total"];
            expenseItem.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];
            
            return expenseItem;
        }
    }
}
