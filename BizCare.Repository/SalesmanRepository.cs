using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;


namespace BizCare.Repository
{
    public interface ISalesmanRepository
    {
        Salesman GetById(Guid id);
        Salesman GetByName(string name);
        Salesman GetLast();
        List<Salesman> GetAll();
        List<Salesman> Search(string value);
        void Save(Salesman salesman);
        void Update(Salesman salesman);
        void Delete(Guid id);
        bool IsSalesmanUsedBySales(Guid salesmanId);
        bool IsSalesmanUsedByPayableBalance(Guid salesmanId);
        bool IsSalesmanNameExisted(string salesmanName);
        bool IsSalesmanUsedBySalesmanFee(Guid salesmanId);
        List<Salesman> GetActiveSalesman();
    }


    public class SalesmanRepository : ISalesmanRepository
    {
        private string tableName = "Salesman";
        private DataSource ds;

        public SalesmanRepository(DataSource ds)
        {
            this.ds = ds;
        }



        public Salesman GetById(Guid id)
        {
            Salesman salesman = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ID").Equal("{" + id + "}").OrderBy("SalesmanName ASC");
                salesman = em.ExecuteObject<Salesman>(q.ToSql(), new SalesmanMapper());
            }

            return salesman;
        }

        public Salesman GetByName(string name)
        {
            Salesman salesman = new Salesman();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("SalesmanName").Equal(name).OrderBy("SalesmanName ASC");
                salesman = em.ExecuteObject<Salesman>(q.ToSql(), new SalesmanMapper());
            }

            return salesman;

        }

        public Salesman GetLast()
        {
            Salesman salesman = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().Select("TOP 1 *").From(tableName).OrderBy("SalesmanName ASC");
                salesman = em.ExecuteObject<Salesman>(q.ToSql(), new SalesmanMapper());
            }

            return salesman;
        }

        public List<Salesman> GetAll()
        {
            List<Salesman> salesmen = new List<Salesman>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).OrderBy("SalesmanName ASC");
                salesmen = em.ExecuteList<Salesman>(q.ToSql(), new SalesmanMapper());

            }

            return salesmen;

        }

        public List<Salesman> Search(string value)
        {
            List<Salesman> salesmen = new List<Salesman>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("IsActive=true").And("SalesmanName")
                    .Like("%" + value + "%")
                    .Or("Phone1").Like("%" + value + "%")
                    .Or("Phone2").Like("%" + value + "%")
                    .Or("Address").Like("%" + value + "%")
                    .Or("Notes").Like("%" + value + "%")
                    .OrderBy("SalesmanName ASC");

                salesmen = em.ExecuteList<Salesman>(q.ToSql(), new SalesmanMapper());

            }

            return salesmen;
        }

        public void Save(Salesman salesman)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = { "ID", "SalesmanName", "Address", "Phone1", "Phone2", "Notes", 
                                         "IsActive", "CreatedDate", "ModifiedDate"};

                    object[] values = { Guid.NewGuid(), salesman.Name, salesman.Address, salesman.Phone1, salesman.Phone2, salesman.Notes, 
                                      salesman.IsActive==true?1:0, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString() };

                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql());
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public void Update(Salesman salesman)
        {
            try
            {

                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = {"SalesmanName", "Address", "Phone1", "Phone2", "Notes", 
                                        "IsActive","ModifiedDate"};

                    object[] values = {salesman.Name, salesman.Address, 
                                      salesman.Phone1, salesman.Phone2, salesman.Notes, 
                                      salesman.IsActive==true?1:0,
                                      DateTime.Now.ToShortDateString()};

                    var q = new Query().Select(columns).From(tableName).Update(values).Where("ID").Equal("{" + salesman.ID + "}");

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


        public bool IsSalesmanUsedBySales(Guid salesmanId)
        {
            bool isUsed = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("Sales").Where("SalesmanId").Equal("{" + salesmanId + "}");

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

        public bool IsSalesmanUsedByPayableBalance(Guid salesmanId)
        {
            bool isUsed = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("PayableBalance").Where("SalesmanId").Equal("{" + salesmanId + "}");

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

        public bool IsSalesmanNameExisted(string salesmanName)
        {
            bool isExisted = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("Salesman").Where("SalesmanName").Equal(salesmanName);

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

        public bool IsSalesmanUsedBySalesmanFee(Guid salesmanId)
        {
            bool isUsed = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("SalesmanFee").Where("SalesmanId").Equal("{" + salesmanId + "}");

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

        public List<Salesman> GetActiveSalesman()
        {
            List<Salesman> salesmans = new List<Salesman>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("IsActive=true").OrderBy("SalesmanName ASC");
                salesmans = em.ExecuteList<Salesman>(q.ToSql(), new SalesmanMapper());
            }

            return salesmans;
        }



    }
}
