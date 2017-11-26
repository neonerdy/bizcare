using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;


namespace BizCare.Repository
{
    public interface IPayablePaymentRepository
    {
        string GeneratePayablePaymentCode(int month, int year);
        PayablePayment GetById(Guid id);
        PayablePayment GetByCode(string code);
        List<string> GetAllCode(int month, int year);
        int GetPayablePaymentIdByCode(string code);
        List<PayablePayment> GetAll(int month, int year);
        List<PayablePayment> GetAll();
        PayablePayment GetLast(int month, int year);
        void Save(PayablePayment payablePayment);
        void Update(PayablePayment payablePayment);
        void Delete(string code);
        void Delete(Guid id);
        void Delete(PayablePayment payablePayment);
        List<PayablePayment> Search(string value, int month, int year);
       

    }

    public class PayablePaymentRepository : IPayablePaymentRepository
    {
        private DataSource ds;
        private string tableName = "PayablePayment";

        private IPayablePaymentItemRepository payablePaymentItemRepository;
        private IRecordCounterRepository recordCounterRepository;
        private ISalesRepository salesRepository;
        private IPayableBalanceRepository payableBalanceRepository;

        public PayablePaymentRepository(DataSource ds)
        {
            this.ds = ds;
            payablePaymentItemRepository = ServiceLocator.GetObject<IPayablePaymentItemRepository>();
            recordCounterRepository = ServiceLocator.GetObject<IRecordCounterRepository>();
            salesRepository = ServiceLocator.GetObject<ISalesRepository>();
            payableBalanceRepository = ServiceLocator.GetObject<IPayableBalanceRepository>();
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

        public string GeneratePayablePaymentCode(int month, int year)
        {

            string strYear = year.ToString().Substring(2);

            string code = "PP-" + strYear + GetMonthCode(month);

            int counter = 0;
            int newCounter = 0;

            var recordCounter = recordCounterRepository.GetByMonthAndYear(month, year);
            if (recordCounter != null)
                counter = recordCounter.PayablePaymentCounter;

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

        public PayablePayment GetById(Guid id)
        {
            PayablePayment payablePayment = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT p.ID, p.PaymentCode, p.PaymentDate, " 
                           + "p.TotalCash, p.TotalBank, p.TotalGiro, p.TotalCorrection, p.GrandTotal, p.Notes, "
                        + "p.CreatedDate,p.ModifiedDate, p.CreatedBy, p.ModifiedBy "
                           + "FROM PayablePayment p "
                           + "WHERE "
                           + "p.ID='{" + id + "}'";

                payablePayment = em.ExecuteObject<PayablePayment>(sql, new PayablePaymentMapper());

                if (payablePayment != null)
                {
                    payablePayment.PayablePaymentItems = payablePaymentItemRepository.GetByPayablePaymentId(payablePayment.ID);
                }
            }

            return payablePayment;
        }


        public int GetPayablePaymentIdByCode(string code)
        {

            int payablePaymentId = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("PaymentCode").Equal(code);

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    if (rdr.Read())
                    {
                        payablePaymentId = (int)rdr["ID"];
                    }
                }
            }

            return payablePaymentId;
        }


        public PayablePayment GetByCode(string code)
        {
            PayablePayment payablePayment = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT ID, PaymentCode, PaymentDate, "
                        + "TotalCash, TotalBank, TotalGiro, TotalCorrection, GrandTotal, Notes, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                        + "FROM PayablePayment "
                        + "WHERE PaymentCode='" + code + "'";


                payablePayment = em.ExecuteObject<PayablePayment>(sql, new PayablePaymentMapper());
            }

            return payablePayment;
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

        public List<PayablePayment> GetAll(int month, int year)
        {
            List<PayablePayment> payablePayment = new List<PayablePayment>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT ID, PaymentCode, PaymentDate, "
                        + "TotalCash, TotalBank, TotalGiro, TotalCorrection, GrandTotal, Notes, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                + "FROM PayablePayment "
                + "WHERE Month(PaymentDate)=" + month + " AND Year(PaymentDate)=" + year + " "
                + "ORDER BY PaymentCode DESC";

                payablePayment = em.ExecuteList<PayablePayment>(sql, new PayablePaymentMapper());
            }

            return payablePayment;
        }


        public List<PayablePayment> GetAll()
        {
            List<PayablePayment> payablePayment = new List<PayablePayment>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT ID, PaymentCode, PaymentDate, "
                        + "TotalCash, TotalBank, TotalGiro, TotalCorrection, GrandTotal, Notes, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                        + "FROM PayablePayment " 
                        + "ORDER BY PaymentCode DESC";

                payablePayment = em.ExecuteList<PayablePayment>(sql, new PayablePaymentMapper());
            }

            return payablePayment;
        }

        public PayablePayment GetLast(int month, int year)
        {
            PayablePayment payablePayment = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT TOP 1 ID, PaymentCode, PaymentDate, "
                        + "TotalCash, TotalBank, TotalGiro, TotalCorrection, GrandTotal, Notes, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                + "FROM PayablePayment "
                + "WHERE Month(PaymentDate)=" + month + " AND Year(PaymentDate)=" + year
                + " ORDER BY PayablePayment.PaymentCode DESC";

                payablePayment = em.ExecuteObject<PayablePayment>(sql, new PayablePaymentMapper());
            }

            return payablePayment;
        }

        
        public void Save(PayablePayment payablePayment)
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

                    object[] values = { ID, payablePayment.PaymentCode, payablePayment.PaymentDate.ToShortDateString(),payablePayment.TotalCash,
                                          payablePayment.TotalBank, payablePayment.TotalGiro, payablePayment.TotalCorrection,
                                          payablePayment.GrandTotal, payablePayment.Notes,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    foreach (var payablePaymentItems in payablePayment.PayablePaymentItems)
                    {
                        payablePaymentItems.PayablePaymentId = ID;

                        payablePaymentItemRepository.Save(em, tx, payablePaymentItems);

                        //update status = lunas
                        salesRepository.UpdateStatus(em, tx, payablePaymentItems.SalesId, true);
                        
                        //update status = lunas
                        payableBalanceRepository.UpdateStatusFromPayment(em, tx, payablePaymentItems.Sales.Code, true);
                    }

                    recordCounterRepository.UpdatePayablePaymentCounter(payablePayment.PaymentDate.Month, payablePayment.PaymentDate.Year);

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }


        private void UpdateGrandTotal(IEntityManager em, Transaction tx, Guid payablePaymentId, decimal total)
        {

            string[] columns = { "GrandTotal" };
            object[] values = { total };

            var q = new Query().Select(columns).From(tableName).Update(values)
                .Where("ID").Equal("{" + payablePaymentId + "}");

            em.ExecuteNonQuery(q.ToSql(), tx);
        }

        public void Update(PayablePayment payablePayment)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    string[] columns = { "PaymentCode", "PaymentDate", "TotalCash", "TotalBank", "TotalGiro", "TotalCorrection", "Notes",
                                         "ModifiedDate","ModifiedBy"};

                    object[] values = { payablePayment.PaymentCode, payablePayment.PaymentDate, payablePayment.TotalCash,payablePayment.TotalBank,
                                          payablePayment.TotalGiro, payablePayment.TotalCorrection, payablePayment.Notes,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + payablePayment.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);


                    ////detail dihapus -> update status = false
                    var list = payablePaymentItemRepository.GetByPayablePaymentId(payablePayment.ID);
                    foreach (var payableItem in list)
                    {
                        salesRepository.UpdateStatus(em, tx, payableItem.SalesId, false);
                        payableBalanceRepository.UpdateStatusFromPayment(em, tx, payableItem.Sales.Code, false);
                    }

                    payablePaymentItemRepository.Delete(em, tx, payablePayment.ID);

                    
                  
                    foreach (var payablePaymentItem in payablePayment.PayablePaymentItems)
                    {
                        payablePaymentItem.PayablePaymentId = payablePayment.ID;

                        payablePaymentItemRepository.Save(em, tx, payablePaymentItem);

                        //update status = lunas
                        salesRepository.UpdateStatus(em, tx, payablePaymentItem.SalesId, true);

                        //update status = lunas
                        payableBalanceRepository.UpdateStatusFromPayment(em, tx, payablePaymentItem.Sales.Code, true);
                    }

                    UpdateGrandTotal(em, tx, payablePayment.ID, payablePayment.GrandTotal);

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

        public void Delete(PayablePayment payablePayment)
        {
            Transaction tx = null;
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    String notes = "";
                    if (payablePayment.Notes != "")
                    {
                        notes = "DIBATALKAN - " + payablePayment.Notes;
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
                        .Where("ID").Equal(payablePayment.ID);

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    var itemList = payablePaymentItemRepository.GetByPayablePaymentId(payablePayment.ID);
                    foreach (var payablePaymentItem in itemList)
                    {
                        payablePaymentItemRepository.Delete(em, tx, payablePaymentItem);
                    }

                    foreach (var item in itemList)
                    {
                        //update status = lunas
                        salesRepository.UpdateStatus(em, tx, item.SalesId, false);

                        //update status = lunas
                        payableBalanceRepository.UpdateStatusFromPayment(em, tx, item.Sales.Code, false);
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

        public List<PayablePayment> Search(string value, int month, int year)
        {
            List<PayablePayment> payablePayment = new List<PayablePayment>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {

                string sql = "SELECT p.ID, p.PaymentCode, p.PaymentDate, "
                        + "p.TotalCash, p.TotalBank, p.TotalGiro, p.TotalCorrection, p.GrandTotal, p.Notes, "
                        + "p.CreatedDate,p.ModifiedDate, p.CreatedBy, p.ModifiedBy "
                        + "FROM PayablePayment p "
                        + "WHERE "
                        + "(p.PaymentCode like '%" + value + "%' "
                        + "OR p.Notes like  '%" + value + "%') "
                        + "AND Month(p.PaymentDate)=" + month + " AND Year(p.PaymentDate)=" + year
                        + " ORDER BY p.PaymentCode DESC";


                payablePayment = em.ExecuteList<PayablePayment>(sql, new PayablePaymentMapper());
            }

            return payablePayment;
        }











    }

}
