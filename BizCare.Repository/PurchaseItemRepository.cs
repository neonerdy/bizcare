using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;


namespace BizCare.Repository
{
    public interface IPurchaseItemRepository
    {
        List<PurchaseItem> GetByPurchaseId(Guid id);
        void Save(IEntityManager em, Transaction tx, PurchaseItem purchaseItem);
        void Delete(IEntityManager em, Transaction tx, Guid purchaseId);
        void Delete(IEntityManager em, Transaction tx, PurchaseItem purchaseItem);
        List<PurchaseItem> GetByMonthAndYear(int month, int year, Guid productId);

    }

    public class PurchaseItemRepository : IPurchaseItemRepository
    {
        private string tableName = "PurchaseItem";
        private DataSource ds;

        public PurchaseItemRepository(DataSource ds)
        {
            this.ds = ds;
        }


        public List<PurchaseItem> GetByPurchaseId(Guid id)
        {
            List<PurchaseItem> purchaseItems = new List<PurchaseItem>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT si.PurchaseId,si.ProductId,p.ProductName,p.Unit,si.Qty,si.Price "
                           + "FROM PurchaseItem si "
                           + "INNER JOIN Product p ON si.ProductId=p.ID WHERE si.PurchaseId='{" + id + "}' "
                        + " ORDER BY p.ProductName ASC";

                purchaseItems = em.ExecuteList<PurchaseItem>(sql, new PurchaseItemMapper());
            }

            return purchaseItems;
        }



        public void Save(IEntityManager em, Transaction tx, PurchaseItem purchaseItem)
        {
            try
            {
                string[] columns = {"ID", "PurchaseId", "ProductId", "Qty", "Price" };

                object[] values =  {Guid.NewGuid(), purchaseItem.PurchaseId,purchaseItem.ProductId,
                                    purchaseItem.Qty,purchaseItem.Price };

                var q = new Query().Select(columns).From(tableName).Insert(values);

                em.ExecuteNonQuery(q.ToSql(), tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Delete(IEntityManager em, Transaction tx, Guid purchaseId)
        {
            try
            {
                var q = new Query().From(tableName).Delete().Where("PurchaseId").Equal("{" + purchaseId + "}");
                em.ExecuteNonQuery(q.ToSql(), tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

          public void Delete(IEntityManager em, Transaction tx, PurchaseItem purchaseItem)
        {
            try
            {
                string[] columns = { "Qty", "Price"};

                object[] values = { 0, 0};

                var q = new Query().Select(columns).From(tableName).Update(values)
                    .Where("PurchaseId").Equal("{" + purchaseItem.PurchaseId + "}");

                em.ExecuteNonQuery(q.ToSql(), tx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

          public List<PurchaseItem> GetByMonthAndYear(int month, int year, Guid productId)
          {
              List<PurchaseItem> purchaseItems = new List<PurchaseItem>();

              using (var em = EntityManagerFactory.CreateInstance(ds))
              {
                  string sql = "SELECT pi.PurchaseId,pi.ProductId,p.ProductName,p.Unit,pi.Qty,pi.Price "
                             + "FROM (PurchaseItem pi INNER JOIN Purchase ph "
                             + "ON pi.PurchaseId = ph.ID) INNER JOIN "
                             + "Product p ON pi.ProductId = p.ID "
                             + "WHERE "
                             + "Month(ph.PurchaseDate)=" + month + " AND Year(ph.PurchaseDate)=" + year                       
                             + "AND pi.ProductId='{" + productId + "}' "
                        + " ORDER BY p.ProductName ASC";


                  purchaseItems = em.ExecuteList<PurchaseItem>(sql, new PurchaseItemMapper());
              }

              return purchaseItems;
          }



    }
}
