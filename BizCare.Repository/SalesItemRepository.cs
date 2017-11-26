using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;


namespace BizCare.Repository
{
    public interface ISalesItemRepository
    {
        List<SalesItem> GetBySalesId(Guid id);
        void Save(IEntityManager em, Transaction tx, SalesItem salesItem);
        void Delete(IEntityManager em, Transaction tx,Guid salesId);
        void Delete(IEntityManager em, Transaction tx, SalesItem salesItem);
        List<SalesItem> GetByMonthAndYear(int month, int year, Guid productId);
      
    }

    public class SalesItemRepository : ISalesItemRepository
    {
        private string tableName = "SalesItem";
        private DataSource ds;
 
        public SalesItemRepository(DataSource ds)
        {
            this.ds = ds;
        }


        public List<SalesItem> GetBySalesId(Guid id)
        {
            List<SalesItem> salesItems = new List<SalesItem>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT si.SalesId,si.ProductId,p.ProductName,p.Unit,si.Qty,si.Price "
                            + "FROM SalesItem si "
                           + "INNER JOIN Product p ON si.ProductId=p.ID WHERE si.SalesId='{" + id + "}' "
                        + " ORDER BY p.ProductName ASC";

                salesItems = em.ExecuteList<SalesItem>(sql, new SalesItemMapper());
            }

            return salesItems;
        }



        public void Save(IEntityManager em, Transaction tx, SalesItem salesItem)
        {
            try
            {
                string[] columns = {"ID","SalesId","ProductId","Qty","Price"};
                
                object[] values =  {Guid.NewGuid(),salesItem.SalesId,salesItem.ProductId,
                                    salesItem.Qty,salesItem.Price };

                var q = new Query().Select(columns).From(tableName).Insert(values);

                em.ExecuteNonQuery(q.ToSql(), tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Delete(IEntityManager em, Transaction tx, Guid salesId)
        {
            try
            {
                var q = new Query().From(tableName).Delete().Where("SalesId").Equal(salesId);
                em.ExecuteNonQuery(q.ToSql(),tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Delete(IEntityManager em, Transaction tx, SalesItem salesItem)
        {
            try
            {
                string[] columns = { "Qty", "Price"};

                object[] values = { 0, 0};

                var q = new Query().Select(columns).From(tableName).Update(values)
                    .Where("SalesId").Equal("{" + salesItem.SalesId + "}");

                em.ExecuteNonQuery(q.ToSql(), tx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<SalesItem> GetByMonthAndYear(int month, int year, Guid productId)
        {
            List<SalesItem> salesItems = new List<SalesItem>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT si.SalesId,si.ProductId,p.ProductName,p.Unit,si.Qty,si.Price "
                           + "FROM (SalesItem si INNER JOIN Sales sh "
                           + "ON si.SalesId = sh.ID) INNER JOIN "
                           + "Product p ON si.ProductId = p.ID "
                           + "WHERE "
                           + "Month(sh.SalesDate)=" + month + " AND Year(sh.SalesDate)=" + year
                           + "AND si.ProductId='{" + productId + "}' "
                        + " ORDER BY p.ProductName ASC";

                salesItems = em.ExecuteList<SalesItem>(sql, new SalesItemMapper());
            }

            return salesItems;
        }

    }
}
