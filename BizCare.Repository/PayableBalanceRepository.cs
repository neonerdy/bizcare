using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;


namespace BizCare.Repository
{
    public interface IPayableBalanceRepository
    {
        PayableBalance GetById(Guid id);
        PayableBalance GetByCode(string code);
        PayableBalance GetLast();
        PayableBalance GetLast(int month, int year);
        List<PayableBalance> GetAll();
        List<string> GetAllCode(int month, int year);
        List<PayableBalance> GetAll(int month, int year);
        List<PayableBalance> Search(int month,int year,string value);
        void Save(PayableBalance payableBalance);
        void Update(PayableBalance payableBalance);
        void UpdateStatusFromPayment(IEntityManager em, Transaction tx, string salesCode, bool paid);
        void Delete(Guid id, string salesCode);
        bool IsSalesCodeExisted(String salesCode);
        bool IsPayableBalanceUsedByBillReceipt(Guid salesId);
        
        void SaveFromClosingPeriod(PayableBalance payableBalance);
        void UpdateFromClosingPeriod(PayableBalance payableBalance);

        void Delete(int month, int year);
        PayableBalance GetByMonthYear(int month, int year, string salesCode);
    }


    public class PayableBalanceRepository : IPayableBalanceRepository
    {
        private string tableName = "PayableBalance";
        private DataSource ds;

        private IPayableBalanceItemRepository payableBalanceItemRepository; 
        private ISalesRepository salesRepository;


        public PayableBalanceRepository(DataSource ds)
        {
            payableBalanceItemRepository = ServiceLocator.GetObject<IPayableBalanceItemRepository>();
            salesRepository = ServiceLocator.GetObject<ISalesRepository>();

            this.ds = ds;
        }



        public PayableBalance GetById(Guid id)
        {
            PayableBalance payableBalance = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT pb.ID, pb.BalanceYear, pb.BalanceMonth, pb.SalesCode, pb.SalesDate, pb.CustomerId, c.CustomerName, "
                        + "pb.SalesmanId, s.SalesmanName, pb.PaymentMethod, pb.GrandTotal, pb.IsStatus, Pb.Notes, "
                        + "pb.CreatedDate, pb.ModifiedDate, "
                        + "pb.AmountInWords, pb.DueDate, pb.TermOfPayment "
                        + "FROM (PayableBalance pb INNER JOIN Customer c ON pb.CustomerId = c.ID) "
                        + "INNER JOIN Salesman s ON pb.SalesmanId = s.ID "
                        + "WHERE "
                        + "pb.ID='{" + id + "}'";
                
                payableBalance = em.ExecuteObject<PayableBalance>(sql, new PayableBalanceMapper());
            }

            return payableBalance;
        }


        public PayableBalance GetByCode(string code)
        {
            PayableBalance payableBalance = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT pb.ID, pb.BalanceYear, pb.BalanceMonth, pb.SalesCode, pb.SalesDate, pb.CustomerId, c.CustomerName, "
                       + "pb.SalesmanId, s.SalesmanName, pb.PaymentMethod, pb.GrandTotal, pb.IsStatus, Pb.Notes, "
                       + "pb.CreatedDate, pb.ModifiedDate, "
                       + "pb.AmountInWords, pb.DueDate, pb.TermOfPayment "
                       + "FROM (PayableBalance pb INNER JOIN Customer c ON pb.CustomerId = c.ID) "
                       + "INNER JOIN Salesman s ON pb.SalesmanId = s.ID "
                       + "WHERE "
                       + "pb.SalesCode='" + code + "'";


                payableBalance = em.ExecuteObject<PayableBalance>(sql, new PayableBalanceMapper());
            }

            return payableBalance;
        }




        public PayableBalance GetLast()
        {
            PayableBalance payableBalance = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT TOP 1 pb.ID, pb.BalanceYear, pb.BalanceMonth, pb.SalesCode, pb.SalesDate, pb.CustomerId, c.CustomerName, "
                        + "pb.SalesmanId, s.SalesmanName, pb.PaymentMethod, pb.GrandTotal, pb.IsStatus, Pb.Notes, pb.CreatedDate, pb.ModifiedDate, "
                        + "pb.AmountInWords, pb.DueDate, pb.TermOfPayment "
                        + "FROM (PayableBalance pb INNER JOIN Customer c ON pb.CustomerId = c.ID) "
                        + "INNER JOIN Salesman s ON pb.SalesmanId = s.ID "
                        + "ORDER BY pb.SalesCode DESC";
               
                payableBalance = em.ExecuteObject<PayableBalance>(sql, new PayableBalanceMapper());
            }

            return payableBalance;
        }


        public PayableBalance GetByMonthYear(int month, int year, string salesCode)
        {
            PayableBalance payableBalance = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT pb.ID, pb.BalanceYear, pb.BalanceMonth, pb.SalesCode, pb.SalesDate, pb.CustomerId, c.CustomerName, "
                        + "pb.SalesmanId, s.SalesmanName, pb.PaymentMethod, pb.GrandTotal, pb.IsStatus, Pb.Notes, pb.CreatedDate, pb.ModifiedDate, "
                        + "pb.AmountInWords, pb.DueDate, pb.TermOfPayment "
                        + "FROM (PayableBalance pb INNER JOIN Customer c ON pb.CustomerId = c.ID) "
                        + "INNER JOIN Salesman s ON pb.SalesmanId = s.ID "
                        + "WHERE "
                        + "pb.SalesCode like '%" + salesCode + "%' "
                        + "AND pb.BalanceMonth=" + month + " AND pb.BalanceYear=" + year + " "
                        + "ORDER BY pb.SalesCode DESC";

                payableBalance = em.ExecuteObject<PayableBalance>(sql, new PayableBalanceMapper());
            }

            return payableBalance;
        }

        public PayableBalance GetLast(int month, int year)
        {
            PayableBalance payableBalance = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT TOP 1 pb.ID, pb.BalanceYear, pb.BalanceMonth, pb.SalesCode, pb.SalesDate, pb.CustomerId, c.CustomerName, "
                        + "pb.SalesmanId, s.SalesmanName, pb.PaymentMethod, pb.GrandTotal, pb.IsStatus, Pb.Notes, pb.CreatedDate, pb.ModifiedDate, "
                        + "pb.AmountInWords, pb.DueDate, pb.TermOfPayment "
                        + "FROM (PayableBalance pb INNER JOIN Customer c ON pb.CustomerId = c.ID) "
                        + "INNER JOIN Salesman s ON pb.SalesmanId = s.ID "
                        + "WHERE pb.BalanceMonth=" + month + " AND pb.BalanceYear=" + year + " "
                        + "ORDER BY pb.SalesCode DESC";
                        

                payableBalance = em.ExecuteObject<PayableBalance>(sql, new PayableBalanceMapper());
            }

            return payableBalance;
        }



        public List<string> GetAllCode(int month, int year)
        {
            List<string> list = new List<string>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().Select("SalesCode").From(tableName)
                    .Where("BalanceMonth").Equal(month).And("BalanceYear").Equal(year)
                    .OrderBy("SalesCode DESC");

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    while (rdr.Read())
                    {
                        string code = rdr["SalesCode"].ToString();
                        list.Add(code);
                    }
                }
            }

            return list;
        }



        public List<PayableBalance> GetAll()
        {
            List<PayableBalance> payableBalance = new List<PayableBalance>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT pb.ID, pb.BalanceYear, pb.BalanceMonth, pb.SalesCode, pb.SalesDate, pb.CustomerId, c.CustomerName, " 
                        + "pb.SalesmanId, s.SalesmanName, pb.PaymentMethod, pb.GrandTotal, pb.IsStatus, Pb.Notes, pb.CreatedDate, pb.ModifiedDate, "
                        + "pb.AmountInWords, pb.DueDate, pb.TermOfPayment "
                        + "FROM (PayableBalance pb INNER JOIN Customer c ON pb.CustomerId = c.ID) "
                        + "INNER JOIN Salesman s ON pb.SalesmanId = s.ID "
                        + "ORDER BY pb.SalesCode DESC";
                  
                payableBalance = em.ExecuteList<PayableBalance>(sql, new PayableBalanceMapper());

            }

            return payableBalance;

        }

        public List<PayableBalance> GetAll(int month, int year)
        {
            List<PayableBalance> payableBalance = new List<PayableBalance>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT pb.ID, pb.BalanceYear, pb.BalanceMonth, pb.SalesCode, pb.SalesDate, pb.CustomerId, c.CustomerName, "
                        + "pb.SalesmanId, s.SalesmanName, pb.PaymentMethod, pb.GrandTotal, pb.IsStatus, Pb.Notes, pb.CreatedDate, pb.ModifiedDate, "
                        + "pb.AmountInWords, pb.DueDate, pb.TermOfPayment "
                        + "FROM (PayableBalance pb INNER JOIN Customer c ON pb.CustomerId = c.ID) "
                        + "INNER JOIN Salesman s ON pb.SalesmanId = s.ID "
                        + "WHERE pb.BalanceMonth=" + month + " AND pb.BalanceYear=" + year + " "
                        + "ORDER BY pb.SalesCode DESC";

                payableBalance = em.ExecuteList<PayableBalance>(sql, new PayableBalanceMapper());
            }

            return payableBalance;
        }

        public List<PayableBalance> Search(int month,int year,string value)
        {


            List<PayableBalance> payableBalance = new List<PayableBalance>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {

                var sql = "SELECT pb.ID, pb.BalanceYear, pb.BalanceMonth, pb.SalesCode, pb.SalesDate, pb.CustomerId, c.CustomerName, "
                        + "pb.SalesmanId, s.SalesmanName, pb.PaymentMethod, pb.GrandTotal, pb.IsStatus, Pb.Notes, pb.CreatedDate, pb.ModifiedDate, "
                        + "pb.AmountInWords, pb.DueDate, pb.TermOfPayment "
                        + "FROM (PayableBalance pb INNER JOIN Customer c ON pb.CustomerId = c.ID) "
                        + "INNER JOIN Salesman s ON pb.SalesmanId = s.ID "
                        + "WHERE pb.BalanceMonth=" + month + " AND pb.BalanceYear=" + year + " "
                        + "AND (pb.SalesCode like '%" + value + "%' "
                        + "OR c.CustomerName like '%" + value + "%'  "
                        + "OR s.SalesmanName like '%" + value + "%'  "
                        + "OR pb.Notes like '%" + value + "%') "
                        + "ORDER BY pb.SalesCode DESC";

                payableBalance = em.ExecuteList<PayableBalance>(sql, new PayableBalanceMapper());

            }

            return payableBalance;
        }


        private void UpdateGrandTotal(IEntityManager em, Transaction tx, Guid payableBalanceId, decimal total)
        {

            string[] columns = { "GrandTotal" };
            object[] values = { total };

            var q = new Query().Select(columns).From(tableName).Update(values)
                .Where("ID").Equal("{" + payableBalanceId + "}");

            em.ExecuteNonQuery(q.ToSql(), tx);
        }



        private Sales CopyToSales(PayableBalance payableBalance)
        {
            Sales sales = new Sales();

            sales.Code = payableBalance.SalesCode;
            sales.Date = payableBalance.SalesDate;
            sales.CustomerId = payableBalance.CustomerId;
            sales.SalesmanId = payableBalance.SalesmanId;
            sales.PaymentMethod = payableBalance.PaymentMethod;
            sales.Status = payableBalance.IsStatus;
            sales.Notes = payableBalance.Notes;
            sales.GrandTotal = payableBalance.GrandTotal;
            sales.AmountInWords = payableBalance.AmountInWords;
            sales.DueDate = payableBalance.DueDate;
            sales.PrintCounter = 0;
            sales.TermOfPayment = payableBalance.TermOfPayment;

            List<SalesItem> salesItems = new List<SalesItem>();

            foreach (var payableBalanceItem in payableBalance.PayableBalanceItems)
            {
                SalesItem si = new SalesItem();

                si.SalesId = payableBalanceItem.PayableBalanceId;
                si.ProductId = payableBalanceItem.ProductId;
                si.Qty = payableBalanceItem.Qty;
                si.Price = payableBalanceItem.Price;

                salesItems.Add(si);
            }

            sales.SalesItems = salesItems;

            return sales;
        }



        public void Save(PayableBalance payableBalance)
        {

            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    Guid ID = Guid.NewGuid();

                    tx = em.BeginTransaction();

                    string[] columns = {"ID", "BalanceYear", "BalanceMonth", "SalesCode", "SalesDate", "CustomerId", 
                                        "SalesmanId", "PaymentMethod", "GrandTotal", "IsStatus", 
                                        "Notes", "AmountInWords", "DueDate", "TermOfPayment",
                                        "CreatedDate", "ModifiedDate"};


                    object[] values = {ID, payableBalance.BalanceYear, payableBalance.BalanceMonth, payableBalance.SalesCode, payableBalance.SalesDate.ToShortDateString(),
                                      payableBalance.CustomerId, payableBalance.SalesmanId, 
                                      payableBalance.PaymentMethod, payableBalance.GrandTotal, 
                                      payableBalance.IsStatus==true?1:0, 
                                      payableBalance.Notes, payableBalance.AmountInWords, payableBalance.DueDate.ToShortDateString(), payableBalance.TermOfPayment,
                                      DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString() };

                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql(),tx);

                    //save detail

                    foreach (var payableBalanceItem in payableBalance.PayableBalanceItems)
                    {
                        payableBalanceItem.PayableBalanceId = ID;
                        payableBalanceItemRepository.Save(em, tx, payableBalanceItem);
                    }
                    
                    //copy to sales
                   
                    Sales sales = CopyToSales(payableBalance);
                    salesRepository.Save(em, tx, sales);                  
                                        
                    tx.Commit();
                }

            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }

        }


        public void Update(PayableBalance payableBalance)
        {
            Transaction tx = null;

            try
            {

                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    //decimal oldGrandTotal = 0;
                    //var oldPayableBalance = GetById(payableBalance.ID);
                   
                    //if (oldPayableBalance != null)
                    //{
                    //    oldGrandTotal = oldPayableBalance.GrandTotal;
                    //}

                    string[] columns = {"BalanceYear", "BalanceMonth", "SalesCode", "SalesDate", "CustomerId", 
                                        "SalesmanId", "PaymentMethod", "GrandTotal", "IsStatus", 
                                        "Notes", "AmountInWords", "DueDate", "TermOfPayment",
                                        "ModifiedDate"};

                    object[] values = {payableBalance.BalanceYear, payableBalance.BalanceMonth, payableBalance.SalesCode, payableBalance.SalesDate.ToShortDateString(), 
                                      payableBalance.CustomerId, payableBalance.SalesmanId, 
                                      payableBalance.PaymentMethod, payableBalance.GrandTotal, payableBalance.IsStatus==true?1:0, 
                                      payableBalance.Notes , payableBalance.AmountInWords, payableBalance.DueDate.ToShortDateString(), payableBalance.TermOfPayment,
                                      DateTime.Now.ToShortDateString() };

                    var q = new Query().Select(columns).From(tableName).Update(values).Where("ID").Equal("{" + payableBalance.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);
                    
                    payableBalanceItemRepository.Delete(em, tx, payableBalance.ID);

                    foreach (var payableBalanceItem in payableBalance.PayableBalanceItems)
                    {
                        payableBalanceItem.PayableBalanceId = payableBalance.ID;
                        payableBalanceItemRepository.Save(em, tx, payableBalanceItem);

                    }

                    UpdateGrandTotal(em, tx, payableBalance.ID, payableBalance.GrandTotal);
                                      
                    
                    //update sales

                    salesRepository.Delete(em, tx, payableBalance.SalesCode);

                    Sales sales = CopyToSales(payableBalance);
                    salesRepository.Save(em, tx, sales);
                    
                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }

        public void UpdateStatusFromPayment(IEntityManager em, Transaction tx, string salesCode, bool paid)
        {
            int status = 0;
            if (paid) status = 1;
            
            string sql = "UPDATE " + tableName + " SET IsStatus= " +  status + " WHERE SalesCode='" + salesCode + "'";
            em.ExecuteNonQuery(sql, tx);


        }

        public void Delete(Guid id, string salesCode)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    var q = new Query().From(tableName).Delete().Where("ID").Equal("{" + id + "}");
                    em.ExecuteNonQuery(q.ToSql(), tx);

                    salesRepository.Delete(em, tx, salesCode);

                    tx.Commit();
                }

            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }

        }

        public bool IsSalesCodeExisted(String salesCode)
        {
            bool isExisted = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("PayableBalance").Where("SalesCode").Equal(salesCode);

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

        public bool IsPayableBalanceUsedByBillReceipt(Guid salesId)
        {
            bool isUsed = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("BillReceiptItem").Where("SalesId").Equal("{" + salesId + "}");

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    if (rdr.Read())
                    {
                        isUsed = true;
                    }
                }

            }

            return isUsed;

        }



        public void SaveFromClosingPeriod(PayableBalance payableBalance)
        {

            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    Guid ID = Guid.NewGuid();

                    tx = em.BeginTransaction();

                    string[] columns = {"ID", "BalanceYear", "BalanceMonth", "SalesCode", "SalesDate", "CustomerId", 
                                        "SalesmanId", "PaymentMethod", "GrandTotal", "IsStatus", 
                                        "Notes", "AmountInWords", "DueDate", "TermOfPayment",
                                        "CreatedDate", "ModifiedDate"};

                    object[] values = {ID, payableBalance.BalanceYear, payableBalance.BalanceMonth, payableBalance.SalesCode, payableBalance.SalesDate.ToShortDateString(),
                                      payableBalance.CustomerId, payableBalance.SalesmanId,payableBalance.PaymentMethod, payableBalance.GrandTotal, 
                                      payableBalance.IsStatus==true?1:0,payableBalance.Notes, payableBalance.AmountInWords, payableBalance.DueDate.ToShortDateString(), payableBalance.TermOfPayment,
                                      DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString() };

                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    //save detail

                    foreach (var payableBalanceItem in payableBalance.PayableBalanceItems)
                    {
                        payableBalanceItem.PayableBalanceId = ID;
                        payableBalanceItemRepository.Save(em, tx, payableBalanceItem);
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



        public void UpdateFromClosingPeriod(PayableBalance payableBalance)
        {
            Transaction tx = null;

            try
            {

                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    string[] columns = {"BalanceYear", "BalanceMonth", "SalesCode", "SalesDate", "CustomerId", 
                                        "SalesmanId", "PaymentMethod", "GrandTotal", "IsStatus", 
                                        "Notes", "AmountInWords", "DueDate", "TermOfPayment",
                                        "ModifiedDate"};

                    object[] values = {payableBalance.BalanceYear, payableBalance.BalanceMonth, payableBalance.SalesCode, payableBalance.SalesDate.ToShortDateString(), 
                                      payableBalance.CustomerId, payableBalance.SalesmanId,payableBalance.PaymentMethod, payableBalance.GrandTotal, payableBalance.IsStatus==true?1:0, 
                                      payableBalance.Notes , payableBalance.AmountInWords, payableBalance.DueDate.ToShortDateString(), payableBalance.TermOfPayment,
                                      DateTime.Now.ToShortDateString() };

                    var q = new Query().Select(columns).From(tableName).Update(values).Where("ID").Equal("{" + payableBalance.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    payableBalanceItemRepository.Delete(em, tx, payableBalance.ID);

                    foreach (var payableBalanceItem in payableBalance.PayableBalanceItems)
                    {
                        payableBalanceItem.PayableBalanceId = payableBalance.ID;
                        payableBalanceItemRepository.Save(em, tx, payableBalanceItem);

                    }

                    UpdateGrandTotal(em, tx, payableBalance.ID, payableBalance.GrandTotal);

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }



        public void Delete(int month, int year)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    var q = new Query().From(tableName).Delete()
                        .Where("BalanceMonth").Equal(month)
                        .And("BalanceYear").Equal(year);
                    em.ExecuteNonQuery(q.ToSql(), tx);

                    tx.Commit();
                }

            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }

        }


    }
}
