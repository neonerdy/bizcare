using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;

namespace BizCare.Repository
{

    public interface IProductQtyRepository
    {
        List<ProductQty> GetByProductId(Guid productId);
        List<ProductQty> GetAll(int month, int year);
        List<ProductQty> Search(int month, int year,string value);
        void Save(IEntityManager em, Transaction tx, ProductQty productQty);
        void Save(ProductQty productQty);
        void Update(IEntityManager em, Transaction tx, ProductQty productQty);
        void Update(ProductQty productQty);
        void Delete(IEntityManager em, Transaction tx, Guid productId);
        ProductQty GetByMonthAndYear(int month, int year, Guid productId);
        void UpdateQtyOut(int month, int year, Guid productId, int qtyProduct, bool plus);
        void UpdateQtyIn(int month, int year, Guid productId, int qtyProduct, bool plus);
        void UpdateQtyCorrection(int month, int year, Guid productId, int qtyPlus, int qtyMinus, bool plus);
        void UpdateQtyFromInventory(int month, int year, Guid productId,
        int qtyIn, decimal purchasePrice,
        int qtyAvailable, decimal valueAverage, decimal valueAvailable,
        int qtyOut, decimal salesPrice, decimal salesValue,
        int qtyEnd, decimal valueEnd,
        int qtyPlusCorrection, int qtyMinusCorrection,
        decimal valuePlusCorrection, decimal valueMinusCorrection,
        int qtyPayment, decimal paymentPrice, decimal paymentValue);
        void UpdateQtyBegin(int month, int year, Guid productId, int qtyBegin, decimal valueBegin);
        ProductQty GetSummary(int month, int year);
    }


    public class ProductQtyRepository : IProductQtyRepository
    {
        private string tableName = "ProductQty";
        private DataSource ds;

        public ProductQtyRepository(DataSource ds)
        {
            this.ds = ds;
        }


        public List<ProductQty> GetByProductId(Guid productId)
        {
            List<ProductQty> productQty = new List<ProductQty>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Product.ID, Product.ProductCode, Product.ProductName, "
                        + "Product.CategoryId, Product.Unit, Product.Notes, Product.IsActive, "
                        + "ProductQty.ProductId, ProductQty.ActiveYear, ProductQty.ActiveMonth, "
                        + "ProductQty.QtyBegin, ProductQty.ValueBegin, "
                        + "ProductQty.QtyIn, ProductQty.PurchasePrice, "
                        + "ProductQty.QtyAvailable, ProductQty.ValueAverage, ProductQty.ValueAvailable,"
                        + "ProductQty.QtyOut, ProductQty.SalesPrice, ProductQty.SalesValue, "
                        + "ProductQty.QtyEnd, ProductQty.ValueEnd, "
                        + "ProductQty.QtyPlusCorrection, ProductQty.QtyMinusCorrection, "
                        + "ProductQty.ValuePlusCorrection, ProductQty.ValueMinusCorrection, "
                        + "ProductQty.QtyPayment, ProductQty.PaymentPrice, ProductQty.PaymentValue "
                        + "FROM Product INNER JOIN ProductQty ON Product.ID = ProductQty.ProductId "
                        + "WHERE "
                        + "Product.ID = '{" + productId  + "}'";

                productQty = em.ExecuteList<ProductQty>(sql, new ProductQtyMapper());
            }

            return productQty;
        }


        public List<ProductQty> GetAll(int month, int year)
        {
            List<ProductQty> productQty = new List<ProductQty>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Product.ID, Product.ProductCode, Product.ProductName, "
                        + "Product.CategoryId, Product.Unit, Product.Notes, Product.IsActive, "
                        + "ProductQty.ProductId, ProductQty.ActiveYear, ProductQty.ActiveMonth, "
                        + "ProductQty.QtyBegin, ProductQty.ValueBegin, "
                        + "ProductQty.QtyIn, ProductQty.PurchasePrice, "
                        + "ProductQty.QtyAvailable, ProductQty.ValueAverage, ProductQty.ValueAvailable,"
                        + "ProductQty.QtyOut, ProductQty.SalesPrice, ProductQty.SalesValue, "
                        + "ProductQty.QtyEnd, ProductQty.ValueEnd, "
                        + "ProductQty.QtyPlusCorrection, ProductQty.QtyMinusCorrection, "
                        + "ProductQty.ValuePlusCorrection, ProductQty.ValueMinusCorrection, "
                        + "ProductQty.QtyPayment, ProductQty.PaymentPrice, ProductQty.PaymentValue "
                        + "FROM Product INNER JOIN ProductQty ON Product.ID = ProductQty.ProductId "
                        + "WHERE "
                        + "Product.IsActive=true "
                        + "AND ProductQty.ActiveMonth=" + month + " AND ProductQty.ActiveYear=" + year + " "
                        + "ORDER BY Product.ProductCode ASC";

                productQty = em.ExecuteList<ProductQty>(sql, new ProductQtyMapper());
            }

            return productQty;
        }


        public List<ProductQty> Search(int month, int year,string value)
        {
            List<ProductQty> productQty = new List<ProductQty>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Product.ID, Product.ProductCode, Product.ProductName, "
                        + "Product.CategoryId, Product.Unit, Product.Notes, Product.IsActive, "
                        + "ProductQty.ProductId, ProductQty.ActiveYear, ProductQty.ActiveMonth, "
                        + "ProductQty.QtyBegin, ProductQty.ValueBegin, "
                        + "ProductQty.QtyIn, ProductQty.PurchasePrice, "
                        + "ProductQty.QtyAvailable, ProductQty.ValueAverage, ProductQty.ValueAvailable,"
                        + "ProductQty.QtyOut, ProductQty.SalesPrice, ProductQty.SalesValue, "
                        + "ProductQty.QtyEnd, ProductQty.ValueEnd, "
                        + "ProductQty.QtyPlusCorrection, ProductQty.QtyMinusCorrection, "
                        + "ProductQty.ValuePlusCorrection, ProductQty.ValueMinusCorrection, "
                        + "ProductQty.QtyPayment, ProductQty.PaymentPrice, ProductQty.PaymentValue "
                        + "FROM Product INNER JOIN ProductQty ON Product.ID = ProductQty.ProductId "
                        + "WHERE "
                        + "Product.IsActive=true "
                        + "AND ProductQty.ActiveMonth=" + month + " AND ProductQty.ActiveYear=" + year + " "
                        + "AND (Product.ProductCode LIKE '%" + value + "%' OR Product.ProductName LIKE '%" + value + "%') "
                        + "ORDER BY Product.ProductCode ASC";

                productQty = em.ExecuteList<ProductQty>(sql, new ProductQtyMapper());
            }

            return productQty;
        }



        public void Save(IEntityManager em, Transaction tx, ProductQty productQty)
        {
            try
            {
                string[] columns = { "ID","ActiveYear", "ActiveMonth","ProductId", 
                                       "QtyBegin", "ValueBegin",
                                       "QtyIn", "PurchasePrice",
                                       "QtyAvailable", "ValueAverage", "ValueAvailable",
                                       "QtyOut", "SalesPrice", "SalesValue",
                                       "QtyEnd", "ValueEnd",
                                       "QtyPlusCorrection", "QtyMinusCorrection",
                                       "ValuePlusCorrection",  "ValueMinusCorrection",
                                       "QtyPayment", "PaymentPrice", "PaymentValue"};

                object[] values = { Guid.NewGuid(),productQty.ActiveYear,productQty.ActiveMonth,productQty.ProductId,
                                    productQty.QtyBegin, productQty.ValueBegin,
                                    productQty.QtyIn, productQty.PurchasePrice,
                                    productQty.QtyAvailable ,productQty.ValueAverage, productQty.ValueAvailable,
                                    productQty.QtyOut, productQty.SalesPrice, productQty.SalesValue,                                 
                                    productQty.QtyEnd, productQty.ValueEnd,
                                    productQty.QtyPlusCorrection, productQty.QtyMinusCorrection,
                                    productQty.ValuePlusCorrection, productQty.ValueMinusCorrection,
                                    productQty.QtyPayment, productQty.PaymentPrice, productQty.PaymentValue};

                var q = new Query().Select(columns).From(tableName).Insert(values);

                if (tx == null)
                {
                    em.ExecuteNonQuery(q.ToSql());
                }
                else
                {
                    em.ExecuteNonQuery(q.ToSql(), tx);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void Save(ProductQty productQty)
        {
            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                Save(em, null, productQty);
            }
        }





        public void Update(IEntityManager em, Transaction tx, ProductQty productQty)
        {
            try
            {
                string[] columns = { "ActiveYear", "ActiveMonth","ProductId", 
                                       "QtyBegin", "ValueBegin",
                                       "QtyIn", "PurchasePrice",
                                       "QtyAvailable", "ValueAverage", "ValueAvailable",
                                       "QtyOut", "SalesPrice", "SalesValue",
                                       "QtyEnd", "ValueEnd",
                                       "QtyPlusCorrection", "QtyMinusCorrection",
                                       "ValuePlusCorrection",  "ValueMinusCorrection",
                                       "QtyPayment", "PaymentPrice", "PaymentValue"};

                object[] values = { productQty.ActiveYear,productQty.ActiveMonth,productQty.ProductId,
                                    productQty.QtyBegin, productQty.ValueBegin,
                                    productQty.QtyIn, productQty.PurchasePrice,
                                    productQty.QtyAvailable ,productQty.ValueAverage, productQty.ValueAvailable,
                                    productQty.QtyOut, productQty.SalesPrice, productQty.SalesValue,                                  
                                    productQty.QtyEnd, productQty.ValueEnd,
                                    productQty.QtyPlusCorrection, productQty.QtyMinusCorrection,
                                    productQty.ValuePlusCorrection, productQty.ValueMinusCorrection,
                                    productQty.QtyPayment, productQty.PaymentPrice, productQty.PaymentValue};
                    
                var q = new Query().Select(columns).From(tableName).Update(values)
                    .Where("ID").Equal("{" + productQty.ID + "}");

                if (tx == null)
                {
                    em.ExecuteNonQuery(q.ToSql());
                }
                else
                {
                    em.ExecuteNonQuery(q.ToSql(), tx);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Update(ProductQty productQty)
        {
            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                Update(em, null, productQty);
            }
        }

        public void Delete(IEntityManager em, Transaction tx, Guid productId)
        {
            try
            {
                var q = new Query().From(tableName).Delete().Where("ProductID").Equal("{" + productId + "}");
                em.ExecuteNonQuery(q.ToSql(),tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductQty GetByMonthAndYear(int month, int year, Guid productId)
        {
            ProductQty productQty = null;
        
            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT q.ID, q.ActiveYear, q.ActiveMonth, "
                           + "q.ProductId, p.ProductCode, p.ProductName, p.Unit, p.Notes, p.IsActive, "
                           + "q.QtyBegin, q.ValueBegin, " 
                           + "q.QtyIn, q.PurchasePrice, "
                           + "q.QtyAvailable, q.ValueAverage, q.ValueAvailable, "
                           + "q.QtyOut, q.SalesPrice, q.SalesValue, "                          
                           + "q.QtyEnd, q.ValueEnd, "
                           + "q.QtyPlusCorrection, q.QtyMinusCorrection, "
                           + "q.ValuePlusCorrection, q.ValueMinusCorrection, "
                           + "q.QtyPayment, q.PaymentPrice, q.PaymentValue "
                           + "FROM (ProductQty q INNER JOIN Product p on q.ProductId=p.ID) "
                           + "WHERE q.ProductId = '{" + productId  + "}' AND q.ActiveMonth = " + month + " AND q.ActiveYear = " + year;
                
                productQty = em.ExecuteObject<ProductQty>(sql, new ProductQtyMapper());

            }

            return productQty;
        }


        public void UpdateQtyBegin(int month, int year, Guid productId, int qtyBegin, decimal valueBegin)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string sql = "UPDATE " + tableName + " SET QtyBegin = " + qtyBegin + ", ValueBegin = " + valueBegin + " WHERE "
                            + "ProductId='{" + productId + "}' AND ActiveYear = " + year + " AND ActiveMonth = " + month;

                    em.ExecuteNonQuery(sql);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateQtyOut(int month, int year, Guid productId, int qtyProduct, bool plus)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    int qtyBegin = 0;
                    int qtyIn = 0;
                    int qtyOut = 0;
                    int qtyEnd = 0;

                    var productQty = GetByMonthAndYear(month, year, productId);
                    if (productQty != null)
                    {
                        qtyBegin = productQty.QtyBegin;
                        qtyIn = productQty.QtyIn;
                        qtyOut = productQty.QtyOut;
                        qtyEnd = productQty.QtyEnd;
                    }
                    if (plus)
                    {
                        qtyOut = qtyOut + qtyProduct;
                        qtyEnd = (qtyBegin + qtyIn) - qtyOut;
                    }
                    else
                    {
                        qtyOut = qtyOut - qtyProduct;
                        qtyEnd = (qtyBegin + qtyIn) - qtyOut;
                    }

                    string sql = "UPDATE " + tableName + " SET QtyOut = " + qtyOut + ", QtyEnd = " + qtyEnd + " WHERE "
                            + "ProductId='{" + productId + "}' AND ActiveYear = " + year + " AND ActiveMonth = " + month;

                    em.ExecuteNonQuery(sql);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateQtyIn(int month, int year, Guid productId, int qtyProduct, bool plus)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    int qtyBegin = 0;
                    int qtyIn = 0;
                    int qtyOut = 0;
                    int qtyEnd = 0;

                    var productQty = GetByMonthAndYear(month, year, productId);
                    if (productQty != null)
                    {
                        qtyBegin = productQty.QtyBegin;
                        qtyIn = productQty.QtyIn;
                        qtyOut = productQty.QtyOut;
                        qtyEnd = productQty.QtyEnd;
                    }


                    if (plus)
                    {
                        qtyIn = qtyIn + qtyProduct;
                        qtyEnd = (qtyBegin + qtyIn) - qtyOut;
                    }
                    else
                    {
                        qtyIn = qtyIn - qtyProduct;
                        qtyEnd = (qtyBegin + qtyIn) - qtyOut;
                    }

                    string sql = "UPDATE " + tableName + " SET QtyIn = " + qtyIn + ", QtyEnd = " + qtyEnd + " WHERE "
                            + "ProductId='{" + productId + "}' AND ActiveYear = " + year + " AND ActiveMonth = " + month;

                    em.ExecuteNonQuery(sql);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateQtyCorrection(int month, int year, Guid productId, int qtyPlus, int qtyMinus, bool plus)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    int qtyBegin = 0;
                    int qtyIn = 0;
                    int qtyOut = 0;
                    int qtyPlusCorrection = 0;
                    int qtyMinusCorrection = 0;
                    int qtyEnd = 0;

                    var productQty = GetByMonthAndYear(month, year, productId);
                    if (productQty != null)
                    {
                        qtyBegin = productQty.QtyBegin;
                        qtyIn = productQty.QtyIn;
                        qtyOut = productQty.QtyOut;
                        qtyPlusCorrection = productQty.QtyPlusCorrection;
                        qtyMinusCorrection = productQty.QtyMinusCorrection;
                        qtyEnd = productQty.QtyEnd;
                    }


                    if (plus)
                    {
                        qtyPlusCorrection = qtyPlusCorrection + qtyPlus;
                        qtyMinusCorrection = qtyMinusCorrection + qtyMinus;
                        qtyOut = (qtyOut - qtyPlusCorrection) + qtyMinusCorrection;
                        qtyEnd = (qtyBegin + qtyIn) - qtyOut;
                    }
                    else
                    {
                        qtyPlusCorrection = qtyPlusCorrection - qtyPlus;
                        qtyMinusCorrection = qtyMinusCorrection - qtyMinus;
                        qtyOut = (qtyOut - qtyPlusCorrection) + qtyMinusCorrection;
                        qtyEnd = (qtyBegin + qtyIn) - qtyOut;
                        
                    }

                    string sql = "UPDATE " + tableName + " SET QtyOut = " + qtyOut + ", QtyPlusCorrection = " + qtyPlusCorrection + ", QtyMinusCorrection = " + qtyMinusCorrection + ", QtyEnd = " + qtyEnd + " WHERE "
                            + "ProductId='{" + productId + "}' AND ActiveYear = " + year + " AND ActiveMonth = " + month;

                    em.ExecuteNonQuery(sql);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateQtyFromInventory(int month, int year, Guid productId, 
            int qtyIn, decimal purchasePrice,
            int qtyAvailable, decimal valueAverage, decimal valueAvailable,
            int qtyOut, decimal salesPrice, decimal salesValue,
            int qtyEnd, decimal valueEnd, 
            int qtyPlusCorrection, int qtyMinusCorrection,
            decimal valuePlusCorrection, decimal valueMinusCorrection,
            int qtyPayment, decimal paymentPrice, decimal paymentValue)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string sql = "UPDATE " + tableName + " SET QtyIn = " + qtyIn + ", "
                            + "PurchasePrice = " + purchasePrice + ", "
                             + "QtyAvailable = " + qtyAvailable + ", "
                              + "ValueAverage = " + valueAverage + ", "
                               + "ValueAvailable = " + valueAvailable + ", "
                                + "QtyOut = " + qtyOut + ", "
                                 + "SalesPrice = " + salesPrice + ", "
                                 + "SalesValue = " + salesValue + ", "
                                 + "QtyEnd = " + qtyEnd + ", "
                                 + "ValueEnd = " + valueEnd + ", "
                                  + "QtyPlusCorrection = " + qtyPlusCorrection + ", "
                                   + "QtyMinusCorrection = " + qtyMinusCorrection + ", "
                                    + "ValuePlusCorrection = " + valuePlusCorrection + ", "
                            + "ValueMinusCorrection = " + valueMinusCorrection + ", "
                            + "QtyPayment = " + qtyPayment + ", "
                             + "PaymentPrice = " + paymentPrice + ", "
                            + "PaymentValue = " + paymentValue + " WHERE "
                            + "ProductId='{" + productId + "}' AND ActiveYear = " + year + " AND ActiveMonth = " + month;

                    em.ExecuteNonQuery(sql);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductQty GetSummary(int month, int year)
        {
            ProductQty productQty = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Sum(ProductQty.QtyBegin) AS QtyBegin, Sum(ProductQty.ValueBegin) AS ValueBegin, "
                + "Sum(ProductQty.QtyIn) AS QtyIn, Sum(ProductQty.PurchasePrice) AS PurchasePrice, "
                + "Sum(ProductQty.QtyAvailable) AS QtyAvailable, Sum(ProductQty.ValueAverage) AS ValueAverage, Sum(ProductQty.ValueAvailable) AS ValueAvailable, "                
                + "Sum(ProductQty.QtyOut) AS QtyOut, Sum(ProductQty.SalesPrice) AS SalesPrice, Sum(ProductQty.SalesValue) AS SalesValue, "
                + "Sum(ProductQty.QtyEnd) AS QtyEnd, Sum(ProductQty.ValueEnd) AS ValueEnd, "
                + "Sum(ProductQty.ValuePlusCorrection) AS ValuePlusCorrection, Sum(ProductQty.ValueMinusCorrection) AS ValueMinusCorrection, "
                + "Sum(ProductQty.QtyPlusCorrection) AS QtyPlusCorrection, Sum(ProductQty.QtyMinusCorrection) AS QtyMinusCorrection, "
                + "Sum(ProductQty.QtyPayment) AS QtyPayment, Sum(ProductQty.PaymentPrice) AS PaymentPrice, Sum(ProductQty.PaymentValue) AS PaymentValue "
                + "FROM ProductQty "
                + "WHERE ProductQty.ActiveYear=" + year + " AND ProductQty.ActiveMonth= " + month;


                productQty = em.ExecuteObject<ProductQty>(sql, new ProductQtySummaryMapper());
            }

            return productQty;
        }















    }
}
