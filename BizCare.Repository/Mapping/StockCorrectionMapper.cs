using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using System.Data;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class StockCorrectionMapper : IDataMapper<StockCorrection>
    {
        public StockCorrection Map(IDataReader rdr)
        {
            var stockCorrection = new StockCorrection();

            stockCorrection.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            stockCorrection.Code = rdr["CorrectionCode"] is DBNull ? string.Empty : (string)rdr["CorrectionCode"];
            stockCorrection.Date = rdr["CorrectionDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CorrectionDate"];

            stockCorrection.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];
            stockCorrection.PrintCounter = rdr["PrintCounter"] is DBNull ? 0 : (int)rdr["PrintCounter"];

            stockCorrection.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            stockCorrection.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];
            stockCorrection.ModifiedBy = rdr["ModifiedBy"] is DBNull ? string.Empty : (string)rdr["ModifiedBy"];
            stockCorrection.CreatedBy = rdr["CreatedBy"] is DBNull ? string.Empty : (string)rdr["CreatedBy"];


            return stockCorrection;
        }

    }
}
