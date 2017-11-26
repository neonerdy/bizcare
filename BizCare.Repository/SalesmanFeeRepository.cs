using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;


namespace BizCare.Repository
{
    public interface ISalesmanFeeRepository
    {
        SalesmanFee GetById(Guid id);
        SalesmanFee GetLast(Guid salesmanId);
        List<SalesmanFee> GetAll(Guid salesmanId);
        List<SalesmanFee> GetAll(int month, int year);
        List<SalesmanFee> Search(string value);
        void Save(SalesmanFee salesmanFee);
        void Update(SalesmanFee salesmanFee);
        void Delete(Guid id);
        SalesmanFee GetByMonthAndYear(int month, int year,Guid salesmanId);
        List<SalesmanFee> GetByActivePeriod(int month, int year);
        bool IsSalesmanFeeExisted(int month, int year, Guid salesmanId);
        void GenerateCommision(int month, int year);
    }


    public class SalesmanFeeRepository : ISalesmanFeeRepository
    {
        private string tableName = "SalesmanFee";
        private DataSource ds;

        private ISalesmanRepository salesmanRepository;
        private IPayablePaymentItemRepository payablePaymentItemRepository;

        public SalesmanFeeRepository(DataSource ds)
        {
            this.ds = ds;
            salesmanRepository = ServiceLocator.GetObject<ISalesmanRepository>();
            payablePaymentItemRepository = ServiceLocator.GetObject<IPayablePaymentItemRepository>();
            
        }


        public SalesmanFee GetById(Guid id)
        {
            SalesmanFee salesmanFee = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT sf.ID, sf.ActiveMonth, sf.ActiveYear, sf.FeePercentage, "
                        + "sf.SalesmanId, s.SalesmanName, "
                        + "sf.CreatedDate, sf.ModifiedDate "
                        + "FROM SalesmanFee sf INNER JOIN Salesman s ON sf.SalesmanId = s.ID "
                        + "WHERE " + "sf.ID ='{" + id + "}'";

                salesmanFee = em.ExecuteObject<SalesmanFee>(sql, new SalesmanFeeMapper());
            }

            return salesmanFee;
        }


        public SalesmanFee GetLast(Guid salesmanId)
        {
            SalesmanFee salesmanFee = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT TOP 1 sf.ID, sf.ActiveMonth, sf.ActiveYear, sf.FeePercentage, "
                        + "sf.SalesmanId, s.SalesmanName, "
                        + "sf.CreatedDate, sf.ModifiedDate "
                        + "FROM SalesmanFee sf INNER JOIN Salesman s ON sf.SalesmanId = s.ID "
                        + "WHERE " + "sf.SalesmanId ={" + salesmanId + "}";
               
                salesmanFee = em.ExecuteObject<SalesmanFee>(sql, new SalesmanFeeMapper());
            }

            return salesmanFee;
        }


        public List<SalesmanFee> GetAll(Guid salesmanId)
        {
            List<SalesmanFee> salesmanFee = new List<SalesmanFee>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT sf.ID, sf.ActiveMonth, sf.ActiveYear, sf.FeePercentage, "
                        + "sf.SalesmanId, s.SalesmanName, "
                        + "sf.CreatedDate, sf.ModifiedDate "
                        + "FROM SalesmanFee sf INNER JOIN Salesman s ON sf.SalesmanId = s.ID "
                        + "WHERE sf.SalesmanId ={" + salesmanId + "} "
                        + "ORDER BY sf.CreatedDate DESC";

                salesmanFee = em.ExecuteList<SalesmanFee>(sql, new SalesmanFeeMapper());
            }

            return salesmanFee;

        }

        public List<SalesmanFee> GetAll(int month, int year)
        {
            List<SalesmanFee> salesmanFee = new List<SalesmanFee>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT sf.ID, sf.ActiveMonth, sf.ActiveYear, sf.FeePercentage, "
                        + "sf.SalesmanId, s.SalesmanName, "
                        + "sf.CreatedDate, sf.ModifiedDate "
                        + "FROM SalesmanFee sf INNER JOIN Salesman s ON sf.SalesmanId = s.ID "
                        + "WHERE sf.ActiveMonth=" + month + " AND sf.ActiveYear = " + year + " "
                        + "ORDER BY sf.CreatedDate DESC";

                salesmanFee = em.ExecuteList<SalesmanFee>(sql, new SalesmanFeeMapper());
            }

            return salesmanFee;

        }

        public List<SalesmanFee> Search(string value)
        {
            List<SalesmanFee> salesmanFee = new List<SalesmanFee>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT sf.ID, sf.ActiveMonth, sf.ActiveYear, sf.FeePercentage, "
                        + "sf.SalesmanId, s.SalesmanName, "
                        + "sf.CreatedDate, sf.ModifiedDate "
                        + "FROM SalesmanFee sf INNER JOIN Salesman s ON db.SalesmanId = s.ID "
                        + "WHERE "
                        + "s.SalesmanName like '%" + value + "%'  "
                        + "ORDER BY db.ActiveYear DESC, sf.ActiveMonth ASC"; 
                
                salesmanFee = em.ExecuteList<SalesmanFee>(sql, new SalesmanFeeMapper());


            }

            return salesmanFee;
        }


        public void Save(SalesmanFee salesmanFee)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    string[] columns = {"ID", "ActiveMonth", "ActiveYear", "FeePercentage", "SalesmanId", 
                                        "CreatedDate", "ModifiedDate"};

                    object[] values = {Guid.NewGuid(),salesmanFee.ActiveMonth, salesmanFee.ActiveYear, 
                                      salesmanFee.FeePercentage, salesmanFee.SalesmanId, 
                                      DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString() };

                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql());

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(SalesmanFee salesmanFee)
        {
            try
            {

                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = {"ActiveYear", "ActiveMonth", "FeePercentage", "SalesmanId", "ModifiedDate"};

                    object[] values = {salesmanFee.ActiveYear, salesmanFee.ActiveMonth, salesmanFee.FeePercentage, 
                                       salesmanFee.SalesmanId, DateTime.Now.ToShortDateString()};

                    var q = new Query().Select(columns).From(tableName).Update(values).Where("ID").Equal("{" + salesmanFee.ID + "}");

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

        public SalesmanFee GetByMonthAndYear(int month, int year,Guid id)
        {
            SalesmanFee salesmanFee = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ActiveMonth").Equal(month)
                    .And("ActiveYear").Equal(year).And("SalesmanId").Equal(id)
                    .OrderBy("ActiveYear DESC, ActiveMonth ASC ");

                salesmanFee = em.ExecuteObject<SalesmanFee>(q.ToSql(), new SalesmanFeeMapper());
            }

            return salesmanFee;
        }

        public bool IsSalesmanFeeExisted(int month, int year, Guid salesmanId)
        {
            bool isExisted = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("SalesmanFee").Where("ActiveYear").Equal(year)
                    .And("ActiveMonth").Equal(month)
                    .And("SalesmanId").Equal(salesmanId);

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

        public List<SalesmanFee> GetByActivePeriod(int month, int year)
        
        {
            List<SalesmanFee> salesmanFee = new List<SalesmanFee>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var sql = "SELECT sf.ID, sf.ActiveMonth, sf.ActiveYear, sf.FeePercentage, "
                        + "sf.SalesmanId, s.SalesmanName, "
                        + "sf.CreatedDate, sf.ModifiedDate "
                        + "FROM SalesmanFee sf INNER JOIN Salesman s ON sf.SalesmanId = s.ID "
                        + "WHERE sf.ActiveMonth=" + month + " AND sf.ActiveYear=" + year
                        + " ORDER BY sf.CreatedDate DESC";

                salesmanFee = em.ExecuteList<SalesmanFee>(sql, new SalesmanFeeMapper());
            }

            return salesmanFee;

        }


        public bool IsSalesmanComissionExist(int month,int year,Guid salesmanId)
        {
            bool isExist=false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("SalesmanCommision").Where("ActiveMonth").Equal(month)
                    .And("ActiveYear").Equal(year).And("SalesmanId").Equal(salesmanId);
                
                using(var rdr=em.ExecuteReader(q.ToSql()))
                {
                    if (rdr.Read())
                    {
                        isExist=true;
                    }
                }
            }

            return isExist;

        }
            


        public void GenerateCommision(int month, int year)
        {
            if (!Store.IsPeriodClosed)
            {


                var salesmanFee = GetAll(month, year);

                Guid salesmanId = Guid.Empty;
                Guid salesmanFeeId = Guid.Empty;
                string salesmanName = "";
                int feePercentage = 0;
                decimal payablePaymentValue = 0;
                decimal commisionValue = 0;

                foreach (var s in salesmanFee)
                {

                    salesmanId = s.SalesmanId;
                    salesmanFeeId = s.ID;
                    salesmanName = s.Salesman.Name;
                    feePercentage = s.FeePercentage;
                    payablePaymentValue = 0;
                    commisionValue = 0;

                    var payablePaymentItem = payablePaymentItemRepository.GetBySalesman(month, year, salesmanId);
                    foreach (var p in payablePaymentItem)
                    {
                        payablePaymentValue = payablePaymentValue + p.Total;
                    }

                    commisionValue = (Convert.ToDecimal(feePercentage) / 100) * payablePaymentValue;

                    if (commisionValue > 0)
                    {
                        if (!IsSalesmanComissionExist(month, year, salesmanId))
                        {
                            using (var em = EntityManagerFactory.CreateInstance(ds))
                            {
                                string[] columns = { "ID", "ActiveMonth", "ActiveYear", 
                                   "SalesmanId", "SalesmanName", "FeePercentage",
                                   "PayablePaymentValue", "CommisionValue"};

                                object[] values = { Guid.NewGuid(),month,year,
                                              salesmanId, salesmanName, feePercentage, 
                                              payablePaymentValue, commisionValue };

                                var q = new Query().Select(columns).From("SalesmanCommision").Insert(values);

                                em.ExecuteNonQuery(q.ToSql());
                            }
                        }
                        else
                        {
                            using (var em = EntityManagerFactory.CreateInstance(ds))
                            {
                                string[] columns = {"SalesmanName", "FeePercentage",
                                   "PayablePaymentValue", "CommisionValue"};

                                object[] values = { salesmanName, feePercentage, 
                                              payablePaymentValue, commisionValue };

                                var q = new Query().Select(columns).From("SalesmanCommision").Update(values).Where("SalesmanId").Equal("{" + salesmanId + "}");

                                em.ExecuteNonQuery(q.ToSql());
                            }
                        }
                    }

                }


            }
            

        }





    }
}
