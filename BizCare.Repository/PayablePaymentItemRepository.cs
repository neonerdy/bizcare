using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;



namespace BizCare.Repository
{
    public interface IPayablePaymentItemRepository
    {
        List<PayablePaymentItem> GetByPayablePaymentId(Guid payablePaymentId);
        void Save(IEntityManager em, Transaction tx, PayablePaymentItem payablePaymentItem);
        void Delete(IEntityManager em, Transaction tx, PayablePaymentItem payablePaymentItem);
        void Delete(IEntityManager em, Transaction tx, Guid payablePaymentId);
        List<PayablePaymentItem> GetBySalesman(int month, int year, Guid salesmanId);
        List<PaymentItemQty> GetPaymentItemQty(int month, int year, Guid productId);
    }

    public class PayablePaymentItemRepository : IPayablePaymentItemRepository
    {
        private string tableName = "PayablePaymentItem";
        private DataSource ds;
 
        public PayablePaymentItemRepository(DataSource ds)
        {
            this.ds = ds;
        }


        public List<PaymentItemQty> GetPaymentItemQty(int month, int year, Guid productId)
        {
            List<PaymentItemQty> paymentItemQty = new List<PaymentItemQty>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT SalesItem.Qty, [Qty]*[price] AS total "
                          + "FROM (((PayablePayment INNER JOIN PayablePaymentItem ON PayablePayment.ID = PayablePaymentItem.PayablePaymentId) INNER JOIN Sales ON PayablePaymentItem.SalesId = Sales.ID) INNER JOIN SalesItem ON Sales.ID = SalesItem.SalesId) INNER JOIN Product ON SalesItem.ProductId = Product.ID "
                          + "WHERE "
                          + "Month(PaymentDate)= " + month + " AND Year(PaymentDate)= " + year
                          + "AND SalesItem.ProductId='{" + productId + "}'";
               
                paymentItemQty = em.ExecuteList<PaymentItemQty>(sql, new PaymentItemQtyMapper());


            }

            return paymentItemQty;
        }



        public List<PayablePaymentItem> GetByPayablePaymentId(Guid payablePaymentId)
        {
            List<PayablePaymentItem> payablePaymentItems = new List<PayablePaymentItem>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT pi.PayablePaymentId, pi.Cash, pi.Bank, pi.Giro, pi.Correction, pi.Total, pi.GiroNumber, pi.Notes, "
                            + "pi.SalesId,s.SalesCode, s.SalesDate, s.GrandTotal,"
                            + "c.CustomerName, sl.SalesmanName "
                            + "FROM "
                            + "((PayablePaymentItem pi INNER JOIN Sales s ON pi.SalesId = s.ID) INNER JOIN Customer c ON s.CustomerId = c.ID) INNER JOIN Salesman sl ON s.SalesmanId = sl.ID "
                            + "WHERE "
                            + "pi.PayablePaymentId='{" + payablePaymentId + "}' "
                            + "ORDER BY s.SalesCode DESC";
                 
                payablePaymentItems = em.ExecuteList<PayablePaymentItem>(sql, new PayablePaymentItemMapper());
            }

            return payablePaymentItems;
        }

        public void Save(IEntityManager em, Transaction tx, PayablePaymentItem payablePaymentItem)
        {
            try
            {
                string[] columns = { "ID", "PayablePaymentId", "SalesId", 
                                       "Cash", "Bank", "Giro", "GiroNumber",
                                        "Correction", "Total", "Notes"};

                object[] values =  {Guid.NewGuid(),payablePaymentItem.PayablePaymentId, payablePaymentItem.SalesId,
                                    payablePaymentItem.Cash, payablePaymentItem.Bank,
                                   payablePaymentItem.Giro, payablePaymentItem.GiroNumber,
                                   payablePaymentItem.Correction, payablePaymentItem.Total,
                                   payablePaymentItem.Notes};

                var q = new Query().Select(columns).From(tableName).Insert(values);

                em.ExecuteNonQuery(q.ToSql(), tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(IEntityManager em, Transaction tx, Guid payablePaymentId)
        {
            try
            {

                var q = new Query().From(tableName).Delete().Where("PayablePaymentId").Equal("{" + payablePaymentId + "}");
                    em.ExecuteNonQuery(q.ToSql(), tx);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(IEntityManager em, Transaction tx, PayablePaymentItem payablePaymentItem)
        {
            try
            {
                string[] columns = { "Cash", "Bank", "Giro", "Correction", "Total"};

                object[] values = { 0, 0,0, 0, 0, 0};

                var q = new Query().Select(columns).From(tableName).Update(values)
                    .Where("PayablePaymentId").Equal("{" + payablePaymentItem.PayablePaymentId + "}");

                em.ExecuteNonQuery(q.ToSql(), tx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<PayablePaymentItem> GetBySalesman(int month, int year, Guid salesmanId)
        {
            List<PayablePaymentItem> payablePaymentItem = new List<PayablePaymentItem>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {

                string sql = "SELECT ph.ID, ph.PaymentCode, ph.PaymentDate, "
                        + "ph.TotalCash, ph.TotalBank, ph.TotalGiro, ph.TotalCorrection, ph.GrandTotal, "
                        + "pi.PayablePaymentId, pi.cash, pi.giro, pi.bank, pi.correction, pi.GiroNumber, pi.Notes, pi.Total, "
                        + "pi.SalesId, s.SalesCode, s.SalesDate "
                        + "FROM (PayablePayment ph INNER JOIN PayablePaymentItem pi "
                        + "ON ph.ID = pi.PayablePaymentId) INNER JOIN "
                        + "Sales s ON pi.SalesId = s.ID "
                        + "WHERE "
                        + "s.SalesmanId='{" + salesmanId + "}' AND Month(ph.PaymentDate)=" + month + " AND Year(ph.PaymentDate)=" + year
                        + " ORDER BY s.SalesCode DESC";


                payablePaymentItem = em.ExecuteList<PayablePaymentItem>(sql, new PayablePaymentItemMapper());
            }

            return payablePaymentItem;
        }














    }
}
