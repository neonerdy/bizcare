using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;


namespace BizCare.Repository
{
    public interface IBillReceiptRepository
    {
        string GenerateBillReceiptCode(int month, int year);
        BillReceipt GetById(Guid id);
        BillReceipt GetByCode(string code);
        List<string> GetAllCode(int month, int year);
        int GetBillReceiptIdByCode(string code);
        List<BillReceipt> GetAll(int month, int year);
        List<BillReceipt> GetAll();
        BillReceipt GetLast(int month, int year);
        void Save(BillReceipt billReceipt);
        void Update(BillReceipt billReceipt);
        void Delete(string code);
        void Delete(Guid id);
        void Delete(BillReceipt billReceipt);
        List<BillReceipt> Search(string value, int month, int year);
        void UpdatePrintCounter(string billReceiptCode);
    }

    public class BillReceiptRepository : IBillReceiptRepository
    {
        private DataSource ds;
        private string tableName = "BillReceipt";

        private IBillReceiptItemRepository billReceiptItemRepository;
        private IRecordCounterRepository recordCounterRepository;
       
       
        public BillReceiptRepository(DataSource ds)
        {
            this.ds = ds;
            billReceiptItemRepository = ServiceLocator.GetObject<IBillReceiptItemRepository>();
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



        public string GenerateBillReceiptCode(int month, int year)
        {

            string strYear = year.ToString().Substring(2);

            string code = "TTNT-" + strYear + GetMonthCode(month);

            int counter = 0;
            int newCounter = 0;

            var recordCounter = recordCounterRepository.GetByMonthAndYear(month, year);
            if (recordCounter != null)
                counter = recordCounter.BillReceiptCounter;

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

        public BillReceipt GetById(Guid id)
        {
            BillReceipt billReceipt = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT b.ID, b.BillReceiptCode, b.BillReceiptDate, "
                           + "b.GrandTotal, b.Notes, b.PrintCounter, "
                           + "b.SalesmanId, s.SalesmanName, "
                           + "b.CreatedDate, b.ModifiedDate, b.CreatedBy, b.ModifiedBy "
                           + "FROM "
                           + "BillReceipt b INNER JOIN Salesman s ON b.SalesmanId = s.ID "
                           + "WHERE b.ID='{" + id + "}'";

                billReceipt = em.ExecuteObject<BillReceipt>(sql, new BillReceiptMapper());

                if (billReceipt != null)
                {
                    billReceipt.BillReceiptItems = billReceiptItemRepository.GetByBillReceiptId(billReceipt.ID);
                }
            }

            return billReceipt;
        }


        public int GetBillReceiptIdByCode(string code)
        {

            int billReceiptId = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("BillReceiptCode").Equal(code);

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    if (rdr.Read())
                    {
                        billReceiptId = (int)rdr["ID"];
                    }
                }
            }

            return billReceiptId;
        }

        public BillReceipt GetByCode(string code)
        {
            BillReceipt billReceipt = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT b.ID, b.BillReceiptCode, b.BillReceiptDate, "
                        + "b.GrandTotal, b.Notes, b.PrintCounter, "
                        + "b.CreatedDate, b.ModifiedDate, b.CreatedBy, b.ModifiedBy, "
                        + "b.SalesmanId, s.SalesmanName "
                        + "FROM "
                        + "BillReceipt b INNER JOIN Salesman s ON b.SalesmanId = s.ID "
                        + "WHERE "
                        + "b.BillReceiptCode='" + code + "'";


                billReceipt = em.ExecuteObject<BillReceipt>(sql, new BillReceiptMapper());
            }

            return billReceipt;
        }

        public List<string> GetAllCode(int month, int year)
        {
            List<string> list = new List<string>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().Select("BillReceiptCode").From(tableName)
                    .Where("Month(BillReceiptDate)").Equal(month).And("Year(BillReceiptDate)").Equal(year)
                    .OrderBy("BillReceiptCode DESC");

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    while (rdr.Read())
                    {
                        string code = rdr["BillReceiptCode"].ToString();
                        list.Add(code);
                    }
                }
            }

            return list;
        }

        public List<BillReceipt> GetAll(int month, int year)
        {
            List<BillReceipt> billReceipt = new List<BillReceipt>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT b.ID, b.BillReceiptCode, b.BillReceiptDate, "
                        + "b.GrandTotal, b.Notes, b.PrintCounter,"
                        + "b.CreatedDate, b.ModifiedDate, b.CreatedBy, b.ModifiedBy, "
                        + "b.SalesmanId, s.SalesmanName "
                        + "FROM "
                        + "BillReceipt b INNER JOIN Salesman s ON b.SalesmanId = s.ID "
                        + "WHERE "
                        + "Month(BillReceiptDate)=" + month + " AND Year(BillReceiptDate)=" + year + " "
                        + "ORDER BY b.BillReceiptCode DESC";

                billReceipt = em.ExecuteList<BillReceipt>(sql, new BillReceiptMapper());
            }

            return billReceipt;
        }


        public List<BillReceipt> GetAll()
        {
            List<BillReceipt> billReceipt = new List<BillReceipt>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT b.ID, b.BillReceiptCode, b.BillReceiptDate, "
                        + "b.GrandTotal, b.Notes, b.PrintCounter, "
                        + "b.CreatedDate, b.ModifiedDate, b.CreatedBy, b.ModifiedBy, "
                        + "b.SalesmanId, s.SalesmanName "
                        + "FROM "
                        + "BillReceipt b INNER JOIN Salesman s ON b.SalesmanId = s.ID "
                        + "ORDER BY b.BillReceiptCode DESC";

                billReceipt = em.ExecuteList<BillReceipt>(sql, new BillReceiptMapper());
            }

            return billReceipt;
        }

        public BillReceipt GetLast(int month, int year)
        {
            BillReceipt billReceipt = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT TOP 1 b.ID, b.BillReceiptCode, b.BillReceiptDate, "
                        + "b.GrandTotal, b.Notes, b.PrintCounter, "
                        + "b.CreatedDate, b.ModifiedDate, b.CreatedBy, b.ModifiedBy, "
                        + "b.SalesmanId, s.SalesmanName "
                        + "FROM "
                        + "BillReceipt b INNER JOIN Salesman s ON b.SalesmanId = s.ID "
                        + "WHERE "
                        + "Month(BillReceiptDate)=" + month + " AND Year(BillReceiptDate)=" + year
                        + " ORDER BY b.BillReceiptCode DESC";

                billReceipt = em.ExecuteObject<BillReceipt>(sql, new BillReceiptMapper());
            }

            return billReceipt;
        }


        public void Save(BillReceipt billReceipt)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    Guid ID = Guid.NewGuid();

                    string[] columns = { "ID","BillReceiptCode", "BillReceiptDate","SalesmanId","Notes", "GrandTotal", "PrintCounter", 
                                         "CreatedDate","ModifiedDate","CreatedBy","ModifiedBy"};

                    object[] values = { ID,billReceipt.Code, billReceipt.BillReceiptDate.ToShortDateString(),
                                        billReceipt.SalesmanId,billReceipt.Notes, billReceipt.GrandTotal, 0,
                                        DateTime.Now.ToShortDateString(),
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser,Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    foreach (var billReceiptItem in billReceipt.BillReceiptItems)
                    {
                        billReceiptItem.BillReceiptId = ID;
                        billReceiptItemRepository.Save(em, tx, billReceiptItem);
                    }

                    recordCounterRepository.UpdateBillReceiptCounter(billReceipt.BillReceiptDate.Month, billReceipt.BillReceiptDate.Year);

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }



        private void UpdateGrandTotal(IEntityManager em, Transaction tx, Guid billReceiptId, decimal total)
        {

            string[] columns = { "GrandTotal" };
            object[] values = { total };

            var q = new Query().Select(columns).From(tableName).Update(values).Where("ID").Equal("{" + billReceiptId + "}");

            em.ExecuteNonQuery(q.ToSql(), tx);
        }



        public void Update(BillReceipt billReceipt)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    string[] columns = { "BillReceiptCode","BillReceiptDate","SalesmanId","Notes", "GrandTotal",
                                         "ModifiedDate","ModifiedBy"};

                    object[] values = { billReceipt.Code,billReceipt.BillReceiptDate,billReceipt.SalesmanId,
                                        billReceipt.Notes, billReceipt.GrandTotal,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + billReceipt.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    billReceiptItemRepository.Delete(em, tx, billReceipt.ID);

                    foreach (var billReceiptItem in billReceipt.BillReceiptItems)
                    {
                        billReceiptItem.BillReceiptId = billReceipt.ID;
                        billReceiptItemRepository.Save(em, tx, billReceiptItem);

                    }

                    UpdateGrandTotal(em, tx, billReceipt.ID, billReceipt.GrandTotal);

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();

                throw ex;
            }

        }

        public void Delete(string code)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    var q = new Query().From(tableName).Delete().Where("BillReceiptCode").Equal(code);
                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
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



        public void Delete(BillReceipt billReceipt)
        {
            Transaction tx = null;
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    String notes = "";
                    if (billReceipt.Notes != "")
                    {
                        notes = "DIBATALKAN - " + billReceipt.Notes;
                    }
                    else
                    {
                        notes = "DIBATALKAN";
                    }

                    string[] columns = { "GrandTotal","Notes","ModifiedDate","ModifiedBy"};

                    object[] values = { 0, notes,DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + billReceipt.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    var itemList = billReceiptItemRepository.GetByBillReceiptId(billReceipt.ID);

                    foreach (var billReceiptItem in itemList)
                    {
                        billReceiptItemRepository.Delete(em, tx, billReceiptItem);
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


        public List<BillReceipt> Search(string value, int month, int year)
        {
            List<BillReceipt> billReceipt = new List<BillReceipt>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {

                string sql = "SELECT b.ID, b.BillReceiptCode, b.BillReceiptDate, "
                    + "b.GrandTotal, b.Notes, b.PrintCounter, "
                    + "b.CreatedDate, b.ModifiedDate, b.CreatedBy, b.ModifiedBy, "
                    + "b.SalesmanId, s.SalesmanName "
                    + "FROM "
                    + "BillReceipt b INNER JOIN Salesman s ON b.SalesmanId = s.ID " 
                    + "WHERE "
                    + "(b.BillReceiptCode like '%" + value + "%' "
                    + "OR b.Notes LIKE  '%" + value + "%' "
                    + "OR s.SalesmanName like '%" + value + "%') "
                    + "AND Month(b.BillReceiptDate)=" + month + " AND Year(b.BillReceiptDate)=" + year
                    + " ORDER BY b.BillReceiptCode DESC";

            
                billReceipt = em.ExecuteList<BillReceipt>(sql, new BillReceiptMapper());
            }

            return billReceipt;
        }

        public void UpdatePrintCounter(string billReceiptCode)
        {
            int printCounter = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                BillReceipt billReceipt = GetByCode(billReceiptCode);
                if (billReceipt != null)
                {
                    printCounter = billReceipt.PrintCounter + 1;
                    string sql = "UPDATE " + tableName + " SET PrintCounter = " + printCounter + " WHERE BillReceiptCode='" + billReceiptCode + "'";
                    em.ExecuteNonQuery(sql);

                }
            }


        }












    }
}
