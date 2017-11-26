
using System;
using System.Collections.Generic;
using BizCare.Model;

using System.Data;
using BizCare.Repository.Mapping;
using EntityMap;
using System.Data.OleDb;
using System.Configuration;


namespace BizCare.Repository
{
    public interface ICustomerRepository
    {
        Customer GetById(Guid id);
        Customer GetLast();
        Customer GetByName(string name);
        List<Customer> GetAll();
        List<Customer> Search(string value);
        void Save(Customer customer);
        void Update(Customer customer);
        void Delete(Guid id);
        void PlusFirstBalance(Guid customerId, decimal amount);
        void MinusFirstBalance(Guid customerId, decimal amount);
        bool IsCustomerUsedBySales(Guid customerId);
        bool IsCustomerUsedByPayableBalance(Guid customerId);
        bool IsCustomerNameExisted(string customerName);
        List<Customer> GetActiveCustomer();
        bool IsPlafonInsuficient(Guid customerId);

    }
       
    public class CustomerRepository : ICustomerRepository
    {
        private string tableName = "Customer";
        private DataSource ds;

        public CustomerRepository(DataSource ds) 
        {
            this.ds = ds;
        }


        public bool IsCustomerUsedBySales(Guid customerId)
        {
            bool isUsed = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("Sales").Where("CustomerId").Equal("{" + customerId + "}");

                using(var rdr=em.ExecuteReader(q.ToSql()))
                {
                    if (rdr.Read())
                    {
                        isUsed = true;
                    }
                }

            }

            return isUsed;

        }

        public bool IsCustomerUsedByPayableBalance(Guid customerId)
        {
            bool isUsed = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("PayableBalance").Where("CustomerId").Equal("{" + customerId + "}");

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

        public Customer GetById(Guid id)
        {
            Customer customer = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ID").Equal("{" + id + "}").OrderBy("CustomerName ASC");
                customer = em.ExecuteObject<Customer>(q.ToSql(), new CustomerMapper());
            }

            return customer;
        }


        public Customer GetLast()
        {
            Customer customer = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().Select("TOP 1 *").From(tableName).OrderBy("CustomerName ASC");

                customer=em.ExecuteObject<Customer>(q.ToSql(), new CustomerMapper());
            }

            return customer;
        }


        public Customer GetByName(string name)
        {
            Customer customer = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("CustomerName").Equal(name).OrderBy("CustomerName ASC");
                customer = em.ExecuteObject<Customer>(q.ToSql(), new CustomerMapper());
            }

            return customer;
        }
        

        public List<Customer> GetAll()
        {           
            List<Customer> customers = new List<Customer>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).OrderBy("CustomerName ASC");
                customers=em.ExecuteList<Customer>(q.ToSql(), new CustomerMapper());
            }
            
            return customers;
        }
        



        public List<Customer> Search(string value)
        {
            List<Customer> customers = new List<Customer>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                Query q = new Query().From(tableName).Where("CustomerName").Like("%" + value + "%")
                    .Or("Address").Like("%" + value + "%")
                    .Or("Phone").Like("%" + value + "%")
                    .Or("Fax").Like("%" + value + "%")
                    .Or("Email").Like("%" + value + "%")
                    .Or("ContactPerson").Like("%" + value + "%")
                    .Or("Notes").Like("%" + value + "%")
                    .OrderBy("CustomerName ASC");

                customers = em.ExecuteList<Customer>(q.ToSql(), new CustomerMapper());
            }

            return customers;
        }




        public void Save(Customer customer)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] fields = { "ID", "CustomerName", "Address", "Phone", "Fax", "Email", "ContactPerson", "Notes","IsActive","Plafon", "TermOfPayment",
                                        "FirstBalance","LastBalance","LastMonthPayment","ThisMonthPayment","CreatedDate", "ModifiedDate"};

                    object[] values = { Guid.NewGuid(), customer.Name,customer.Address,customer.Phone,customer.Fax,customer.Email,customer.ContactPerson,
                                        customer.Notes,customer.IsActive==true?1:0,customer.Plafon, customer.TermOfPayment, customer.FirstBalance,customer.LastBalance,
                                        customer.LastMonthPayment,customer.ThisMonthPayment,DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString()};

                    Query q=new Query().Select(fields).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void Update(Customer customer)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    string[] fields = { "CustomerName", "Address", "Phone", "Fax", "Email", "ContactPerson","Notes","IsActive",
                                        "Plafon", "TermOfPayment", "FirstBalance","ModifiedDate"};
                    
                    object[] values = { customer.Name,customer.Address,customer.Phone,customer.Fax,customer.Email,customer.ContactPerson,
                                        customer.Notes,customer.IsActive==true?1:0,customer.Plafon, customer.TermOfPayment, customer.FirstBalance,DateTime.Now.ToShortDateString()};

                    Query q = new Query().Select(fields).From(tableName).Update(values)
                        .Where("ID").Equal("{" + customer.ID + "}");

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
                    Query q = new Query().From(tableName).Delete().Where("ID").Equal("{" + id + "}");
                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void PlusFirstBalance(Guid customerId, decimal amount)
        {
            decimal currentFirstBalance = 0;

            var customer = GetById(customerId);
            if (customer != null)
            {
                currentFirstBalance = customer.FirstBalance;
            }

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    string[] fields = { "FirstBalance" };

                    object[] values = { amount + currentFirstBalance };

                    Query q = new Query().Select(fields).From(tableName).Update(values)
                        .Where("ID").Equal(customerId);

                    em.ExecuteNonQuery(q.ToSql());

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void MinusFirstBalance(Guid customerId, decimal amount)
        {
            decimal currentFirstBalance = 0;

            var customer = GetById(customerId);
            if (customer != null)
            {
                currentFirstBalance = customer.FirstBalance;
            }

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    string[] fields = { "FirstBalance" };

                    object[] values = { currentFirstBalance - amount };

                    Query q = new Query().Select(fields).From(tableName).Update(values)
                        .Where("ID").Equal(customerId);

                    em.ExecuteNonQuery(q.ToSql());

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public bool IsCustomerNameExisted(string customerName)
        {
            bool isExisted = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("Customer").Where("CustomerName").Equal(customerName);

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

        public List<Customer> GetActiveCustomer()
        {
            List<Customer> customers = new List<Customer>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("IsActive=true").OrderBy("CustomerName Asc");
                customers = em.ExecuteList<Customer>(q.ToSql(), new CustomerMapper());
            }

            return customers;
        }


        public bool IsPlafonInsuficient(Guid customerId)
        {
            bool isInSuficient = false;
            decimal grandTotal = 0;
            decimal plafon = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Sum(Sales.GrandTotal) AS GrandTotal "
                    + "FROM Sales INNER JOIN Customer ON Sales.CustomerId = Customer.ID "
                    + "WHERE Sales.Status=False and Sales.CustomerId='{" + customerId + "}'";

                using (var rdr = em.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        grandTotal = (decimal)rdr["GrandTotal"];
                    }
                }

                var customer = GetById(customerId);
                if (customer != null) plafon = customer.Plafon;

                if (plafon > 0 && grandTotal > plafon) isInSuficient = true;
                

            }
               
            return isInSuficient;

        }










    }
}
