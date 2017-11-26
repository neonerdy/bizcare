using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;
using Corbis.Repository;


namespace BizCare.Repository
{
    public interface IStockCorrectionItemRepository
    {
        List<StockCorrectionItem> GetByStockCorrectionId(Guid stockCorrectionId);
        void Save(IEntityManager em, Transaction tx, StockCorrectionItem stockCorrectionItem);
        void Delete(IEntityManager em, Transaction tx, Guid stockCorrectionId);
        void Delete(IEntityManager em, Transaction tx, StockCorrectionItem stockCorrectionItem);
        List<StockCorrectionItem> GetByMonthAndYear(int month, int year, Guid productId);

    }

    public class StockCorrectionItemRepository : IStockCorrectionItemRepository
    { 

        private string tableName = "StockCorrectionItem";
        private DataSource ds;
 
        public StockCorrectionItemRepository(DataSource ds)
        {
            this.ds = ds;
        }


        public List<StockCorrectionItem> GetByStockCorrectionId(Guid stockCorrectionId)
        {
            List<StockCorrectionItem> stockCorrectionItems = new List<StockCorrectionItem>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT si.StockCorrectionId,si.QtyPlus, si.QtyMinus, si.ValuePlus, si.ValueMinus, si.Notes, "
                            + "si.ProductId,p.ProductName, p.Unit "
                            + "FROM "
                            + "StockCorrectionItem si "
                            + "INNER JOIN Product p ON si.ProductId=p.ID "
                            + "WHERE "
                            + "si.StockCorrectionId='{" + stockCorrectionId + "}' "
                        + " ORDER BY p.ProductName ASC";

                stockCorrectionItems = em.ExecuteList<StockCorrectionItem>(sql, new StockCorrectionItemMapper());
            }

            return stockCorrectionItems;
        }



        public void Save(IEntityManager em, Transaction tx, StockCorrectionItem stockCorrectionItem)
        {
            try
            {
                string[] columns = { "ID", "StockCorrectionId", "ProductId", "QtyPlus", "QtyMinus", "ValuePlus", "ValueMinus", "Notes" };

                object[] values =  {Guid.NewGuid(),stockCorrectionItem.StockCorrectionId,stockCorrectionItem.ProductId,
                                    stockCorrectionItem.QtyPlus,stockCorrectionItem.QtyMinus,
                                   stockCorrectionItem.ValuePlus, stockCorrectionItem.ValueMinus, stockCorrectionItem.Notes};

                var q = new Query().Select(columns).From(tableName).Insert(values);

                em.ExecuteNonQuery(q.ToSql(), tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Delete(IEntityManager em, Transaction tx, Guid stockCorrectionId)
        {
            try
            {
                var q = new Query().From(tableName).Delete()
                    .Where("StockCorrectionId").Equal("{" + stockCorrectionId + "}");
                em.ExecuteNonQuery(q.ToSql(),tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(IEntityManager em, Transaction tx, StockCorrectionItem stockCorrectionItem)
        {
            try
            {
                string[] columns = { "QtyPlus", "QtyMinus", "ValuePlus", "ValueMinus" };

                object[] values = { 0, 0, 0, 0};

                var q = new Query().Select(columns).From(tableName).Update(values)
                    .Where("StockCorrectionId").Equal("{" + stockCorrectionItem.StockCorrectionId + "}");
                    

                em.ExecuteNonQuery(q.ToSql(), tx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<StockCorrectionItem> GetByMonthAndYear(int month, int year, Guid productId)
        {
            List<StockCorrectionItem> StockCorrectionItems = new List<StockCorrectionItem>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT si.StockCorrectionId,si.ProductId, si.QtyPlus, si.QtyMinus, si.ValuePlus, si.ValueMinus, p.ProductName, p.Unit, p.Notes "
                           + "FROM (StockCorrection sh INNER JOIN StockCorrectionItem si "
                           + "ON sh.ID = si.StockCorrectionId) INNER JOIN "
                           + "Product p ON si.ProductId = p.ID "
                           + "WHERE "
                           + "Month(sh.CorrectionDate)=" + month + " AND Year(sh.CorrectionDate)=" + year
                           + "AND si.ProductId='{" + productId + "}' "
                        + " ORDER BY p.ProductName ASC";

                StockCorrectionItems = em.ExecuteList<StockCorrectionItem>(sql, new StockCorrectionItemMapper());
            }

            return StockCorrectionItems;
        }

















    }
}
