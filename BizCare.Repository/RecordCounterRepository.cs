using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;

namespace BizCare.Repository
{

    public interface IRecordCounterRepository
    {
        RecordCounter GetById(Guid id);
        RecordCounter GetLast();
        RecordCounter GetByMonthAndYear(int month, int year);
        List<RecordCounter> GetAll();
        List<RecordCounter> Search(string value);
        void Save(RecordCounter recordCounter);
        void Update(RecordCounter recordCounter);
        void UpdateSalesCounter(IEntityManager em,Transaction tx,int month, int year);
        void Delete(Guid id);
        void UpdatePurchaseCounter(int month, int year);
        bool IsRecordCounterExisted(int month, int year);
        void UpdatePayablePaymentCounter(int month, int year);
        void UpdateDebtPaymentCounter(int month, int year);
        void UpdateBillReceiptCounter(int month, int year);
        bool IsPeriodClosed(int month, int year);
        void UpdateExpenseCounter(int month, int year);
        void UpdateStockCorrectionCounter(int month, int year);
        void UpdateClosingStatus(int month, int year);
    }
    
    public class RecordCounterRepository : IRecordCounterRepository
    {
        private string tableName = "RecordCounter";
        private DataSource ds;

        public RecordCounterRepository(DataSource ds)
        {
            this.ds = ds;
        }

        public RecordCounter GetById(Guid id)
        {
            RecordCounter recordCounter = null;
        
            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ID").Equal("{" + id + "}");
                recordCounter = em.ExecuteObject<RecordCounter>(q.ToSql(), new RecordCounterMapper());
            }
            
            return recordCounter;
        }


        public RecordCounter GetByYear(int year)
        {
            RecordCounter recordCounter = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ActiveYear").Equal(year);
                recordCounter = em.ExecuteObject<RecordCounter>(q.ToSql(), new RecordCounterMapper());
            }

            return recordCounter;
        }

        public RecordCounter GetLast()
        {
            RecordCounter recordCounter = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().Select("TOP 1 *").From(tableName).OrderBy("ActiveYear DESC, ActiveMonth ASC ");

                recordCounter = em.ExecuteObject<RecordCounter>(q.ToSql(), new RecordCounterMapper());
            }

            return recordCounter;
        }

        public RecordCounter GetByMonthAndYear(int month,int year)
        {
            RecordCounter recordCounter = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ActiveMonth").Equal(month)
                    .And("ActiveYear").Equal(year)
                    .OrderBy("ActiveYear DESC, ActiveMonth ASC ");
                recordCounter = em.ExecuteObject<RecordCounter>(q.ToSql(), new RecordCounterMapper());
            }

            return recordCounter;
        }

        public List<RecordCounter> GetAll()
        {
            List<RecordCounter> recordCounters = new List<RecordCounter>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).OrderBy("ActiveYear DESC, ActiveMonth ASC ");
                recordCounters = em.ExecuteList<RecordCounter>(q.ToSql(), new RecordCounterMapper());
            }

            return recordCounters;
        }


        public List<RecordCounter> Search(string value)
        {
            List<RecordCounter> recordCounters = new List<RecordCounter>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ActiveYear").Equal(int.Parse(value))
                    .OrderBy("ActiveYear DESC, ActiveMonth ASC ");
                recordCounters = em.ExecuteList<RecordCounter>(q.ToSql(), new RecordCounterMapper());

            }
            return recordCounters;
        }

        public void Save(RecordCounter recordCounter)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = {"ID","ActiveYear", "ActiveMonth","SalesCounter", "PurchaseCounter", "ExpenseCounter", 
                                        "PayablePaymentCounter", "DebtPaymentCounter","BillReceiptCounter", "StockCorrectionCounter", 
                                        "ClosingStatus","CreatedDate", "ModifiedDate"};

                    object[] values = {Guid.NewGuid(),recordCounter.ActiveYear, recordCounter.ActiveMonth,recordCounter.SalesCounter, 
                                       recordCounter.PurchaseCounter, recordCounter.ExpenseCounter,recordCounter.PayablePaymentCounter, 
                                       recordCounter.DebtPaymentCounter, recordCounter.BillReceiptCounter,recordCounter.StockCorrectionCounter,
                                       recordCounter.ClosingStatus==true?1:0,DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString()};

                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void Update(RecordCounter recordCounter)
        {
            try
            {

                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = {"ActiveYear", "ActiveMonth", "SalesCounter", "PurchaseCounter", "ExpenseCounter", 
                                        "PayablePaymentCounter", "DebtPaymentCounter", "BillReceiptCounter", "StockCorrectionCounter",
                                        "ClosingStatus", "ModifiedDate"};

                    object[] values = {recordCounter.ActiveYear, recordCounter.ActiveMonth, 
                                      recordCounter.SalesCounter, recordCounter.PurchaseCounter, recordCounter.ExpenseCounter, 
                                      recordCounter.PayablePaymentCounter, recordCounter.DebtPaymentCounter, recordCounter.BillReceiptCounter, 
                                      recordCounter.StockCorrectionCounter, recordCounter.ClosingStatus==true?1:0,
                                      DateTime.Now.ToShortDateString()};

                    var q = new Query().Select(columns).From(tableName).Update(values).Where("ID").Equal("{" + recordCounter.ID + "}");

                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public void UpdateSalesCounter(IEntityManager em,Transaction tx,int month,int year)
        {
            try
            {                 
                int salesCounter=0;

                var recordCounter = GetByMonthAndYear(month,year);

                if (recordCounter!=null) {
                    salesCounter=recordCounter.SalesCounter;    
                }

                string[] columns = { "SalesCounter" };
                object[] values = { salesCounter + 1 };

                var q = new Query().Select(columns).From(tableName).Update(values)
                    .Where("ActiveMonth").Equal(month)
                    .And("ActiveYear").Equal(year);

                em.ExecuteNonQuery(q.ToSql(),tx);
            }
            catch(Exception ex)
            {
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



        public void UpdatePurchaseCounter(int month, int year)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    int purchaseCounter = 0;

                    var recordCounter = GetByMonthAndYear(month, year);

                    if (recordCounter != null)
                    {
                        purchaseCounter = recordCounter.PurchaseCounter;
                    }

                    string[] columns = { "PurchaseCounter" };
                    object[] values = { purchaseCounter + 1 };

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ActiveMonth").Equal(month)
                        .And("ActiveYear").Equal(year);

                    em.ExecuteNonQuery(q.ToSql());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public bool IsRecordCounterExisted(int month, int year)
        {
            bool isExisted = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("RecordCounter").Where("ActiveYear").Equal(year).And("ActiveMonth").Equal(month);

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    if (rdr.Read())
                    {
                        isExisted = true;
                    }
                }

            }

            return isExisted;

        }

        public void UpdatePayablePaymentCounter(int month, int year)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    int payablePaymentCounter = 0;

                    var recordCounter = GetByMonthAndYear(month, year);

                    if (recordCounter != null)
                    {
                        payablePaymentCounter = recordCounter.PayablePaymentCounter;
                    }

                    string[] columns = { "PayablePaymentCounter" };
                    object[] values = { payablePaymentCounter + 1 };

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ActiveMonth").Equal(month)
                        .And("ActiveYear").Equal(year);

                    em.ExecuteNonQuery(q.ToSql());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void UpdateDebtPaymentCounter(int month, int year)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    int debtPaymentCounter = 0;

                    var recordCounter = GetByMonthAndYear(month, year);

                    if (recordCounter != null)
                    {
                        debtPaymentCounter = recordCounter.DebtPaymentCounter;
                    }

                    string[] columns = { "DebtPaymentCounter" };
                    object[] values = { debtPaymentCounter + 1 };

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ActiveMonth").Equal(month)
                        .And("ActiveYear").Equal(year);

                    em.ExecuteNonQuery(q.ToSql());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateBillReceiptCounter(int month, int year)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    int billReceiptCounter = 0;

                    var recordCounter = GetByMonthAndYear(month, year);

                    if (recordCounter != null)
                    {
                        billReceiptCounter = recordCounter.BillReceiptCounter;
                    }

                    string[] columns = { "BillReceiptCounter" };
                    object[] values = { billReceiptCounter + 1 };

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ActiveMonth").Equal(month)
                        .And("ActiveYear").Equal(year);

                    em.ExecuteNonQuery(q.ToSql());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public bool IsPeriodClosed(int month, int year)
        {
            bool isClosed = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("RecordCounter")
                    .Where("ActiveYear").Equal(year)
                    .And("ActiveMonth").Equal(month)
                    .And("ClosingStatus = true");

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    if (rdr.Read())
                    {
                        isClosed = true;
                    }
                }

            }

            return isClosed;

        }

        public void UpdateExpenseCounter(int month, int year)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    int expenseCounter = 0;

                    var recordCounter = GetByMonthAndYear(month, year);

                    if (recordCounter != null)
                    {
                        expenseCounter = recordCounter.ExpenseCounter;
                    }

                    string[] columns = { "ExpenseCounter" };
                    object[] values = { expenseCounter + 1 };

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ActiveMonth").Equal(month)
                        .And("ActiveYear").Equal(year);

                    em.ExecuteNonQuery(q.ToSql());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateStockCorrectionCounter(int month, int year)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    int stockCorrectionCounter = 0;

                    var recordCounter = GetByMonthAndYear(month, year);

                    if (recordCounter != null)
                    {
                        stockCorrectionCounter = recordCounter.StockCorrectionCounter;
                    }

                    string[] columns = { "StockCorrectionCounter" };
                    object[] values = { stockCorrectionCounter + 1 };

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ActiveMonth").Equal(month)
                        .And("ActiveYear").Equal(year);

                    em.ExecuteNonQuery(q.ToSql());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateClosingStatus(int month, int year)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    var recordCounter = GetByMonthAndYear(month, year);

                    string[] columns = { "ClosingStatus" };
                    object[] values = { 1 };

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ActiveMonth").Equal(month)
                        .And("ActiveYear").Equal(year);

                    em.ExecuteNonQuery(q.ToSql());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
