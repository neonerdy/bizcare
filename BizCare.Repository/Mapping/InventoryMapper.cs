using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityMap;
using BizCare.Model;


namespace BizCare.Repository.Mapping
{
    public class InventoryMapper : IDataMapper<Inventory>
    {
        public Inventory Map(IDataReader rdr)
        {
            var inventory = new Inventory();

            inventory.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];

            inventory.ActiveYear = rdr["ActiveYear"] is DBNull ? 0 : (int)rdr["ActiveYear"];
            inventory.ActiveMonth = rdr["ActiveMonth"] is DBNull ? 0 : (int)rdr["ActiveMonth"];
            
            inventory.ProductCode = rdr["ProductCode"] is DBNull ? string.Empty : (string)rdr["ProductCode"];
            inventory.ProductName = rdr["ProductName"] is DBNull ? string.Empty : (string)rdr["ProductName"];
            inventory.Unit = rdr["Unit"] is DBNull ? string.Empty : (string)rdr["Unit"];
            
            inventory.QtyBegin = rdr["QtyBegin"] is DBNull ? 0 : (int)rdr["QtyBegin"];
            inventory.ValueBegin = rdr["ValueBegin"] is DBNull ? 0 : (decimal)rdr["ValueBegin"];

            inventory.QtyIn = rdr["QtyIn"] is DBNull ? 0 : (int)rdr["QtyIn"];
            inventory.PurchasePrice = rdr["PurchasePrice"] is DBNull ? 0 : (decimal)rdr["PurchasePrice"];
            
            inventory.QtyOut = rdr["QtyOut"] is DBNull ? 0 : (int)rdr["QtyOut"];
            inventory.SalesPrice = rdr["SalesPrice"] is DBNull ? 0 : (decimal)rdr["SalesPrice"];
            
            inventory.QtyAvailable = rdr["QtyAvailable"] is DBNull ? 0 : (int)rdr["QtyAvailable"];            
            inventory.ValueAverage = rdr["ValueAverage"] is DBNull ? 0 : (decimal)rdr["ValueAverage"];
            inventory.ValueAvailable = rdr["ValueAvailable"] is DBNull ? 0 : (decimal)rdr["ValueAvailable"];
            
            inventory.QtyEnd = rdr["QtyEnd"] is DBNull ? 0 : (int)rdr["QtyEnd"];
            inventory.ValueEnd = rdr["ValueEnd"] is DBNull ? 0 : (decimal)rdr["ValueEnd"];
            
            inventory.QtyPlusCorrection = rdr["QtyPlusCorrection"] is DBNull ? 0 : (int)rdr["QtyPlusCorrection"];
            inventory.QtyMinusCorrection = rdr["QtyMinusCorrection"] is DBNull ? 0 : (int)rdr["QtyMinusCorrection"];
            inventory.ValuePlusCorrection = rdr["ValuePlusCorrection"] is DBNull ? 0 : (decimal)rdr["ValuePlusCorrection"];
            inventory.ValueMinusCorrection = rdr["ValueMinusCorrection"] is DBNull ? 0 : (decimal)rdr["ValueMinusCorrection"];
            
            return inventory;
        }
    }
}
