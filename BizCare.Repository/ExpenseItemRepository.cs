using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;



namespace BizCare.Repository
{
    public interface IExpenseItemRepository
    {
        List<ExpenseItem> GetByExpenseId(Guid id);
        void Save(IEntityManager em, Transaction tx, ExpenseItem expenseItem);
        void Delete(IEntityManager em, Transaction tx, Guid expenseId);
        void Delete(IEntityManager em, Transaction tx, ExpenseItem expenseItem);
        decimal GetSummary(int month, int year);
    }


    public class ExpenseItemRepository : IExpenseItemRepository
    {
        private string tableName = "ExpenseItem";
        private DataSource ds;
 
        public ExpenseItemRepository(DataSource ds)
        {
            this.ds = ds;
        }

        public List<ExpenseItem> GetByExpenseId(Guid id)
        {
            List<ExpenseItem> expenseItems = new List<ExpenseItem>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT ExpenseId, Total,Notes "
                            + "FROM ExpenseItem "
                            + "WHERE ExpenseId='{" + id + "}'";

                expenseItems = em.ExecuteList<ExpenseItem>(sql, new ExpenseItemMapper());
            }

            return expenseItems;
        }

        public void Save(IEntityManager em, Transaction tx, ExpenseItem expenseItem)
        {
            try
            {
                string[] columns = { "ID", "ExpenseId", "Total", "Notes" };

                object[] values =  { Guid.NewGuid(), expenseItem.ExpenseId, expenseItem.Total, expenseItem.Notes };

                var q = new Query().Select(columns).From(tableName).Insert(values);

                em.ExecuteNonQuery(q.ToSql(), tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Delete(IEntityManager em, Transaction tx, Guid expenseId)
        {
            try
            {
                var q = new Query().From(tableName).Delete().Where("ExpenseId").Equal("{" + expenseId + "}");
                em.ExecuteNonQuery(q.ToSql(), tx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(IEntityManager em, Transaction tx, ExpenseItem expenseItem)
        {
            try
            {
                string[] columns = { "Total" };

                object[] values = { 0 };

                var q = new Query().Select(columns).From(tableName).Update(values)
                    .Where("ExpenseId").Equal("{" + expenseItem.ExpenseId + "}");

                em.ExecuteNonQuery(q.ToSql(), tx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetSummary(int month, int year)
        {
            decimal expenseSummary = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Sum(ExpenseItem.Total) AS Summary "
                    + "FROM Expense INNER JOIN ExpenseItem ON Expense.ID = ExpenseItem.ExpenseId "
                    + "GROUP BY Month([ExpenseDate]), Year([ExpenseDate]) "
                    + "HAVING Month(ExpenseDate)= " + month + "AND Year(ExpenseDate)= " + year;


                using (var rdr = em.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        expenseSummary =  (decimal) rdr["Summary"];
                    }
                }


            }

            return expenseSummary;
        }












    }
}
