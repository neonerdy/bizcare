using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;


namespace BizCare.Repository
{
    public interface IDebtBalanceRepository
    {
        DebtBalance GetById(Guid id);
        DebtBalance GetByCode(string code);
        DebtBalance GetLast();
        DebtBalance GetLast(int month, int year);
        List<DebtBalance> GetAll();
        List<DebtBalance> GetAll(int month, int year);
        List<DebtBalance> Search(int month,int year,string value);
        void Save(DebtBalance debtBalance);
        void Update(DebtBalance debtBalance);
        void UpdateStatusFromPayment(IEntityManager em, Transaction tx, string purchaseCode, bool paid);
        void Delete(Guid id, string purchaseCode);
        bool IsPurchaseCodeExisted(String purchaseCode);
        void SaveFromClosingPeriod(DebtBalance debtBalance);
        void UpdateFromClosingPeriod(DebtBalance debtBalance);
        void Delete(int month, int year);
        DebtBalance GetByMonthYear(int month, int year, string purchaseCode);
    }


    public class DebtBalanceRepository : IDebtBalanceRepository
    {
        private string tableName = "DebtBalance";
        private DataSource ds;

        private ISupplierRepository supplierRepository;
        private IPurchaseRepository purchaseRepository;
        
        public DebtBalanceRepository(DataSource ds)
        {
            supplierRepository = ServiceLocator.GetObject<ISupplierRepository>();
            purchaseRepository = ServiceLocator.GetObject<IPurchaseRepository>();

            this.ds = ds;
        }



        public DebtBalance GetById(Guid id)
        {
            DebtBalance debtBalance = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT db.ID, db.BalanceYear, db.BalanceMonth, db.PurchaseCode, db.PurchaseDate, db.SupplierId, s.SupplierName, "
                        + "db.PaymentMethod, db.GrandTotal, db.IsStatus, db.Notes, db.CreatedDate, db.ModifiedDate, "                
                        + "db.AmountInWords, db.DueDate, db.TermOfPayment "
                        + "FROM DebtBalance db INNER JOIN Supplier s ON db.SupplierId = s.ID "
                        + "WHERE "
                        + "db.ID='{" + id + "}'";

                debtBalance = em.ExecuteObject<DebtBalance>(sql, new DebtBalanceMapper());
            }

            return debtBalance;
        }

        public DebtBalance GetByCode(string code)
        {
            DebtBalance debtBalance = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT db.ID, db.BalanceYear, db.BalanceMonth, db.PurchaseCode, db.PurchaseDate, db.SupplierId, s.SupplierName, "
                        + "db.PaymentMethod, db.GrandTotal, db.IsStatus, db.Notes, db.CreatedDate, db.ModifiedDate, "
                        + "db.AmountInWords, db.DueDate, db.TermOfPayment "
                        + "FROM DebtBalance db INNER JOIN Supplier s ON db.SupplierId = s.ID "
                        + "WHERE "
                        + "db.PurchaseCode='" + code + "'";

                debtBalance = em.ExecuteObject<DebtBalance>(sql, new DebtBalanceMapper());
            }

            return debtBalance;
        }

        public DebtBalance GetLast()
        {
            DebtBalance debtBalance = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT TOP 1 db.ID, db.BalanceYear, db.BalanceMonth, db.PurchaseCode, db.PurchaseDate, db.SupplierId, s.SupplierName, "
                        + "db.PaymentMethod, db.GrandTotal, db.IsStatus, db.Notes, db.CreatedDate, db.ModifiedDate, "
                        + "db.AmountInWords, db.DueDate, db.TermOfPayment "                              
                        + "FROM DebtBalance db INNER JOIN Supplier s ON db.SupplierId = s.ID "
                        + "ORDER BY db.PurchaseCode DESC";

                debtBalance = em.ExecuteObject<DebtBalance>(sql, new DebtBalanceMapper());
            }

            return debtBalance;
        }

        public DebtBalance GetLast(int month, int year)
        {
            DebtBalance debtBalance = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT TOP 1 db.ID, db.BalanceYear, db.BalanceMonth, db.PurchaseCode, db.PurchaseDate, db.SupplierId, s.SupplierName, "
                        + "db.PaymentMethod, db.GrandTotal, db.IsStatus, db.Notes, db.CreatedDate, db.ModifiedDate, "
                        + "db.AmountInWords, db.DueDate, db.TermOfPayment "                        
                        + "FROM DebtBalance db INNER JOIN Supplier s ON db.SupplierId = s.ID "
                        + "WHERE db.BalanceMonth=" + month + " AND db.BalanceYear=" + year + " "
                        + "ORDER BY db.PurchaseCode DESC";

                debtBalance = em.ExecuteObject<DebtBalance>(sql, new DebtBalanceMapper());
            }

            return debtBalance;
        }

        public DebtBalance GetByMonthYear(int month, int year, string purchaseCode)
        {
            DebtBalance debtBalance = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT db.ID, db.BalanceYear, db.BalanceMonth, db.PurchaseCode, db.PurchaseDate, db.SupplierId, s.SupplierName, "
                        + "db.PaymentMethod, db.GrandTotal, db.IsStatus, db.Notes, db.CreatedDate, db.ModifiedDate, "
                        + "db.AmountInWords, db.DueDate, db.TermOfPayment "                        
                        + "FROM DebtBalance db INNER JOIN Supplier s ON db.SupplierId = s.ID "
                        + "WHERE "
                        + "db.PurchaseCode like '%" + purchaseCode + "%' "
                        + "AND db.BalanceMonth=" + month + " AND db.BalanceYear=" + year + " "
                        + "ORDER BY db.PurchaseCode DESC";

                debtBalance = em.ExecuteObject<DebtBalance>(sql, new DebtBalanceMapper());
            }

            return debtBalance;
        }

        public List<DebtBalance> GetAll()
        {
            List<DebtBalance> debtBalance = new List<DebtBalance>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT db.ID, db.BalanceYear, db.BalanceMonth, db.PurchaseCode, db.PurchaseDate, db.SupplierId, s.SupplierName, "
                        + "db.PaymentMethod, db.GrandTotal, db.IsStatus, db.Notes, db.CreatedDate, db.ModifiedDate, "
                        + "db.AmountInWords, db.DueDate, db.TermOfPayment "                        
                        + "FROM DebtBalance db INNER JOIN Supplier s ON db.SupplierId = s.ID "
                        + "ORDER BY db.PurchaseCode DESC";

                debtBalance = em.ExecuteList<DebtBalance>(sql, new DebtBalanceMapper());
            }

            return debtBalance;

        }

        public List<DebtBalance> GetAll(int month, int year)
        {
            List<DebtBalance> debtBalance = new List<DebtBalance>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT db.ID, db.BalanceYear, db.BalanceMonth, db.PurchaseCode, db.PurchaseDate, db.SupplierId, s.SupplierName, "
                        + "db.PaymentMethod, db.GrandTotal, db.IsStatus, db.Notes, db.CreatedDate, db.ModifiedDate, "
                        + "db.AmountInWords, db.DueDate, db.TermOfPayment "                        
                        + "FROM DebtBalance db INNER JOIN Supplier s ON db.SupplierId = s.ID "
                        + "WHERE db.BalanceMonth=" + month + " AND db.BalanceYear=" + year + " "
                        + "ORDER BY db.PurchaseCode DESC";

                debtBalance = em.ExecuteList<DebtBalance>(sql, new DebtBalanceMapper());
            }

            return debtBalance;

        }

        public List<DebtBalance> Search (int month,int year,string value)
        {
            List<DebtBalance> debtBalance = new List<DebtBalance>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT db.ID, db.BalanceYear, db.BalanceMonth, db.PurchaseCode, db.PurchaseDate, db.SupplierId, s.SupplierName, "
                        + "db.PaymentMethod, db.GrandTotal, db.IsStatus, db.Notes, db.CreatedDate, db.ModifiedDate, "
                        + "db.AmountInWords, db.DueDate, db.TermOfPayment "                        
                        + "FROM DebtBalance db INNER JOIN Supplier s ON db.SupplierId = s.ID "
                        + "WHERE db.BalanceMonth=" + month + " AND db.BalanceYear=" + year + " "
                        + "AND (db.PurchaseCode like '%" + value + "%' "
                        + "OR s.SupplierName like '%" + value + "%'  "
                        + "OR db.Notes like '%" + value + "%') "
                        + "ORDER BY db.PurchaseCode DESC";

                debtBalance = em.ExecuteList<DebtBalance>(sql, new DebtBalanceMapper());

            }

            return debtBalance;
        }

        private Purchase CopyToPurchase(DebtBalance debtBalance)
        {
            Purchase purchase = new Purchase();

            purchase.Code = debtBalance.PurchaseCode;
            purchase.Date = debtBalance.PurchaseDate;
            purchase.SupplierId = debtBalance.SupplierId;
            purchase.PaymentMethod = debtBalance.PaymentMethod;
            purchase.Status = debtBalance.IsStatus;
            purchase.Notes = debtBalance.Notes;
            purchase.GrandTotal = debtBalance.GrandTotal;
            purchase.DueDate = debtBalance.DueDate;
            purchase.AmountInWords = debtBalance.AmountInWords;
            purchase.PrintCounter = 0;
            purchase.TermOfPayment = debtBalance.TermOfPayment;

            return purchase;
        }

        public void Save(DebtBalance debtBalance)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    Guid ID = Guid.NewGuid();

                    tx = em.BeginTransaction();

                    string[] columns = {"ID", "BalanceYear", "BalanceMonth", "PurchaseCode", "PurchaseDate", "SupplierId", 
                                        "PaymentMethod", "GrandTotal", "IsStatus", "Notes",
                                        "AmountInwords", "DueDate", "TermOfPayment", 
                                        "CreatedDate", "ModifiedDate"};

                    object[] values = {ID, debtBalance.BalanceYear, debtBalance.BalanceMonth, debtBalance.PurchaseCode, debtBalance.PurchaseDate.ToShortDateString(), debtBalance.SupplierId, 
                                      debtBalance.PaymentMethod, debtBalance.GrandTotal, debtBalance.IsStatus==true?1:0, debtBalance.Notes,
                                      debtBalance.AmountInWords, debtBalance.DueDate.ToShortDateString(), debtBalance.TermOfPayment,
                                      DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString() };

                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    //copy to purchase
                    Purchase purchase = CopyToPurchase(debtBalance);
                    purchaseRepository.SaveHeader(em, tx, purchase);


                    //supplierRepository.PlusFirstBalance(debtBalance.SupplierId, debtBalance.GrandTotal);


                    tx.Commit();

                }

            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }

        }

        public void Update(DebtBalance debtBalance)
        {
            Transaction tx = null;

            try
            {

                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    
                    tx = em.BeginTransaction();

                    decimal oldGrandTotal = 0;
                    var oldDebtBalance = GetById(debtBalance.ID);
                    if (oldDebtBalance != null)
                    {
                        oldGrandTotal = oldDebtBalance.GrandTotal;
                        
                        supplierRepository.MinusFirstBalance(debtBalance.SupplierId, oldGrandTotal);
                    }


                    string[] columns = {"BalanceYear", "BalanceMonth", "PurchaseCode", "PurchaseDate", "SupplierId", 
                    "PaymentMethod", "Notes", "GrandTotal", "IsStatus", "AmountInWords", "DueDate", "TermOfPayment",
                    "ModifiedDate"};

                    object[] values = {debtBalance.BalanceYear, debtBalance.BalanceMonth, debtBalance.PurchaseCode, debtBalance.PurchaseDate.ToShortDateString(), debtBalance.SupplierId, 
                                      debtBalance.PaymentMethod, debtBalance.Notes, debtBalance.GrandTotal, debtBalance.IsStatus==true?1:0, 
                                      debtBalance.AmountInWords, debtBalance.DueDate,  debtBalance.TermOfPayment,
                                      DateTime.Now.ToShortDateString() };

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + debtBalance.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    //copy to purchase
                    Purchase purchase = CopyToPurchase(debtBalance);
                    purchaseRepository.UpdateHeader(em, tx, purchase);


                    supplierRepository.PlusFirstBalance(debtBalance.SupplierId, debtBalance.GrandTotal);

                    tx.Commit();

                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }

        public void Delete(Guid id, string purchaseCode)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    var q = new Query().From(tableName).Delete().Where("ID").Equal("{" + id + "}");
                    em.ExecuteNonQuery(q.ToSql(), tx);


                    purchaseRepository.Delete(em, tx, purchaseCode);

                    tx.Commit();
                }

            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }

        }

        public bool IsPurchaseCodeExisted(String purchaseCode)
        {
            bool isExisted = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("DebtBalance").Where("PurchaseCode").Equal(purchaseCode);

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

        public void UpdateStatusFromPayment(IEntityManager em, Transaction tx, string purchaseCode, bool paid)
        {
            int status = 0;
            if (paid) status = 1;

            string sql = "UPDATE " + tableName + " SET IsStatus= " + status + " WHERE PurchaseCode='" + purchaseCode + "'";
            em.ExecuteNonQuery(sql, tx);


        }

        public void SaveFromClosingPeriod(DebtBalance debtBalance)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    Guid ID = Guid.NewGuid();

                    tx = em.BeginTransaction();

                    string[] columns = {"ID", "BalanceYear", "BalanceMonth", "PurchaseCode", "PurchaseDate", "SupplierId", 
                    "PaymentMethod", "GrandTotal", "IsStatus", "Notes", "AmountInWords", "DueDate", "TermOfPayment",
                    "CreatedDate", "ModifiedDate"};

                    object[] values = {ID, debtBalance.BalanceYear, debtBalance.BalanceMonth, debtBalance.PurchaseCode, debtBalance.PurchaseDate.ToShortDateString(), debtBalance.SupplierId, 
                                      debtBalance.PaymentMethod, debtBalance.GrandTotal, debtBalance.IsStatus==true?1:0, debtBalance.Notes,
                                      debtBalance.AmountInWords, debtBalance.DueDate.ToShortDateString(), debtBalance.TermOfPayment,
                                      DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString() };

                    var q = new Query().Select(columns).From(tableName).Insert(values);

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

        public void UpdateFromClosingPeriod(DebtBalance debtBalance)
        {
            Transaction tx = null;

            try
            {

                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    tx = em.BeginTransaction();

                    decimal oldGrandTotal = 0;
                    var oldDebtBalance = GetById(debtBalance.ID);
                    if (oldDebtBalance != null)
                    {
                        oldGrandTotal = oldDebtBalance.GrandTotal;

                    }


                    string[] columns = {"BalanceYear", "BalanceMonth", "PurchaseCode", "PurchaseDate", "SupplierId", 
                    "PaymentMethod", "Notes", "GrandTotal", "IsStatus", "AmountInWords", "DueDate", "TermOfPayment",
                    "ModifiedDate"};

                    object[] values = {debtBalance.BalanceYear, debtBalance.BalanceMonth, debtBalance.PurchaseCode, debtBalance.PurchaseDate.ToShortDateString(), debtBalance.SupplierId, 
                                      debtBalance.PaymentMethod, debtBalance.Notes, debtBalance.GrandTotal, debtBalance.IsStatus==true?1:0, 
                                      debtBalance.AmountInWords, debtBalance.DueDate, debtBalance.TermOfPayment,
                                      DateTime.Now.ToShortDateString() };

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + debtBalance.ID + "}");

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
