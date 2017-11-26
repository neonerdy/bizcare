using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;


namespace BizCare.Repository
{
    public interface IPayableBalanceItemRepository
    {
        List<PayableBalanceItem> GetByPayableBalanceId(Guid id);
        void Save(IEntityManager em, Transaction tx, PayableBalanceItem payableBalanceItem);
        void Delete(IEntityManager em, Transaction tx,Guid payableBalanceId);
        void Delete(IEntityManager em, Transaction tx, PayableBalanceItem payableBalanceItem);
        List<PayableBalanceItem> GetByMonthAndYear(int month, int year, Guid productId);
      
    }

    public class PayableBalanceItemRepository : IPayableBalanceItemRepository
    {
        private string tableName = "PayableBalanceItem";
        private DataSource ds;
 
        public PayableBalanceItemRepository(DataSource ds)
        {
            this.ds = ds;
        }


        public List<PayableBalanceItem> GetByPayableBalanceId(Guid id)
        {
            List<PayableBalanceItem> payableBalanceItems = new List<PayableBalanceItem>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT si.PayableBalanceId,si.ProductId,p.ProductName,p.Unit,si.Qty,si.Price FROM PayableBalanceItem si "
                           + "INNER JOIN Product p ON si.ProductId=p.ID "
                           + "WHERE si.PayableBalanceId='{" + id + "}' "
                            + "ORDER BY p.ProductName ASC";

                payableBalanceItems = em.ExecuteList<PayableBalanceItem>(sql, new PayableBalanceItemMapper());
            }

            return payableBalanceItems;
        }



        public void Save(IEntityManager em, Transaction tx, PayableBalanceItem payableBalanceItem)
        {
            try
            {
                string[] columns = {"ID","PayableBalanceId","ProductId","Qty","Price"};
                
                object[] values =  {Guid.NewGuid(),payableBalanceItem.PayableBalanceId,payableBalanceItem.ProductId,
                                    payableBalanceItem.Qty,payableBalanceItem.Price };

                var q = new Query().Select(columns).From(tableName).Insert(values);

                em.ExecuteNonQuery(q.ToSql(), tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Delete(IEntityManager em, Transaction tx, Guid payableBalanceId)
        {
            try
            {
                var q = new Query().From(tableName).Delete().Where("PayableBalanceId").Equal(payableBalanceId);
                em.ExecuteNonQuery(q.ToSql(),tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Delete(IEntityManager em, Transaction tx, PayableBalanceItem payableBalanceItem)
        {
            try
            {
                string[] columns = { "Qty", "Price"};

                object[] values = { 0, 0};

                var q = new Query().Select(columns).From(tableName).Update(values)
                    .Where("PayableBalanceId").Equal("{" + payableBalanceItem.PayableBalanceId + "}");

                em.ExecuteNonQuery(q.ToSql(), tx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<PayableBalanceItem> GetByMonthAndYear(int month, int year, Guid productId)
        {
            List<PayableBalanceItem> payableBalanceItems = new List<PayableBalanceItem>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT si.PayableBalanceId,si.ProductId,p.ProductName,p.Unit,si.Qty,si.Price "
                           + "FROM (PayableBalanceItem si INNER JOIN PayableBalance sh "
                           + "ON si.PayableBalanceId = sh.ID) INNER JOIN "
                           + "Product p ON si.ProductId = p.ID "
                           + "WHERE "
                           + "Month(sh.PayableBalanceDate)=" + month + " AND Year(sh.PayableBalanceDate)=" + year
                           + "AND si.ProductId='{" + productId + "}' "
                            + "ORDER BY p.ProductName ASC";

                payableBalanceItems = em.ExecuteList<PayableBalanceItem>(sql, new PayableBalanceItemMapper());
            }

            return payableBalanceItems;
        }

    }
}
