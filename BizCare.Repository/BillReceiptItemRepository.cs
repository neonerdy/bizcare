using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;



namespace BizCare.Repository
{

    public interface IBillReceiptItemRepository
    {
        List<BillReceiptItem> GetByBillReceiptId(Guid id);
        void Save(IEntityManager em, Transaction tx, BillReceiptItem billReceiptItem);
        void Delete(IEntityManager em, Transaction tx, BillReceiptItem billReceiptItem);
        void Delete(IEntityManager em, Transaction tx, Guid billReceiptId);
    }


    public class BillReceiptItemRepository : IBillReceiptItemRepository
    {
        private string tableName = "BillReceiptItem";
        private DataSource ds;
        private ISalesRepository salesRepository;

        public BillReceiptItemRepository(DataSource ds)
        {
            this.ds = ds;
            salesRepository = ServiceLocator.GetObject<ISalesRepository>();

        }
        
        public List<BillReceiptItem> GetByBillReceiptId(Guid id)
        {
            List<BillReceiptItem> billReceiptItems = new List<BillReceiptItem>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT b.BillReceiptId, b.Total, b.Notes, "
                            + "b.SalesId,s.SalesCode, s.SalesDate, s.GrandTotal, "
                            + "s.CustomerId,c.CustomerName, "
                            + "s.SalesmanId,sl.SalesmanName "                           
                            + "FROM "
                            + "((BillReceiptItem b INNER JOIN Sales s ON b.SalesId = s.ID) "
                            + "INNER JOIN Customer c ON s.CustomerId = c.ID) "
                            + "INNER JOIN Salesman sl ON s.SalesmanId = sl.ID "
                            + "WHERE b.BillReceiptId='{" + id + "}' "
                            + "ORDER BY s.SalesCode DESC";

                billReceiptItems = em.ExecuteList<BillReceiptItem>(sql, new BillReceiptItemMapper());
            }

            return billReceiptItems;
        }


        public void Save(IEntityManager em, Transaction tx, BillReceiptItem billReceiptItem)
        {
            try
            {
                string[] columns = { "ID", "BillReceiptId", "SalesId", "Total", "Notes"};

                object[] values =  { Guid.NewGuid(), billReceiptItem.BillReceiptId, billReceiptItem.SalesId,
                                    billReceiptItem.Total, billReceiptItem.Notes};

                var q = new Query().Select(columns).From(tableName).Insert(values);

                em.ExecuteNonQuery(q.ToSql(), tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Delete(IEntityManager em, Transaction tx, Guid billReceiptId)
        {
            try
            {

                var q = new Query().From(tableName).Delete().Where("BillReceiptId ").Equal("{" + billReceiptId + "}");
                em.ExecuteNonQuery(q.ToSql(), tx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(IEntityManager em, Transaction tx, BillReceiptItem billReceiptItem)
        {
            try
            {
                string[] columns = { "Total" };

                object[] values = { 0 };

                var q = new Query().Select(columns).From(tableName).Update(values)
                    .Where("BillReceiptId").Equal("{" + billReceiptItem.BillReceiptId + "}");

                em.ExecuteNonQuery(q.ToSql(), tx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
















    }
}
