using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityMap;
using System.Data;
using BizCare.Model;
namespace BizCare.Repository.Mapping
{
    public class StockCorrectionItemMapper : IDataMapper<StockCorrectionItem>
    {
        public StockCorrectionItem Map(IDataReader rdr)
        {
            var stockCorrectionItem = new StockCorrectionItem();

            stockCorrectionItem.StockCorrectionId = rdr["StockCorrectionId"] is DBNull ? Guid.Empty : (Guid)rdr["StockCorrectionId"];
            stockCorrectionItem.ProductId = rdr["ProductId"] is DBNull ? Guid.Empty : (Guid)rdr["ProductId"];

            if (stockCorrectionItem.Product == null) stockCorrectionItem.Product = new Product();
            stockCorrectionItem.Product.Name = rdr["ProductName"] is DBNull ? string.Empty : (string)rdr["ProductName"];
            stockCorrectionItem.Product.Unit = rdr["Unit"] is DBNull ? string.Empty : (string)rdr["Unit"];

            stockCorrectionItem.QtyPlus = rdr["QtyPlus"] is DBNull ? 0 : (int)rdr["QtyPlus"];
            stockCorrectionItem.QtyMinus = rdr["QtyMinus"] is DBNull ? 0 : (int)rdr["QtyMinus"];

            stockCorrectionItem.ValuePlus = rdr["ValuePlus"] is DBNull ? 0 : (decimal)rdr["ValuePlus"];
            stockCorrectionItem.ValueMinus = rdr["ValueMinus"] is DBNull ? 0 : (decimal)rdr["ValueMinus"];

            stockCorrectionItem.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];

            return stockCorrectionItem;

        }
    }
}
