using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;

namespace BizCare.Repository
{
    public interface IPurchaseRepository
    {
        string GeneratePurchaseCode(int month, int year);
        Purchase GetById(Guid id);
        Purchase GetByCode(string code);
        List<string> GetAllCode(int month, int year);
        int GetPurchaseIdByCode(string code);
        List<Purchase> GetAll(int month, int year);
        List<Purchase> GetAll();
        Purchase GetLast(int month, int year);
        List<Purchase> GetByStatusFalse();
        void SaveHeader(IEntityManager em, Transaction tx, Purchase purchase);
        void Save(Purchase purchase);
        void Update(Purchase purchase);
        void UpdateHeader(IEntityManager em, Transaction tx, Purchase purchase);
        void UpdateStatus(IEntityManager em, Transaction tx, Guid id, bool paid);       
        void Delete(string code);
        void Delete(Guid id);
        void Delete(IEntityManager em, Transaction tx, string purchaseCode);
        void Delete(Purchase purchase);
        bool IsPurchaseUsedByPayment(Guid purchaseId);
        List<Purchase> Search(string value);
        List<Purchase> Search(string value, int month, int year);
        List<Purchase> SearchStatusFalse(string value);
        void UpdatePrintCounter(string purchaseCode);

    }

    public class PurchaseRepository : IPurchaseRepository
    {
        private DataSource ds;
        private string tableName = "Purchase";

        private IPurchaseItemRepository purchaseItemRepository;
        private IRecordCounterRepository recordCounterRepository;
        private IProductQtyRepository productQtyRepository;

        public PurchaseRepository(DataSource ds)
        {
            this.ds = ds;
            purchaseItemRepository = ServiceLocator.GetObject<IPurchaseItemRepository>();
            recordCounterRepository = ServiceLocator.GetObject<IRecordCounterRepository>();
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();
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

        public string GeneratePurchaseCode(int month, int year)
        {

            string strYear = year.ToString().Substring(2);

            string code = "BLI-" + strYear + GetMonthCode(month) ;

            int counter = 0;
            int newCounter = 0;

            var recordCounter = recordCounterRepository.GetByMonthAndYear(month, year);
            if (recordCounter != null)
                counter = recordCounter.PurchaseCounter;

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

        public Purchase GetById(Guid id)
        {
            Purchase purchase = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT p.ID,p.PurchaseCode,p.PurchaseDate,p.SupplierId,s.SupplierName,"
                           + "p.PaymentMethod,p.Status,p.Notes,p.GrandTotal, "
                           + "p.CreatedDate, p.ModifiedDate, p.CreatedBy, p.ModifiedBy, "
                           + "p.AmountInWords,p.DueDate,p.PrintCounter, p.TermOfPayment "
                           + "FROM Purchase p "
                           + "INNER JOIN Supplier s ON p.SupplierId=s.ID "
                           + "WHERE "
                           + "p.ID='{" + id + "}'";

                purchase = em.ExecuteObject<Purchase>(sql, new PurchaseMapper());

                if (purchase != null)
                {
                    purchase.PurchaseItems = purchaseItemRepository.GetByPurchaseId(purchase.ID);
                }
            }

            return purchase;
        }


        public int GetPurchaseIdByCode(string code)
        {

            int purchaseId = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("PurchaseCode").Equal(code);

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    if (rdr.Read())
                    {
                        purchaseId = (int)rdr["ID"];
                    }
                }
            }

            return purchaseId;
        }



        public Purchase GetByCode(string code)
        {
            Purchase purchase = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Purchase.ID, Purchase.PurchaseCode, Purchase.PurchaseDate, Purchase.SupplierId, Supplier.SupplierName,"
                        + "Purchase.PaymentMethod, Purchase.Status, Purchase.Notes, Purchase.GrandTotal, "
                           + "Purchase.CreatedDate, Purchase.ModifiedDate, Purchase.CreatedBy, Purchase.ModifiedBy, "
                        + "Purchase.AmountInWords,Purchase.DueDate,Purchase.PrintCounter, Purchase.TermOfPayment "
                        + "FROM (Purchase INNER JOIN Supplier ON Purchase.SupplierId = Supplier.ID) "
                        + "WHERE "
                        + "Purchase.PurchaseCode='" + code + "'";


                purchase = em.ExecuteObject<Purchase>(sql, new PurchaseMapper());
            }

            return purchase;
        }



        public List<string> GetAllCode(int month, int year)
        {
            List<string> list = new List<string>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().Select("PurchaseCode").From(tableName)
                    .Where("Month(PurchaseDate)").Equal(month).And("Year(PurchaseDate)").Equal(year)
                    .OrderBy("PurchaseCode DESC");

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    while (rdr.Read())
                    {
                        string code = rdr["PurchaseCode"].ToString();
                        list.Add(code);
                    }
                }
            }

            return list;
        }




        public List<Purchase> GetAll(int month, int year)
        {
            List<Purchase> purchase = new List<Purchase>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Purchase.ID, Purchase.PurchaseCode, Purchase.PurchaseDate, Purchase.SupplierId, Supplier.SupplierName,"
                        + "Purchase.PaymentMethod, Purchase.Status, Purchase.Notes,Purchase.GrandTotal, "
                           + "Purchase.CreatedDate, Purchase.ModifiedDate, Purchase.CreatedBy, Purchase.ModifiedBy, "
                        + "Purchase.AmountInWords,Purchase.DueDate,Purchase.PrintCounter, Purchase.TermOfPayment "
                        + "FROM (Purchase INNER JOIN Supplier ON Purchase.SupplierId = Supplier.ID) "
                        + "WHERE Month(Purchase.PurchaseDate)=" + month + " AND Year(Purchase.PurchaseDate)=" + year + " "
                        + "ORDER BY Purchase.PurchaseCode DESC";

                purchase = em.ExecuteList<Purchase>(sql, new PurchaseMapper());
            }

            return purchase;
        }



        public List<Purchase> GetAll()
        {
            List<Purchase> purchase = new List<Purchase>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Purchase.ID, Purchase.PurchaseCode, Purchase.PurchaseDate, Purchase.SupplierId, Supplier.SupplierName,"
                        + "Purchase.PaymentMethod, Purchase.Status, Purchase.Notes,Purchase.GrandTotal, "
                           + "Purchase.CreatedDate, Purchase.ModifiedDate, Purchase.CreatedBy, Purchase.ModifiedBy, "
                        + "Purchase.AmountInWords,Purchase.DueDate,Purchase.PrintCounter, Purchase.TermOfPayment "
                        + "FROM (Purchase INNER JOIN Supplier ON Purchase.SupplierId = Supplier.ID) "
                        + "ORDER BY Purchase.PurchaseCode DESC";

                purchase = em.ExecuteList<Purchase>(sql, new PurchaseMapper());
            }

            return purchase;
        }





        public Purchase GetLast(int month, int year)
        {
            Purchase purchase = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT TOP 1 Purchase.ID, Purchase.PurchaseCode, Purchase.PurchaseDate, Purchase.SupplierId, Supplier.SupplierName,"
                        + "Purchase.PaymentMethod, Purchase.Status, Purchase.Notes, Purchase.GrandTotal, "
                           + "Purchase.CreatedDate, Purchase.ModifiedDate, Purchase.CreatedBy, Purchase.ModifiedBy, "
                        + "Purchase.AmountInWords,Purchase.DueDate,Purchase.PrintCounter, Purchase.TermOfPayment "
                        + "FROM (Purchase INNER JOIN Supplier ON Purchase.SupplierId = Supplier.ID) "
                        + "WHERE "
                        + "Month(Purchase.PurchaseDate)=" + month + " AND Year(Purchase.PurchaseDate)=" + year
                        + " ORDER BY Purchase.PurchaseCode DESC";

                purchase = em.ExecuteObject<Purchase>(sql, new PurchaseMapper());
            }

            return purchase;
        }

        public void Save(Purchase purchase)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    Guid ID = Guid.NewGuid();

                    string[] columns = { "ID", "PurchaseCode", "PurchaseDate", "SupplierId", "PaymentMethod", "Status", "Notes","GrandTotal",
                                           "AmountInWords", "DueDate", "PrintCounter", "TermOfPayment", 
                                         "CreatedDate", "CreatedBy" };

                    object[] values = { ID, purchase.Code, purchase.Date.ToShortDateString(),purchase.SupplierId,purchase.PaymentMethod,
                                        purchase.Status==true?1:0,purchase.Notes,purchase.GrandTotal,
                                        purchase.AmountInWords, purchase.DueDate.ToShortDateString(), purchase.PrintCounter, purchase.TermOfPayment,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    foreach (var purchaseItems in purchase.PurchaseItems)
                    {
                        purchaseItems.PurchaseId = ID;

                        purchaseItemRepository.Save(em, tx, purchaseItems);

                        //update product
                        productQtyRepository.UpdateQtyIn(Store.ActiveMonth, Store.ActiveYear, purchaseItems.ProductId, purchaseItems.Qty, true);
                        
                    }

                    recordCounterRepository.UpdatePurchaseCounter(purchase.Date.Month, purchase.Date.Year);

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }


        public void SaveHeader(IEntityManager em, Transaction tx, Purchase purchase)
        {
            string[] columns = { "ID", "PurchaseCode", "PurchaseDate", "SupplierId", "PaymentMethod", "Status", "Notes","GrandTotal",
                                   "AmountInWords", "DueDate", "PrintCounter", "TermOfPayment",
                                         "CreatedDate", "CreatedBy" };

            object[] values = { Guid.NewGuid(), purchase.Code, purchase.Date.ToShortDateString(),purchase.SupplierId,purchase.PaymentMethod,purchase.Status==true?1:0,
                                        purchase.Notes,purchase.GrandTotal,
                                        purchase.AmountInWords, purchase.DueDate.ToShortDateString(), purchase.PrintCounter, purchase.TermOfPayment,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};

            var q = new Query().Select(columns).From(tableName).Insert(values);

            em.ExecuteNonQuery(q.ToSql(), tx);
        }


        private void UpdateGrandTotal(IEntityManager em, Transaction tx, Guid purchaseId, decimal total)
        {

            string[] columns = { "GrandTotal" };
            object[] values = { total };

            var q = new Query().Select(columns).From(tableName).Update(values)
                .Where("ID").Equal("{" + purchaseId + "}");

            em.ExecuteNonQuery(q.ToSql(), tx);
        }



        public void Update(Purchase purchase)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    string[] columns = { "PurchaseCode", "PurchaseDate", "SupplierId", "PaymentMethod", "Status", "Notes", "GrandTotal",
                                         "AmountInWords", "DueDate", "TermOfPayment",
                                         "ModifiedDate","ModifiedBy"};

                    object[] values = { purchase.Code, purchase.Date,purchase.SupplierId,purchase.PaymentMethod,
                                        purchase.Status==true?1:0,purchase.Notes, purchase.GrandTotal,
                                        purchase.AmountInWords, purchase.DueDate.ToShortDateString(), purchase.TermOfPayment,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + purchase.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);


                    //detail dihapus -> update qty
                    var list = purchaseItemRepository.GetByPurchaseId(purchase.ID);
                    foreach (var purchaseItem in list)
                    {
                        productQtyRepository.UpdateQtyIn(Store.ActiveMonth, Store.ActiveYear, purchaseItem.ProductId, purchaseItem.Qty, false);

                    }
                    purchaseItemRepository.Delete(em, tx, purchase.ID);

                    foreach (var purchaseItem in purchase.PurchaseItems)
                    {
                        purchaseItem.PurchaseId = purchase.ID;
                        purchaseItemRepository.Save(em, tx, purchaseItem);

                        //update product
                        productQtyRepository.UpdateQtyIn(Store.ActiveMonth, Store.ActiveYear, purchaseItem.ProductId, purchaseItem.Qty, true);
                        
                    }

                    UpdateGrandTotal(em, tx, purchase.ID, purchase.GrandTotal);

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();

                throw ex;
            }

        }

        public void UpdateHeader(IEntityManager em, Transaction tx, Purchase purchase)
        {
            string[] columns = { "PurchaseDate", "SupplierId", "PaymentMethod", "Status", "Notes", "GrandTotal",
                                   "AmountInWords", "DueDate", "TermOfPayment", 
                                         "ModifiedDate","ModifiedBy"};

            object[] values = { purchase.Date.ToShortDateString(),purchase.SupplierId, purchase.PaymentMethod,
                                        purchase.Status==true?1:0,purchase.Notes,purchase.GrandTotal,
                                        purchase.AmountInWords, purchase.DueDate, purchase.TermOfPayment,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};

            var q = new Query().Select(columns).From(tableName).Update(values)
                .Where("PurchaseCode").Equal(purchase.Code);

            em.ExecuteNonQuery(q.ToSql(), tx);
        }

        public void Delete(string code)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    var q = new Query().From(tableName).Delete().Where("PurchaseCode").Equal(code);
                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(IEntityManager em, Transaction tx, string purchaseCode)
        {
            var q = new Query().From(tableName).Delete().Where("PurchaseCode").Equal(purchaseCode);
            em.ExecuteNonQuery(q.ToSql(), tx);
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

        public void Delete(Purchase purchase)
        {
            Transaction tx = null;
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    String notes = "";
                    if (purchase.Notes != "")
                    {
                        notes = "DIBATALKAN - " + purchase.Notes;
                    }
                    else
                    {
                        notes = "DIBATALKAN";
                    }

                    string[] columns = { "GrandTotal", "Notes",
                                         "ModifiedDate","ModifiedBy"};

                    object[] values = { 0, notes,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + purchase.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    var itemList = purchaseItemRepository.GetByPurchaseId(purchase.ID);
                    foreach (var purchaseItems in itemList)
                    {
                        purchaseItemRepository.Delete(em, tx, purchaseItems);

                        productQtyRepository.UpdateQtyIn(Store.ActiveMonth, Store.ActiveYear, purchaseItems.ProductId, purchaseItems.Qty, false);

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


        public bool IsPurchaseUsedByPayment(Guid purchaseId)
        {
            bool isUsed = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("DebtPaymentItem").Where("PurchaseId").Equal("{" + purchaseId + "}");

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


        public void UpdateStatus(IEntityManager em, Transaction tx, Guid id, bool paid)
        {
            int status = 0;
            if (paid) status = 1;


            string sql = "UPDATE " + tableName + " SET Status = " + status + " WHERE ID={" + id + "}";
            em.ExecuteNonQuery(sql, tx);


        }


        public List<Purchase> GetByStatusFalse()
        {
            List<Purchase> purchase = new List<Purchase>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Purchase.ID, Purchase.PurchaseCode, Purchase.PurchaseDate, "
                        + "Purchase.SupplierId, Supplier.SupplierName,"
                        + "Purchase.PaymentMethod, Purchase.Status, Purchase.Notes,Purchase.GrandTotal, "
                           + "Purchase.CreatedDate, Purchase.ModifiedDate, Purchase.CreatedBy, Purchase.ModifiedBy, "
                        + "Purchase.AmountInWords, Purchase.DueDate, Purchase.PrintCounter, Purchase.TermOfPayment "
                        + "FROM Purchase INNER JOIN Supplier ON Purchase.SupplierId = Supplier.ID "
                        + "WHERE Purchase.Status=false "
                        + "ORDER BY Purchase.PurchaseCode DESC";

                purchase = em.ExecuteList<Purchase>(sql, new PurchaseMapper());
            }

            return purchase;
        }


        public List<Purchase> Search(string value)
        {
            List<Purchase> purchase = new List<Purchase>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Purchase.ID, Purchase.PurchaseCode, Purchase.PurchaseDate, "
                       + "Purchase.SupplierId, Supplier.SupplierName,"
                       + "Purchase.PaymentMethod, Purchase.Status, Purchase.Notes,Purchase.GrandTotal, "
                           + "Purchase.CreatedDate, Purchase.ModifiedDate, Purchase.CreatedBy, Purchase.ModifiedBy, "
                       + "Purchase.AmountInWords, Purchase.DueDate, Purchase.PrintCounter, Purchase.TermOfPayment "
                       + "FROM Purchase INNER JOIN Supplier ON Purchase.SupplierId = Supplier.ID "
                       + "WHERE "
                       + "(Purchase.PurchaseCode like '%" + value + "%' "
                       + "OR Purchase.Notes like  '%" + value + "%' "
                       + "OR Supplier.SupplierName like '%" + value + "%') "
                       + "ORDER BY Purchase.PurchaseCode DESC";
                                              
                purchase = em.ExecuteList<Purchase>(sql, new PurchaseMapper());
            }

            return purchase;
        }

        public List<Purchase> Search(string value, int month, int year)
        {
            List<Purchase> purchase = new List<Purchase>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Purchase.ID, Purchase.PurchaseCode, Purchase.PurchaseDate, "
                       + "Purchase.SupplierId, Supplier.SupplierName,"
                       + "Purchase.PaymentMethod, Purchase.Status, Purchase.Notes,Purchase.GrandTotal, "
                           + "Purchase.CreatedDate, Purchase.ModifiedDate, Purchase.CreatedBy, Purchase.ModifiedBy, "
                       + "Purchase.AmountInWords, Purchase.DueDate, Purchase.PrintCounter, Purchase.TermOfPayment "
                       + "FROM Purchase INNER JOIN Supplier ON Purchase.SupplierId = Supplier.ID "
                       + "WHERE "
                       + "(Purchase.PurchaseCode like '%" + value + "%' "
                       + "OR Purchase.Notes like  '%" + value + "%' "
                       + "OR Supplier.SupplierName like '%" + value + "%') "
                        + "AND Month(Purchase.PurchaseDate)=" + month + " AND Year(Purchase.PurchaseDate)=" + year + " ORDER BY Purchase.PurchaseCode DESC";

                purchase = em.ExecuteList<Purchase>(sql, new PurchaseMapper());
            }

            return purchase;
        }

        public List<Purchase> SearchStatusFalse(string value)
        {
            List<Purchase> purchase = new List<Purchase>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Purchase.ID, Purchase.PurchaseCode, Purchase.PurchaseDate, "
                       + "Purchase.SupplierId, Supplier.SupplierName,"
                       + "Purchase.PaymentMethod, Purchase.Status, Purchase.Notes,Purchase.GrandTotal, "
                           + "Purchase.CreatedDate, Purchase.ModifiedDate, Purchase.CreatedBy, Purchase.ModifiedBy, "
                       + "Purchase.AmountInWords, Purchase.DueDate, Purchase.PrintCounter, Purchase.TermOfPayment "
                       + "FROM Purchase INNER JOIN Supplier ON Purchase.SupplierId = Supplier.ID "
                       + "WHERE Purchase.Status=false "
                       + "AND (Purchase.PurchaseCode like '%" + value + "%' "
                       + "OR Purchase.Notes like  '%" + value + "%' "
                       + "OR Supplier.SupplierName like '%" + value + "%') "
                       + "ORDER BY Purchase.PurchaseCode DESC";

                purchase = em.ExecuteList<Purchase>(sql, new PurchaseMapper());
            }

            return purchase;
        }

        public void UpdatePrintCounter(string purchaseCode)
        {
            int printCounter = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                Purchase purchase = GetByCode(purchaseCode);
                if (purchase != null)
                {
                    printCounter = purchase.PrintCounter + 1;
                    string sql = "UPDATE " + tableName + " SET PrintCounter = " + printCounter + " WHERE PurchaseCode='" + purchaseCode + "'";
                    em.ExecuteNonQuery(sql);

                }
            }


        }






    }
}
