using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;


namespace BizCare.Repository
{

    public interface IExpenseRepository
    {
        string GenerateExpenseCode(int month, int year);
        Expense GetById(Guid id);
        int GetExpenseIdByCode(string code);
        Expense GetByCode(String code);
        List<string> GetAllCode(int month, int year);
        Expense GetLast(int month, int year);
        List<Expense> GetAll(int month, int year);
        List<Expense> GetAll();
        List<Expense> Search(string value);
        void Save(Expense expense);
        void Update(Expense expense);
        void Delete(Guid id);
        void UpdateGrandTotal(IEntityManager em, Transaction tx, Guid expenseId, decimal total);
        void Delete(IEntityManager em, Transaction tx, string expenseCode);
        void Delete(Expense expense);
        List<Expense> Search(string value, int month, int year);
        void Delete(string code);
        void UpdatePrintCounter(string expenseCode);
    }


    public class ExpenseRepository : IExpenseRepository
    {
        private string tableName = "Expense";
        private DataSource ds;

        private IExpenseItemRepository expenseItemRepository;
        private IRecordCounterRepository recordCounterRepository;
        
        public ExpenseRepository(DataSource ds)
        {
            this.ds = ds;
            expenseItemRepository = ServiceLocator.GetObject<IExpenseItemRepository>();
            recordCounterRepository = ServiceLocator.GetObject<IRecordCounterRepository>();
            
        }

        private string GetMonthCode(int month)
        {
            string monthCode = string.Empty;

            switch (month)
            {
                case 1:
                    monthCode = "A";
                    break;
                case 2:
                    monthCode = "B";
                    break;
                case 3:
                    monthCode = "C";
                    break;
                case 4:
                    monthCode = "D";
                    break;
                case 5:
                    monthCode = "E";
                    break;
                case 6:
                    monthCode = "F";
                    break;
                case 7:
                    monthCode = "G";
                    break;
                case 8:
                    monthCode = "H";
                    break;
                case 9:
                    monthCode = "I";
                    break;
                case 10:
                    monthCode = "J";
                    break;
                case 11:
                    monthCode = "K";
                    break;
                case 12:
                    monthCode = "L";
                    break;

            }

            return monthCode;
        }

        public string GenerateExpenseCode(int month, int year)
        {

            string strYear = year.ToString().Substring(2);

            string code = "BY-" + strYear + GetMonthCode(month);

            int counter = 0;
            int newCounter = 0;

            var recordCounter = recordCounterRepository.GetByMonthAndYear(month, year);
            if (recordCounter != null)
                counter = recordCounter.ExpenseCounter;

            if (counter == 0)
            {
                code = code + "0001";
            }
            else
            {
                newCounter = counter + 1;
                code = code + newCounter.ToString("D4");
            }

            return code;
        }



        public Expense GetById(Guid id)
        {
            Expense expense = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ID").Equal("{" + id + "}");
                expense = em.ExecuteObject<Expense>(q.ToSql(), new ExpenseMapper());
            }

            if (expense != null)
            {
                expense.ExpenseItems = expenseItemRepository.GetByExpenseId(expense.ID);
            }      

            return expense;
        }


        public int GetExpenseIdByCode(string code)
        {

            int expenseId = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ExpenseCode").Equal(code);

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    if (rdr.Read())
                    {
                        expenseId = (int)rdr["ID"];
                    }
                }
            }

            return expenseId;
        }


        public Expense GetByCode(string code)
        {
            Expense expense = new Expense();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ExpenseCode").Equal(code);
                expense = em.ExecuteObject<Expense>(q.ToSql(), new ExpenseMapper());
            }

            return expense;

        }

        public List<string> GetAllCode(int month, int year)
        {
            List<string> list = new List<string>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().Select("ExpenseCode").From(tableName)
                    .Where("Month(ExpenseDate)").Equal(month).And("Year(ExpenseDate)").Equal(year)
                    .OrderBy("ExpenseCode DESC");

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    while (rdr.Read())
                    {
                        string code = rdr["ExpenseCode"].ToString();
                        list.Add(code);
                    }
                }
            }

            return list;
        }

        public Expense GetLast(int month, int year)
        {
            Expense expense = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT TOP 1 ID, ExpenseCode, ExpenseDate, AccountType, AccountName, AccountNumber, "
                        + "Notes, GrandTotal, AmountInWords, PrintCounter, "
                        + "CreatedDate,ModifiedDate, CreatedBy, ModifiedBy "
                        + "FROM Expense WHERE Month(ExpenseDate)=" + month + " AND Year(ExpenseDate)=" + year
                        + " ORDER BY ExpenseCode DESC";

                expense = em.ExecuteObject<Expense>(sql, new ExpenseMapper());
            }

            return expense;
        }


        public List<Expense> GetAll(int month, int year)
        {
            List<Expense> expense = new List<Expense>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT ID, ExpenseCode, ExpenseDate, "
                        + "AccountType,AccountName,AccountNumber, "
                        + "GrandTotal,Notes, AmountInWords, PrintCounter, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                        + "FROM Expense WHERE Month(ExpenseDate)=" + month + " AND Year(ExpenseDate)=" + year + " "
                        + "ORDER BY ExpenseCode DESC";

                expense = em.ExecuteList<Expense>(sql, new ExpenseMapper());
            }

            return expense;
        }

        public List<Expense> GetAll()
        {
            List<Expense> expenses = new List<Expense>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).OrderBy("ExpenseCode DESC");
                expenses = em.ExecuteList<Expense>(q.ToSql(), new ExpenseMapper());
            }

            return expenses;
        }


        public List<Expense> Search(string value)
        {
            List<Expense> expenses = new List<Expense>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName)
                    .Where("Notes").Like("%" + value + "%")
                    .And("AccountType").Like("%" + value + "%")
                    .And("AccountName").Like("%" + value + "%")
                    .And("AccountNumber").Like("%" + value + "%")
                    .OrderBy("ExpenseCode DESC");

                expenses = em.ExecuteList<Expense>(q.ToSql(), new ExpenseMapper());
            }

            return expenses;
        }



        public void Save(Expense expense)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    Guid ID = Guid.NewGuid();
                    
                    string[] columns = { "ID","ExpenseCode","ExpenseDate","AccountType","AccountName","AccountNumber",
                                         "Notes", "GrandTotal", "AmountInWords", "PrintCounter", 
                                         "CreatedDate","ModifiedDate","CreatedBy","ModifiedBy" };

                    object[] values = { ID,expense.Code,expense.Date.ToShortDateString(),expense.AccountType,expense.AccountName, 
                                        expense.AccountNumber,expense.Notes,expense.GrandTotal, 
                                        expense.AmountInWords, expense.PrintCounter,
                                        DateTime.Now.ToShortDateString(),DateTime.Now.ToShortDateString(),
                                        Store.ActiveUser,Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    foreach (var expenseItem in expense.ExpenseItems)
                    {
                        expenseItem.ExpenseId = ID;
                        expenseItemRepository.Save(em, tx, expenseItem);
                    }

                    recordCounterRepository.UpdateExpenseCounter(expense.Date.Month, expense.Date.Year);

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }
        

        public void UpdateGrandTotal(IEntityManager em, Transaction tx, Guid expenseId, decimal total)
        {
            string[] columns = { "GrandTotal" };
            object[] values = { total };

            var q = new Query().Select(columns).From(tableName).Update(values).Where("ID").Equal("{" + expenseId + "}");

            em.ExecuteNonQuery(q.ToSql(), tx);
        }



        public void Update(Expense expense)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();


                    string[] columns = { "ExpenseCode","ExpenseDate","AccountType","AccountName","AccountNumber",
                                         "Notes","GrandTotal", "AmountInWords", "PrintCounter",  
                                         "ModifiedDate","ModifiedBy" };

                    object[] values = { expense.Code,expense.Date.ToShortDateString(),expense.AccountType,expense.AccountName, 
                                        expense.AccountNumber,expense.Notes, expense.GrandTotal,
                                        expense.AmountInWords, expense.PrintCounter,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};
                                        
                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + expense.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    expenseItemRepository.Delete(em, tx, expense.ID);

                    foreach (var expenseItem in expense.ExpenseItems)
                    {
                        expenseItem.ExpenseId = expense.ID;
                        expenseItemRepository.Save(em, tx, expenseItem);
                    }

                    UpdateGrandTotal(em, tx, expense.ID, expense.GrandTotal);

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();

                throw ex;
            }

        }
        

        public void Delete(Guid id)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    var q = new Query().From(tableName).Delete().Where("ID").Equal("{" + id + "}");
                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void Delete(IEntityManager em, Transaction tx, string expenseCode)
        {
            var q = new Query().From(tableName).Delete().Where("ExpenseCode").Equal(expenseCode);
            em.ExecuteNonQuery(q.ToSql(), tx);
        }



        public void Delete(Expense expense)
        {
            Transaction tx = null;
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    String notes = "";
                    if (expense.Notes != "")
                    {
                        notes = "DIBATALKAN - " + expense.Notes;
                    }
                    else
                    {
                        notes = "DIBATALKAN";
                    }

                    string[] columns = { "GrandTotal","Notes","ModifiedDate","ModifiedBy"};

                    object[] values = { 0,notes,DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + expense.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    var itemList = expenseItemRepository.GetByExpenseId(expense.ID);
                    foreach (var expenseItems in itemList)
                    {
                        expenseItemRepository.Delete(em, tx, expenseItems);
                        
                    }

                    tx.Commit();
                }

            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }


        public List<Expense> Search(string value, int month, int year)
        {
            List<Expense> expense = new List<Expense>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Expense.ID, Expense.ExpenseCode, Expense.ExpenseDate, "
                        + "Expense.AccountType, Expense.AccountName, Expense.AccountNumber, "
                        + "Expense.GrandTotal, Expense.Notes, Expense.AmountInWords, Expense.PrintCounter, "
                        + "Expense.CreatedDate,  Expense.ModifiedDate, Expense.CreatedBy, Expense.ModifiedBy "
                        + "FROM Expense WHERE (Expense.ExpenseCode like '%" + value + "%' "
                        + "OR Expense.Notes like  '%" + value + "%' "
                        + "OR Expense.AccountType like  '%" + value + "%' "
                        + "OR Expense.AccountName like  '%" + value + "%' "
                        + "OR Expense.AccountNumber like  '%" + value + "%') "
                        + "AND Month(Expense.ExpenseDate)=" + month + " AND Year(Expense.ExpenseDate)=" + year
                        + " ORDER BY Expense.ExpenseCode DESC";

                expense = em.ExecuteList<Expense>(sql, new ExpenseMapper());
            }

            return expense;
        }

        public void Delete(string code)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    var q = new Query().From(tableName).Delete().Where("ExpenseCode").Equal(code);
                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePrintCounter(string expenseCode)
        {
            int printCounter = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                Expense expense = GetByCode(expenseCode);
                if (expense != null)
                {
                    printCounter = expense.PrintCounter + 1;
                    string sql = "UPDATE " + tableName + " SET PrintCounter = " + printCounter + " WHERE ExpenseCode='" + expenseCode + "'";
                    em.ExecuteNonQuery(sql);

                }
            }


        }

















    }
}
