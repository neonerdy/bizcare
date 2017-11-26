using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;
using System.Data;

namespace BizCare.Repository
{
    public interface ISupplierRepository
    {
        Supplier GetById(Guid id);
        Supplier GetByName(string name);
        Supplier GetLast();
        List<Supplier> GetAll();
        List<Supplier> Search(string value);
        void Save(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(Guid id);
        void PlusFirstBalance(Guid customerId, decimal amount);
        void MinusFirstBalance(Guid customerId, decimal amount);
        bool IsSupplierUsedByDebtBalance(Guid supplierId);
        bool IsSupplierNameExisted(string supplierName);
        List<Supplier> GetActiveSupplier();
        bool IsPlafonInsuficient(Guid supplierId);
    }


    public class SupplierRepository : ISupplierRepository
    {
        private string tableName = "Supplier";
        private DataSource ds;

        public SupplierRepository(DataSource ds)
        {
            this.ds = ds;
        }

        
        public Supplier GetById(Guid id)
        {
            Supplier supplier = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ID").Equal("{" + id + "}").OrderBy("SupplierName ASC");
                supplier = em.ExecuteObject<Supplier>(q.ToSql(), new SupplierMapper());
            }

            return supplier;
        }


        public Supplier GetByName(string name)
        {
            Supplier supplier = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("SupplierName").Equal(name).OrderBy("SupplierName ASC");
                supplier = em.ExecuteObject<Supplier>(q.ToSql(), new SupplierMapper());
            }

            return supplier;
        }

        

        public Supplier GetLast()
        {
            Supplier supplier = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().Select("TOP 1 *").From(tableName).OrderBy("SupplierName ASC");
             
                supplier = em.ExecuteObject<Supplier>(q.ToSql(), new SupplierMapper());
            }

            return supplier;
        }


        public List<Supplier> GetAll()
        {
            List<Supplier> suppliers = new List<Supplier>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).OrderBy("SupplierName ASC");
                suppliers = em.ExecuteList<Supplier>(q.ToSql(), new SupplierMapper());
            }

            return suppliers;
        }



        public List<Supplier> Search(string value)
        {
            List<Supplier> suppliers=new List<Supplier>();

            using(var em=EntityManagerFactory.CreateInstance(ds))
            {
                Query q = new Query().From(tableName).Where("IsActive=true").And("SupplierName")
                   .Like("%" + value + "%")
                   .Or("Address").Like("%" + value + "%")
                   .Or("Phone").Like("%" + value + "%")
                   .Or("Fax").Like("%" + value + "%")
                   .Or("Email").Like("%" + value + "%")
                   .Or("ContactPerson").Like("%" + value + "%")
                   .Or("Notes").Like("%" + value + "%")
                   .OrderBy("SupplierName ASC"); 
                
                suppliers = em.ExecuteList<Supplier>(q.ToSql(), new SupplierMapper());
            }

            return suppliers;
        }



        public void Save(Supplier supplier)
        {
            try
            {
                using(var em=EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = { "ID", "SupplierName", "Address", "Phone", "Fax", "Email", "ContactPerson", "Notes","IsActive","Plafon", "TermOfPayment",
                                        "FirstBalance","LastBalance","LastMonthPayment","ThisMonthPayment","CreatedDate", "ModifiedDate"};

                    object[] values = { Guid.NewGuid(), supplier.Name,supplier.Address,supplier.Phone,supplier.Fax,supplier.Email,supplier.ContactPerson,
                                        supplier.Notes,supplier.IsActive==true?1:0,supplier.Plafon, supplier.TermOfPayment, supplier.FirstBalance,supplier.LastBalance,
                                        supplier.LastMonthPayment,supplier.ThisMonthPayment,
                                        DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString()};


                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }        
        }


        
        public void Update(Supplier supplier)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] fields = { "SupplierName", "Address", "Phone", "Fax", "Email", "ContactPerson","Notes","IsActive",
                                        "Plafon", "TermOfPayment", "FirstBalance","ModifiedDate"};

                    object[] values = { supplier.Name,supplier.Address,supplier.Phone,supplier.Fax,supplier.Email,supplier.ContactPerson,
                                        supplier.Notes,supplier.IsActive==true?1:0,supplier.Plafon, supplier.TermOfPayment, supplier.FirstBalance,
                                        DateTime.Now.ToShortDateString()};

                    Query q = new Query().Select(fields).From(tableName).Update(values)
                        .Where("ID").Equal("{" + supplier.ID + "}");


                    em.ExecuteNonQuery(q.ToSql());

                }
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



        public void PlusFirstBalance(Guid supplierId, decimal amount)
        {
            decimal currentFirstBalance = 0;

            var supplier = GetById(supplierId);
            if (supplier != null)
            {
                currentFirstBalance = supplier.FirstBalance;
            }

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    string[] fields = { "FirstBalance" };

                    object[] values = { amount+currentFirstBalance };

                    Query q = new Query().Select(fields).From(tableName).Update(values)
                        .Where("ID").Equal("{" + supplierId + "}");

                    em.ExecuteNonQuery(q.ToSql());

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void MinusFirstBalance(Guid supplierId, decimal amount)
        {
            decimal currentFirstBalance = 0;

            var supplier = GetById(supplierId);
            if (supplier != null)
            {
                currentFirstBalance = supplier.FirstBalance;
            }

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    string[] fields = { "FirstBalance" };

                    object[] values = { currentFirstBalance - amount };

                    Query q = new Query().Select(fields).From(tableName).Update(values)
                        .Where("ID").Equal(supplierId);

                    em.ExecuteNonQuery(q.ToSql());

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public bool IsSupplierUsedByDebtBalance(Guid supplierId)
        {
            bool isUsed = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("DebtBalance")
                    .Where("SupplierId").Equal("{" + supplierId + "}");

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


        public bool IsSupplierNameExisted(string supplierName)
        {
            bool isExisted = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("Supplier").Where("SupplierName").Equal(supplierName);

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


        public List<Supplier> GetActiveSupplier()
        {
            List<Supplier> suppliers = new List<Supplier>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("IsActive=true").OrderBy("SupplierName ASC");
                suppliers = em.ExecuteList<Supplier>(q.ToSql(), new SupplierMapper());
            }

            return suppliers;
        }


        public bool IsPlafonInsuficient(Guid supplierId)
        {
            bool isInSuficient = false;
            decimal grandTotal = 0;
            decimal plafon = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Sum(Purchase.GrandTotal) AS GrandTotal "
                    + "FROM Purchase INNER JOIN Supplier ON Purchase.SupplierId = Supplier.ID "
                    + "WHERE Purchase.Status=False and Purchase.SupplierId='{" + supplierId + "}'";
                   

                using (var rdr = em.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        grandTotal = (decimal)rdr["GrandTotal"];
                    }
                }

                var supplier = GetById(supplierId);
                if (supplier != null) plafon = supplier.Plafon;

                if (plafon > 0 && grandTotal > plafon) isInSuficient = true;


            }

            return isInSuficient;

        }



    

    

      
    }
}
