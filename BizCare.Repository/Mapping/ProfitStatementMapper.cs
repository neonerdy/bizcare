using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityMap;
using BizCare.Model;


namespace BizCare.Repository.Mapping
{
    public class ProfitStatementMapper : IDataMapper<ProfitStatement>
    {
        public ProfitStatement Map(IDataReader rdr)
        {
            var profitStatement = new ProfitStatement();

            profitStatement.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];

            profitStatement.RowNumber = rdr["RowNumber"] is DBNull ? 0 : (int)rdr["RowNumber"];
            profitStatement.SalesItem = rdr["SalesItem"] is DBNull ? string.Empty : (string)rdr["SalesItem"];
            profitStatement.PayablePaymentItem = rdr["PayablePaymentItem"] is DBNull ? string.Empty : (string)rdr["PayablePaymentItem"];

            profitStatement.ThisMonth = rdr["ThisMonth"] is DBNull ? 0 : (decimal)rdr["ThisMonth"];
            profitStatement.LastMonth = rdr["LastMonth"] is DBNull ? 0 : (decimal)rdr["LastMonth"];
            profitStatement.Cumulative = rdr["Cumulative"] is DBNull ? 0 : (decimal)rdr["Cumulative"];
            
            return profitStatement;
        }
    }
}
