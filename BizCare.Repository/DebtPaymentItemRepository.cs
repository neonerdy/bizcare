using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;



namespace BizCare.Repository
{
    public interface IDebtPaymentItemRepository
    {
        List<DebtPaymentItem> GetByDebtPaymentId(Guid debtPaymentId);
        void Save(IEntityManager em, Transaction tx, DebtPaymentItem debtPaymentItem);
        void Delete(IEntityManager em, Transaction tx, DebtPaymentItem debtPaymentItem);
        void Delete(IEntityManager em, Transaction tx, Guid debtPaymentId);
    }

    public class DebtPaymentItemRepository : IDebtPaymentItemRepository
    {
        private string tableName = "DebtPaymentItem";
        private DataSource ds;

        public DebtPaymentItemRepository(DataSource ds)
        {
            this.ds = ds;
        }


        public List<DebtPaymentItem> GetByDebtPaymentId(Guid debtPaymentId)
        {
            List<DebtPaymentItem> debtPaymentItems = new List<DebtPaymentItem>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT di.DebtPaymentId, di.Cash, di.Bank, di.Giro, di.Correction, di.Total, di.GiroNumber, di.Notes, "
                            + "di.PurchaseId,p.PurchaseCode, p.PurchaseDate, p.GrandTotal "
                            + "FROM "
                            + "DebtPaymentItem di INNER JOIN Purchase p ON di.PurchaseId = p.ID "
                            + "WHERE "
                            + "di.DebtPaymentId='{" + debtPaymentId + "}' "
                            + "ORDER BY p.PurchaseCode DESC";

                debtPaymentItems = em.ExecuteList<DebtPaymentItem>(sql, new DebtPaymentItemMapper());
            }

            return debtPaymentItems;
        }

        public void Save(IEntityManager em, Transaction tx, DebtPaymentItem debtPaymentItem)
        {
            try
            {
                string[] columns = { "ID", "DebtPaymentId", "PurchaseId", 
                                       "Cash", "Bank", "Giro", "GiroNumber",
                                        "Correction", "Total", "Notes"};

                object[] values =  {Guid.NewGuid(),debtPaymentItem.DebtPaymentId, debtPaymentItem.PurchaseId,
                                    debtPaymentItem.Cash, debtPaymentItem.Bank,
                                   debtPaymentItem.Giro, debtPaymentItem.GiroNumber,
                                   debtPaymentItem.Correction, debtPaymentItem.Total,
                                   debtPaymentItem.Notes};

                var q = new Query().Select(columns).From(tableName).Insert(values);

                em.ExecuteNonQuery(q.ToSql(), tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(IEntityManager em, Transaction tx, Guid debtPaymentId)
        {
            try
            {

                var q = new Query().From(tableName).Delete().Where("DebtPaymentId").Equal("{" + debtPaymentId + "}");
                em.ExecuteNonQuery(q.ToSql(), tx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(IEntityManager em, Transaction tx, DebtPaymentItem debtPaymentItem)
        {
            try
            {
                string[] columns = { "Cash", "Bank", "Giro", "Correction", "Total" };

                object[] values = { 0, 0, 0, 0, 0, 0 };

                var q = new Query().Select(columns).From(tableName).Update(values)
                    .Where("DebtPaymentId").Equal("{" + debtPaymentItem.DebtPaymentId + "}");

                em.ExecuteNonQuery(q.ToSql(), tx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }



}
