using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityMap;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class ProductQtyMapper : IDataMapper<ProductQty>
    {
        public ProductQty Map(IDataReader rdr)
        {
            var productQty = new ProductQty();

            productQty.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];

            productQty.ProductId = rdr["ProductId"] is DBNull ? Guid.Empty : (Guid)rdr["ProductId"];
            
            if (productQty.Product == null) productQty.Product = new Product();
            productQty.Product.Code = rdr["ProductCode"] is DBNull ? string.Empty : (string)rdr["ProductCode"];
            productQty.Product.Name = rdr["ProductName"] is DBNull ? string.Empty : (string)rdr["ProductName"];
            productQty.Product.Unit = rdr["Unit"] is DBNull ? string.Empty : (string)rdr["Unit"];
            productQty.Product.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];
            productQty.Product.IsActive = rdr["IsActive"] is DBNull ? false : (bool)rdr["IsActive"];

            productQty.ActiveYear = rdr["ActiveYear"] is DBNull ? 0 : (int)rdr["ActiveYear"];
            productQty.ActiveMonth = rdr["ActiveMonth"] is DBNull ? 0 : (int)rdr["ActiveMonth"];


            productQty.QtyBegin = rdr["QtyBegin"] is DBNull ? 0 : (int)rdr["QtyBegin"];
            productQty.ValueBegin = rdr["ValueBegin"] is DBNull ? 0 : (decimal)rdr["ValueBegin"];

            productQty.QtyIn = rdr["QtyIn"] is DBNull ? 0 : (int)rdr["QtyIn"];
            productQty.PurchasePrice = rdr["PurchasePrice"] is DBNull ? 0 : (decimal)rdr["PurchasePrice"];

            productQty.QtyAvailable = rdr["QtyAvailable"] is DBNull ? 0 : (int)rdr["QtyAvailable"];
            productQty.ValueAverage = rdr["ValueAverage"] is DBNull ? 0 : (decimal)rdr["ValueAverage"];
            productQty.ValueAvailable = rdr["ValueAvailable"] is DBNull ? 0 : (decimal)rdr["ValueAvailable"];

            productQty.QtyOut = rdr["QtyOut"] is DBNull ? 0 : (int)rdr["QtyOut"];
            productQty.SalesPrice = rdr["SalesPrice"] is DBNull ? 0 : (decimal)rdr["SalesPrice"];
            productQty.SalesValue = rdr["SalesValue"] is DBNull ? 0 : (decimal)rdr["SalesValue"];

            productQty.QtyEnd = rdr["QtyEnd"] is DBNull ? 0 : (int)rdr["QtyEnd"];
            productQty.ValueEnd = rdr["ValueEnd"] is DBNull ? 0 : (decimal)rdr["ValueEnd"];

            productQty.QtyPlusCorrection = rdr["QtyPlusCorrection"] is DBNull ? 0 : (int)rdr["QtyPlusCorrection"];
            productQty.QtyMinusCorrection = rdr["QtyMinusCorrection"] is DBNull ? 0 : (int)rdr["QtyMinusCorrection"];
            productQty.ValuePlusCorrection = rdr["ValuePlusCorrection"] is DBNull ? 0 : (decimal)rdr["ValuePlusCorrection"];
            productQty.ValueMinusCorrection = rdr["ValueMinusCorrection"] is DBNull ? 0 : (decimal)rdr["ValueMinusCorrection"];

            productQty.QtyPayment = rdr["QtyPayment"] is DBNull ? 0 : (int)rdr["QtyPayment"];
            productQty.PaymentPrice = rdr["PaymentPrice"] is DBNull ? 0 : (decimal)rdr["PaymentPrice"];
            productQty.PaymentValue = rdr["PaymentValue"] is DBNull ? 0 : (decimal)rdr["PaymentValue"];


            return productQty;
        }

    }


    public class ProductQtySummaryMapper : IDataMapper<ProductQty>
    {
        public ProductQty Map(IDataReader rdr)
        {
            var productQty = new ProductQty();

            productQty.QtyBegin = rdr["QtyBegin"] is DBNull ? 0 : Convert.ToInt32(rdr["QtyBegin"]);
            productQty.ValueBegin = rdr["ValueBegin"] is DBNull ? 0 : (decimal)rdr["ValueBegin"];

            productQty.QtyIn = rdr["QtyIn"] is DBNull ? 0 : Convert.ToInt32(rdr["QtyIn"]);
            productQty.PurchasePrice = rdr["PurchasePrice"] is DBNull ? 0 : (decimal)rdr["PurchasePrice"];

            productQty.QtyAvailable = rdr["QtyAvailable"] is DBNull ? 0 : Convert.ToInt32(rdr["QtyAvailable"]);
            productQty.ValueAverage = rdr["ValueAverage"] is DBNull ? 0 : (decimal)rdr["ValueAverage"];
            productQty.ValueAvailable = rdr["ValueAvailable"] is DBNull ? 0 : (decimal)rdr["ValueAvailable"];

            productQty.QtyOut = rdr["QtyOut"] is DBNull ? 0 : Convert.ToInt32(rdr["QtyOut"]);
            productQty.SalesPrice = rdr["SalesPrice"] is DBNull ? 0 : (decimal)rdr["SalesPrice"];
            productQty.SalesValue = rdr["SalesValue"] is DBNull ? 0 : (decimal)rdr["SalesValue"];

            productQty.QtyEnd = rdr["QtyEnd"] is DBNull ? 0 : Convert.ToInt32(rdr["QtyEnd"]);
            productQty.ValueEnd = rdr["ValueEnd"] is DBNull ? 0 : (decimal)rdr["ValueEnd"];

            productQty.QtyPlusCorrection = rdr["QtyPlusCorrection"] is DBNull ? 0 : Convert.ToInt32(rdr["QtyPlusCorrection"]);
            productQty.QtyMinusCorrection = rdr["QtyMinusCorrection"] is DBNull ? 0 : Convert.ToInt32(rdr["QtyMinusCorrection"]);
            productQty.ValuePlusCorrection = rdr["ValuePlusCorrection"] is DBNull ? 0 : (decimal)rdr["ValuePlusCorrection"];
            productQty.ValueMinusCorrection = rdr["ValueMinusCorrection"] is DBNull ? 0 : (decimal)rdr["ValueMinusCorrection"];

            productQty.QtyPayment = rdr["QtyPayment"] is DBNull ? 0 : Convert.ToInt32(rdr["QtyPayment"]);
            productQty.PaymentPrice = rdr["PaymentPrice"] is DBNull ? 0 : (decimal)rdr["PaymentPrice"];
            productQty.PaymentValue = rdr["PaymentValue"] is DBNull ? 0 : (decimal)rdr["PaymentValue"];

           




            return productQty;
        }

    }





}
