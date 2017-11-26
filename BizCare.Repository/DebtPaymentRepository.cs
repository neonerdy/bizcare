using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;



namespace BizCare.Repository
{
    public interface IDebtPaymentRepository
    {
        string GenerateDebtPaymentCode(int month, int year);
        DebtPayment GetById(Guid id);
        DebtPayment GetByCode(string code);
        List<string> GetAllCode(int month, int year);
        int GetDebtPaymentIdByCode(string code);
        List<DebtPayment> GetAll(int month, int year);
        List<DebtPayment> GetAll();
        DebtPayment GetLast(int month, int year);
        void Save(DebtPayment debtPayment);
        void Update(DebtPayment debtPayment);
        void Delete(string code);
        void Delete(Guid id);
        void Delete(DebtPayment debtPayment);
        List<DebtPayment> Search(string value, int month, int year);
    }

    public class DebtPaymentRepository : IDebtPaymentRepository
    {
        private DataSource ds;
        private string tableName = "DebtPayment";

        private IDebtPaymentItemRepository debtPaymentItemRepository;
        private IRecordCounterRepository recordCounterRepository;
        private IPurchaseRepository purchaseRepository;
        private IDebtBalanceRepository debtBalanceRepository;

        public DebtPaymentRepository(DataSource ds)
        {
            this.ds = ds;
            debtPaymentItemRepository = ServiceLocator.GetObject<IDebtPaymentItemRepository>();
            recordCounterRepository = ServiceLocator.GetObject<IRecordCounterRepository>();
            purchaseRepository = ServiceLocator.GetObject<IPurchaseRepository>();
            debtBalanceRepository = ServiceLocator.GetObject<IDebtBalanceRepository>();
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

        public string GenerateDebtPaymentCode(int month, int year)
        {

            string strYear = year.ToString().Substring(2);

            string code = "PH-" + strYear + GetMonthCode(month);

            int counter = 0;
            int newCounter = 0;

            var recordCounter = recordCounterRepository.GetByMonthAndYear(month, year);
            if (recordCounter != null)
                counter = recordCounter.DebtPaymentCounter;

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

        public DebtPayment GetById(Guid id)
        {
            DebtPayment debtPayment = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT dp.ID, dp.PaymentCode, dp.PaymentDate, "
                           + "dp.TotalCash, dp.TotalBank, dp.TotalGiro, dp.TotalCorrection, dp.GrandTotal, dp.Notes, "
                        + "dp.CreatedDate,dp.ModifiedDate, dp.CreatedBy, dp.ModifiedBy "
                           + "FROM DebtPayment dp "
                           + "WHERE "
                           + "dp.ID='{" + id + "}'";

                debtPayment = em.ExecuteObject<DebtPayment>(sql, new DebtPaymentMapper());

                if (debtPayment != null)
                {
                    debtPayment.DebtPaymentItems = debtPaymentItemRepository.GetByDebtPaymentId(debtPayment.ID);
                }
            }

            return debtPayment;
        }


        public int GetDebtPaymentIdByCode(string code)
        {

            int debtPaymentId = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("PaymentCode").Equal(code);

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    if (rdr.Read())
                    {
                        debtPaymentId = (int)rdr["ID"];
                    }
                }
            }

            return debtPaymentId;
        }


        public DebtPayment GetByCode(string code)
        {
            DebtPayment debtPayment = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT ID, PaymentCode, PaymentDate, "
                        + "TotalCash, TotalBank, TotalGiro, TotalCorrection, GrandTotal, Notes, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                        + "FROM DebtPayment "
                        + "WHERE PaymentCode='" + code + "'";


                debtPayment = em.ExecuteObject<DebtPayment>(sql, new DebtPaymentMapper());
            }

            return debtPayment;
        }

        public List<string> GetAllCode(int month, int year)
        {
            List<string> list = new List<string>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().Select("PaymentCode").From(tableName)
                    .Where("Month(PaymentDate)").Equal(month).And("Year(PaymentDate)").Equal(year)
                    .OrderBy("PaymentCode DESC");

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    while (rdr.Read())
                    {
                        string code = rdr["PaymentCode"].ToString();
                        list.Add(code);
                    }
                }
            }

            return list;
        }

        public List<DebtPayment> GetAll(int month, int year)
        {
            List<DebtPayment> debtPayment = new List<DebtPayment>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT ID, PaymentCode, PaymentDate, "
                        + "TotalCash, TotalBank, TotalGiro, TotalCorrection, GrandTotal, Notes, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                + "FROM DebtPayment "
                + "WHERE Month(PaymentDate)=" + month + " AND Year(PaymentDate)=" + year + " "
                + "ORDER BY PaymentCode DESC";

                debtPayment = em.ExecuteList<DebtPayment>(sql, new DebtPaymentMapper());
            }

            return debtPayment;
        }


        public List<DebtPayment> GetAll()
        {
            List<DebtPayment> debtPayment = new List<DebtPayment>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT ID, PaymentCode, PaymentDate, "
                        + "TotalCash, TotalBank, TotalGiro, TotalCorrection, GrandTotal, Notes, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                        + "FROM DebtPayment " 
                        + "ORDER BY PaymentCode DESC";

                debtPayment = em.ExecuteList<DebtPayment>(sql, new DebtPaymentMapper());
            }

            return debtPayment;
        }

        public DebtPayment GetLast(int month, int year)
        {
            DebtPayment debtPayment = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT TOP 1 ID, PaymentCode, PaymentDate, "
                        + "TotalCash, TotalBank, TotalGiro, TotalCorrection, GrandTotal, Notes, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                + "FROM DebtPayment "
                + "WHERE Month(PaymentDate)=" + month + " AND Year(PaymentDate)=" + year
                + " ORDER BY DebtPayment.PaymentCode DESC";

                debtPayment = em.ExecuteObject<DebtPayment>(sql, new DebtPaymentMapper());
            }

            return debtPayment;
        }

        
        public void Save(DebtPayment debtPayment)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    Guid ID = Guid.NewGuid();

                    string[] columns = { "ID", "PaymentCode", "PaymentDate", "TotalCash", "TotalBank", "TotalGiro", "TotalCorrection", 
                                           "GrandTotal", "Notes",
                                         "CreatedDate", "CreatedBy" };

                    object[] values = { ID, debtPayment.PaymentCode, debtPayment.PaymentDate.ToShortDateString(),debtPayment.TotalCash,
                                          debtPayment.TotalBank, debtPayment.TotalGiro, debtPayment.TotalCorrection,
                                          debtPayment.GrandTotal, debtPayment.Notes,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    foreach (var debtPaymentItems in debtPayment.DebtPaymentItems)
                    {
                        debtPaymentItems.DebtPaymentId = ID;

                        debtPaymentItemRepository.Save(em, tx, debtPaymentItems);

                        //update status = lunas
                        purchaseRepository.UpdateStatus(em, tx, debtPaymentItems.PurchaseId, true);

                        //update status = lunas
                        debtBalanceRepository.UpdateStatusFromPayment(em, tx, debtPaymentItems.Purchase.Code, true);
                    }

                    recordCounterRepository.UpdateDebtPaymentCounter(debtPayment.PaymentDate.Month, debtPayment.PaymentDate.Year);

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }


        private void UpdateGrandTotal(IEntityManager em, Transaction tx, Guid debtPaymentId, decimal total)
        {

            string[] columns = { "GrandTotal" };
            object[] values = { total };

            var q = new Query().Select(columns).From(tableName).Update(values)
                .Where("ID").Equal("{" + debtPaymentId + "}");

            em.ExecuteNonQuery(q.ToSql(), tx);
        }

        public void Update(DebtPayment debtPayment)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    string[] columns = { "PaymentDate", "TotalCash", "TotalBank", "TotalGiro", "TotalCorrection", "Notes",
                                         "ModifiedDate","ModifiedBy"};

                    object[] values = { debtPayment.PaymentDate, debtPayment.TotalCash,debtPayment.TotalBank,
                                          debtPayment.TotalGiro, debtPayment.TotalCorrection, debtPayment.Notes,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + debtPayment.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);


                    ////detail dihapus -> update status = false
                    var list=debtPaymentItemRepository.GetByDebtPaymentId(debtPayment.ID);
                    foreach (var debtItem in list)
                    {
                        purchaseRepository.UpdateStatus(em, tx, debtItem.PurchaseId, false);
                        debtBalanceRepository.UpdateStatusFromPayment(em, tx, debtItem.Purchase.Code, false);
                    }

                    debtPaymentItemRepository.Delete(em, tx, debtPayment.ID);



                    foreach (var debtPaymentItem in debtPayment.DebtPaymentItems)
                    {

                        debtPaymentItem.DebtPaymentId = debtPayment.ID;

                        debtPaymentItemRepository.Save(em, tx, debtPaymentItem);

                        //update status = lunas
                        purchaseRepository.UpdateStatus(em, tx, debtPaymentItem.PurchaseId, true);

                        //update status = lunas
                        debtBalanceRepository.UpdateStatusFromPayment(em, tx, debtPaymentItem.Purchase.Code, true);
                    }

                    UpdateGrandTotal(em, tx, debtPayment.ID, debtPayment.GrandTotal);

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
                    var q = new Query().From(tableName).Delete().Where("PaymentCode").Equal(code);
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

        public void Delete(DebtPayment debtPayment)
        {
            Transaction tx = null;
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    String notes = "";
                    if (debtPayment.Notes != "")
                    {
                        notes = "DIBATALKAN - " + debtPayment.Notes;
                    }
                    else
                    {
                        notes = "DIBATALKAN";
                    }

                    string[] columns = { "TotalCash", "TotalBank", "TotalGiro", "TotalCorrection", "GrandTotal", "Notes",
                                         "ModifiedDate","ModifiedBy"};

                    object[] values = { 0, 0,0, 0, 0, notes,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal(debtPayment.ID);

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    var itemList = debtPaymentItemRepository.GetByDebtPaymentId(debtPayment.ID);
                    foreach (var debtPaymentItem in itemList)
                    {
                        debtPaymentItemRepository.Delete(em, tx, debtPaymentItem);
                    }

                    foreach (var item in itemList)
                    {
                        //update status = lunas
                        purchaseRepository.UpdateStatus(em, tx, item.PurchaseId, false);

                        //update status = lunas
                        debtBalanceRepository.UpdateStatusFromPayment(em, tx, item.Purchase.Code, false);
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

        public List<DebtPayment> Search(string value, int month, int year)
        {
            List<DebtPayment> debtPayment = new List<DebtPayment>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {

                string sql = "SELECT dp.ID, dp.PaymentCode, dp.PaymentDate, "
                        + "dp.TotalCash, dp.TotalBank, dp.TotalGiro, dp.TotalCorrection, dp.GrandTotal, dp.Notes, "
                        + "dp.CreatedDate,dp.ModifiedDate, dp.CreatedBy, dp.ModifiedBy "
                        + "FROM DebtPayment dp "
                        + "WHERE "
                        + "(dp.PaymentCode like '%" + value + "%' "
                        + "OR dp.Notes like  '%" + value + "%') "
                        + "AND Month(dp.PaymentDate)=" + month + " AND Year(dp.PaymentDate)=" + year
                        + " ORDER BY dp.PaymentCode DESC";

                debtPayment = em.ExecuteList<DebtPayment>(sql, new DebtPaymentMapper());
            }

            return debtPayment;
        }












    }


    
}
