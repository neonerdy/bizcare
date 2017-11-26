using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;
namespace BizCare.Repository
{
    public interface ISalesRepository
    {
        string GenerateSalesCode(int month, int year);
        Sales GetById(Guid id);
        Sales GetByCode(string code);
        List<string> GetAllCode(int month, int year);
        int GetSalesIdByCode(string code);
        List<Sales> GetAll();
        List<Sales> GetAll(int month, int year);
        Sales GetLast(int month, int year);
        List<Sales> GetByStatusFalse();
        void SaveHeader(IEntityManager em, Transaction tx, Sales sales);
        void Save(IEntityManager em, Transaction tx, Sales sales);
        void Save(Sales sales);
        void UpdateHeader(IEntityManager em, Transaction tx, Sales sales);
        void Update(Sales sales);
        void UpdateStatus(IEntityManager em, Transaction tx, Guid id, bool paid);
        void Delete(string code);
        void Delete(Guid id);
        void Delete(IEntityManager em, Transaction tx, string salesCode);
        void Delete(Sales sales);
        bool IsSalesUsedByPayment(Guid salesId);
        bool IsSalesUsedByBillReceipt(Guid salesId);
        List<Sales> Search(string value);
        List<Sales> Search(string value, int month, int year);
        List<Sales> SearchStatusFalse(string value);
        void UpdatePrintCounter(string salesCode);
    }

    public class SalesRepository : ISalesRepository
    {

        private DataSource ds;
        private string tableName = "Sales";

        private ISalesItemRepository salesItemRepository;
        private IRecordCounterRepository recordCounterRepository;
        private IProductQtyRepository productQtyRepository;

        public SalesRepository(DataSource ds)
        {
            this.ds = ds;
            salesItemRepository = ServiceLocator.GetObject<ISalesItemRepository>();
            recordCounterRepository = ServiceLocator.GetObject<IRecordCounterRepository>();
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();
        }



        private string GetMonthCode(int month)
        {
            string monthCode = string.Empty;

            switch (month)
            {
                case 1 :
                    monthCode = "A";
                    break;
                case 2 :
                    monthCode = "B";
                    break;
                case 3 :
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
        

       

        public string GenerateSalesCode(int month,int year)
        {

            string strYear = year.ToString().Substring(2);

            string code = "INV-" + strYear + GetMonthCode(month) ;

            int counter = 0;
            int newCounter = 0;

            var recordCounter = recordCounterRepository.GetByMonthAndYear(month,year);
            if (recordCounter != null)
                counter = recordCounter.SalesCounter;

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

        


        public Sales GetById(Guid id)
        {
            Sales sales = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT s.ID, s.SalesCode, s.SalesDate, s.CustomerId, c.CustomerName, c.Address,"
                        + "s.SalesmanId, sl.SalesmanName,s.PaymentMethod, s.Status, s.Notes, s.GrandTotal, "
                        + "s.CreatedDate, s.ModifiedDate, s.CreatedBy, s.ModifiedBy, "
                        + "s.AmountInWords, s.DueDate, s.PrintCounter, s.TermOfPayment " 
                        + "FROM (Sales s INNER JOIN Customer c ON s.CustomerId = c.ID) "
                        + "INNER JOIN Salesman sl ON s.SalesmanId = sl.ID "
                        + "WHERE s.ID='{" + id + "}'";

                sales = em.ExecuteObject<Sales>(sql, new SalesMapper());

                if (sales != null)
                {
                    sales.SalesItems = salesItemRepository.GetBySalesId(sales.ID);
                }               
            }

            return sales;
        }


        public int GetSalesIdByCode(string code)
        {

            int salesId = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("SalesCode").Equal(code);

                using(var rdr=em.ExecuteReader(q.ToSql()))
                {
                    if (rdr.Read())
                    {
                        salesId = (int)rdr["ID"];
                    }
                }
            }

            return salesId;
        }



        public Sales GetByCode(string code)
        {
            Sales sales = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Sales.ID, Sales.SalesCode, Sales.SalesDate, Sales.CustomerId, Customer.CustomerName, Customer.Address, "
                        + "Sales.SalesmanId, Salesman.SalesmanName,Sales.PaymentMethod, Sales.Status, Sales.Notes, Sales.GrandTotal, "
                        + "Sales.CreatedDate, Sales.ModifiedDate, Sales.CreatedBy, Sales.ModifiedBy, "
                        + "Sales.AmountInWords, Sales.DueDate, Sales.PrintCounter, Sales.TermOfPayment " 
                        + "FROM (Sales INNER JOIN Customer ON Sales.CustomerId = Customer.ID) "
                        + "INNER JOIN Salesman ON Sales.SalesmanId = Salesman.ID "
                        + "WHERE "
                        + "Sales.SalesCode='" + code + "'"; 


                sales = em.ExecuteObject<Sales>(sql, new SalesMapper());
            }

            return sales;
        }



        public List<string> GetAllCode(int month,int year)
        {
            List<string> list = new List<string>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().Select("SalesCode").From(tableName)
                    .Where("Month(SalesDate)").Equal(month).And("Year(SalesDate)").Equal(year)
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


        public List<Sales> GetByStatusFalse()
        {
            List<Sales> sales = new List<Sales>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Sales.ID, Sales.SalesCode, Sales.SalesDate, Sales.CustomerId, Customer.CustomerName, Customer.Address, "
                        + "Sales.SalesmanId, Salesman.SalesmanName,Sales.PaymentMethod, Sales.Status, Sales.Notes,Sales.GrandTotal, "
                        + "Sales.CreatedDate, Sales.ModifiedDate, Sales.CreatedBy, Sales.ModifiedBy, "
                        + "Sales.AmountInWords, Sales.DueDate, Sales.PrintCounter, Sales.TermOfPayment " 
                        + "FROM (Sales INNER JOIN Customer ON Sales.CustomerId = Customer.ID) "
                        + "INNER JOIN Salesman ON Sales.SalesmanId = Salesman.ID "
                        + "WHERE Sales.Status=false "
                        + "ORDER BY Sales.SalesCode DESC";

                sales = em.ExecuteList<Sales>(sql, new SalesMapper());

                foreach(var s in sales)
                {
                    s.SalesItems=salesItemRepository.GetBySalesId(s.ID);
                }
            }

            return sales;
        }


        public List<Sales> GetAll(int month,int year)
        {
            List<Sales> sales = new List<Sales>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Sales.ID, Sales.SalesCode, Sales.SalesDate, Sales.CustomerId, Customer.CustomerName, Customer.Address, "
                        + "Sales.SalesmanId, Salesman.SalesmanName,Sales.PaymentMethod, Sales.Status, Sales.Notes,Sales.GrandTotal, "
                        + "Sales.CreatedDate, Sales.ModifiedDate, Sales.CreatedBy, Sales.ModifiedBy, "
                        + "Sales.AmountInWords, Sales.DueDate, Sales.PrintCounter, Sales.TermOfPayment " 
                        + "FROM (Sales INNER JOIN Customer ON Sales.CustomerId = Customer.ID) "
                        + "INNER JOIN Salesman ON Sales.SalesmanId = Salesman.ID "
                        + "WHERE Month(Sales.SalesDate)=" + month + " AND Year(Sales.SalesDate)=" + year + " "
                        + "ORDER BY Sales.SalesCode DESC";

                sales = em.ExecuteList<Sales>(sql, new SalesMapper());
            }

            return sales;
        }



        public List<Sales> GetAll()
        {
            List<Sales> sales = new List<Sales>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Sales.ID, Sales.SalesCode, Sales.SalesDate, Sales.CustomerId, Customer.CustomerName, Customer.Address, "
                        + "Sales.SalesmanId, Salesman.SalesmanName,Sales.PaymentMethod, Sales.Status, Sales.Notes,Sales.GrandTotal, "
                        + "Sales.CreatedDate, Sales.ModifiedDate, Sales.CreatedBy, Sales.ModifiedBy, "
                        + "Sales.AmountInWords, Sales.DueDate, Sales.PrintCounter, Sales.TermOfPayment " 
                        + "FROM (Sales INNER JOIN Customer ON Sales.CustomerId = Customer.ID) "
                        + "INNER JOIN Salesman ON Sales.SalesmanId = Salesman.ID "
                        + "ORDER BY Sales.SalesCode DESC";
                                               
                sales = em.ExecuteList<Sales>(sql, new SalesMapper());
            }

            return sales;
        }





        public Sales GetLast(int month,int year)
        {
            Sales sales = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT TOP 1 Sales.ID, Sales.SalesCode, Sales.SalesDate, Sales.CustomerId, Customer.CustomerName, Customer.Address, "
                        + "Sales.SalesmanId, Salesman.SalesmanName,Sales.PaymentMethod, Sales.Status, Sales.Notes, Sales.GrandTotal, "
                        + "Sales.CreatedDate, Sales.ModifiedDate, Sales.CreatedBy, Sales.ModifiedBy, "
                        + "Sales.AmountInWords, Sales.DueDate, Sales.PrintCounter, Sales.TermOfPayment " 
                        + "FROM (Sales INNER JOIN Customer ON Sales.CustomerId = Customer.ID) "
                        + "INNER JOIN Salesman ON Sales.SalesmanId = Salesman.ID "
                        + "WHERE Month(Sales.SalesDate)=" + month + " AND Year(Sales.SalesDate)=" + year
                        + " ORDER BY Sales.SalesCode DESC";

                sales = em.ExecuteObject<Sales>(sql, new SalesMapper());
            }            

            return sales;
        }


        public void SaveHeader(IEntityManager em, Transaction tx, Sales sales)
        {
            string[] columns = { "ID", "SalesCode", "SalesDate", "CustomerId", "SalesmanId", "PaymentMethod", "Status", "Notes","GrandTotal",
                                   "AmountInWords", "DueDate", "PrintCounter", "TermOfPayment", 
                                 "CreatedDate", "CreatedBy", "ModifiedDate", "ModifiedBy"};

            object[] values = { Guid.NewGuid(), sales.Code, sales.Date.ToShortDateString(),sales.CustomerId,sales.SalesmanId,sales.PaymentMethod,
                                sales.Status==true?1:0,sales.Notes,sales.GrandTotal,
                                sales.AmountInWords, sales.DueDate.ToShortDateString(), sales.PrintCounter, sales.TermOfPayment,
                                DateTime.Now.ToShortDateString(),
                                Store.ActiveUser,DateTime.Now.ToShortDateString(),Store.ActiveUser};

            var q = new Query().Select(columns).From(tableName).Insert(values);

            em.ExecuteNonQuery(q.ToSql(), tx);
        }




        public void Save(IEntityManager em, Transaction tx, Sales sales)
        {
            Guid ID = Guid.NewGuid();

            string[] columns = { "ID","SalesCode","SalesDate", "CustomerId", "SalesmanId", "PaymentMethod", "Status", "Notes","GrandTotal",
                                 "AmountInWords", "DueDate", "PrintCounter", "TermOfPayment",
                                 "CreatedDate","ModifiedDate","CreatedBy","ModifiedBy" };

            object[] values = { ID,sales.Code,sales.Date.ToShortDateString(),sales.CustomerId,sales.SalesmanId,sales.PaymentMethod,
                                sales.Status==true?1:0,sales.Notes,sales.GrandTotal,
                                sales.AmountInWords, sales.DueDate.ToShortDateString(), sales.PrintCounter, sales.TermOfPayment,
                                DateTime.Now.ToShortDateString(),DateTime.Now.ToShortDateString(),Store.ActiveUser,Store.ActiveUser};

            var q = new Query().Select(columns).From(tableName).Insert(values);

            em.ExecuteNonQuery(q.ToSql(), tx);

            foreach (var salesItem in sales.SalesItems)
            {
                salesItem.SalesId = ID;

                salesItemRepository.Save(em, tx, salesItem);
                productQtyRepository.UpdateQtyOut(Store.ActiveMonth, Store.ActiveYear, salesItem.ProductId, salesItem.Qty, true);
            }

            recordCounterRepository.UpdateSalesCounter(em, tx, sales.Date.Month, sales.Date.Year); 
        }


        

        public void Save(Sales sales)
        {
            Transaction tx=null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx=em.BeginTransaction();

                    //Guid ID = Guid.NewGuid();
                    
                    //string[] columns = { "ID","SalesCode","SalesDate", "CustomerId", "SalesmanId", "PaymentMethod", "Status", "Notes","GrandTotal",
                    //                    "AmountInWords", "DueDate", "PrintCounter", 
                    //                     "CreatedDate","ModifiedDate","CreatedBy","ModifiedBy" };

                    //object[] values = { ID,sales.Code,sales.Date.ToShortDateString(),sales.CustomerId,sales.SalesmanId,sales.PaymentMethod,
                    //                    sales.Status==true?1:0,sales.Notes,sales.GrandTotal,
                    //                    sales.AmountInWords, sales.DueDate.ToShortDateString(), sales.PrintCounter,
                    //                    DateTime.Now.ToShortDateString(),
                    //                    DateTime.Now.ToShortDateString(),Store.ActiveUser,Store.ActiveUser};

                    //var q = new Query().Select(columns).From(tableName).Insert(values);

                    //em.ExecuteNonQuery(q.ToSql(),tx);

                    //foreach (var salesItem in sales.SalesItems)
                    //{
                    //    salesItem.SalesId = ID;

                    //    salesItemRepository.Save(em, tx, salesItem);
                    //    productQtyRepository.UpdateQtyOut(Store.ActiveMonth, Store.ActiveYear, salesItem.ProductId, salesItem.Qty, true);
                    //}

                    //recordCounterRepository.UpdateSalesCounter(em,tx,sales.Date.Month, sales.Date.Year); 
                    

                    Save(em, tx, sales);
                    
                    tx.Commit();
                }              
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }



        private void UpdateGrandTotal(IEntityManager em,Transaction tx, Guid salesId,decimal total)
        {

            string[] columns = { "GrandTotal" };
            object[] values = { total };

            var q = new Query().Select(columns).From(tableName).Update(values)
                .Where("ID").Equal("{" + salesId + "}");

            em.ExecuteNonQuery(q.ToSql(),tx);
        }



        public void UpdateHeader(IEntityManager em, Transaction tx, Sales sales)
        {
            string[] columns = { "SalesDate", "CustomerId", "SalesmanId", "PaymentMethod", "Status", "Notes","GrandTotal",
                                "AmountInWords", "DueDate", "TermOfPayment", 
                                 "ModifiedDate","ModifiedBy"};

            object[] values = { sales.Date.ToShortDateString(),sales.CustomerId,sales.SalesmanId,sales.PaymentMethod,
                                sales.Status==true?1:0,sales.Notes,sales.GrandTotal,
                                sales.AmountInWords, sales.DueDate.ToShortDateString(), sales.TermOfPayment,
                                DateTime.Now.ToShortDateString(),Store.ActiveUser};

            var q = new Query().Select(columns).From(tableName).Update(values)
                .Where("SalesCode").Equal(sales.Code);

            em.ExecuteNonQuery(q.ToSql(), tx);
        }




        public void Update(Sales sales)
        {
            Transaction tx = null;
            
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    string[] columns = { "SalesCode","SalesDate", "CustomerId", "SalesmanId", "PaymentMethod", "Status", "Notes","GrandTotal",
                                         "AmountInWords", "DueDate", "TermOfPayment", 
                                         "ModifiedDate","ModifiedBy" };

                    object[] values = { sales.Code,sales.Date.ToShortDateString(),sales.CustomerId,sales.SalesmanId,sales.PaymentMethod,
                                        sales.Status==true?1:0,sales.Notes,sales.GrandTotal,
                                        sales.AmountInWords, sales.DueDate.ToShortDateString(), sales.TermOfPayment,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};
                    
                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + sales.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(),tx);

                    //detail dihapus -> update qty

                    var list = salesItemRepository.GetBySalesId(sales.ID);
                    foreach (var salesItem in list)
                    {
                        productQtyRepository.UpdateQtyOut(Store.ActiveMonth, Store.ActiveYear, salesItem.ProductId, salesItem.Qty, false);
                    }

                    salesItemRepository.Delete(em, tx, sales.ID);

                    foreach (var salesItem in sales.SalesItems)
                    {
                        salesItem.SalesId = sales.ID;
                        salesItemRepository.Save(em, tx, salesItem);
                        
                        //update product
                         productQtyRepository.UpdateQtyOut(Store.ActiveMonth, Store.ActiveYear, salesItem.ProductId, salesItem.Qty, true);
                    }
                   
                    UpdateGrandTotal(em, tx, sales.ID, sales.GrandTotal);

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();

                throw ex;
            }          

        }

        public void UpdateStatus(IEntityManager em, Transaction tx, Guid id, bool paid)
        {
            int status = 0;
            if (paid) status = 1;
            

            string sql = "UPDATE " + tableName + " SET Status = " + status + " WHERE ID={" + id + "}";
            em.ExecuteNonQuery(sql, tx);
     
        }


        public void Delete(string code)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    var q = new Query().From(tableName).Delete().Where("SalesCode").Equal(code);
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

        public void Delete(IEntityManager em, Transaction tx, string salesCode)
        {
            var q = new Query().From(tableName).Delete().Where("SalesCode").Equal(salesCode);
            em.ExecuteNonQuery(q.ToSql(), tx);
        }


        public void Delete(Sales sales)
        {
            Transaction tx = null;
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    String notes = "";
                    if (sales.Notes != "")
                    {
                        notes = "DIBATALKAN - " + sales.Notes;
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
                        .Where("ID").Equal("{" + sales.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    var itemList = salesItemRepository.GetBySalesId(sales.ID);
                    foreach (var salesItems in itemList)
                    {
                        salesItemRepository.Delete(em, tx, salesItems);
                        productQtyRepository.UpdateQtyOut(Store.ActiveMonth, Store.ActiveYear, salesItems.ProductId, salesItems.Qty, false);
                        
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


        public bool IsSalesUsedByPayment(Guid salesId)
        {
            bool isUsed = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("PayablePaymentItem").Where("SalesId").Equal("{" + salesId + "}");

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

        public bool IsSalesUsedByBillReceipt(Guid salesId)
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

        public List<Sales> Search(string value)
        {
            List<Sales> sales = new List<Sales>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Sales.ID, Sales.SalesCode, Sales.SalesDate, Sales.CustomerId, Customer.CustomerName, Customer.Address, "
                        + "Sales.SalesmanId, Salesman.SalesmanName,Sales.PaymentMethod, Sales.Status, Sales.Notes,Sales.GrandTotal, "
                        + "Sales.CreatedDate, Sales.ModifiedDate, Sales.CreatedBy, Sales.ModifiedBy, "
                        + "Sales.AmountInWords, Sales.DueDate, Sales.PrintCounter, Sales.TermOfPayment "
                        + "FROM (Sales INNER JOIN Customer ON Sales.CustomerId = Customer.ID) "
                        + "INNER JOIN Salesman ON Sales.SalesmanId = Salesman.ID "
                        + "WHERE "
                        + "(Sales.SalesCode like '%" + value + "%' "
                        + "OR Sales.Notes like  '%" + value + "%' "
                        + "OR Customer.CustomerName like '%" + value + "%' "
                        + "OR Salesman.SalesmanName like '%" + value + "%') "
                        + " ORDER BY Sales.SalesCode DESC";


              
                sales = em.ExecuteList<Sales>(sql, new SalesMapper());
            }

            return sales;
        }

        public List<Sales> Search(string value, int month, int year)
        {
            List<Sales> sales = new List<Sales>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Sales.ID, Sales.SalesCode, Sales.SalesDate, Sales.CustomerId, Customer.CustomerName, Customer.Address, "
                        + "Sales.SalesmanId, Salesman.SalesmanName,Sales.PaymentMethod, Sales.Status, Sales.Notes,Sales.GrandTotal, "
                        + "Sales.CreatedDate, Sales.ModifiedDate, Sales.CreatedBy, Sales.ModifiedBy, "
                        + "Sales.AmountInWords, Sales.DueDate, Sales.PrintCounter, Sales.TermOfPayment "
                        + "FROM (Sales INNER JOIN Customer ON Sales.CustomerId = Customer.ID) "
                        + "INNER JOIN Salesman ON Sales.SalesmanId = Salesman.ID "
                        + "WHERE "
                        + "(Sales.SalesCode like '%" + value + "%' "
                        + "OR Sales.Notes like  '%" + value + "%' "
                        + "OR Customer.CustomerName like '%" + value + "%' "
                        + "OR Salesman.SalesmanName like '%" + value + "%') "
                        + "AND Month(Sales.SalesDate)=" + month + " AND Year(Sales.SalesDate)=" + year + " ORDER BY Sales.SalesCode DESC";



                sales = em.ExecuteList<Sales>(sql, new SalesMapper());
            }

            return sales;
        }

        public List<Sales> SearchStatusFalse(string value)
        {
            List<Sales> sales = new List<Sales>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT Sales.ID, Sales.SalesCode, Sales.SalesDate, Sales.CustomerId, Customer.CustomerName, Customer.Address, "
                   + "Sales.SalesmanId, Salesman.SalesmanName,Sales.PaymentMethod, Sales.Status, Sales.Notes,Sales.GrandTotal, "
                   + "Sales.CreatedDate, Sales.ModifiedDate, Sales.CreatedBy, Sales.ModifiedBy, "
                   + "Sales.AmountInWords, Sales.DueDate, Sales.PrintCounter, Sales.TermOfPayment "
                   + "FROM (Sales INNER JOIN Customer ON Sales.CustomerId = Customer.ID) "
                   + "INNER JOIN Salesman ON Sales.SalesmanId = Salesman.ID "
                   + "WHERE Sales.Status=false "
                   + "AND (Sales.SalesCode like '%" + value + "%' "
                   + "OR Sales.Notes like  '%" + value + "%' "
                   + "OR Customer.CustomerName like '%" + value + "%' "
                   + "OR Salesman.SalesmanName like '%" + value + "%') "
                   + " ORDER BY Sales.SalesCode DESC";



                sales = em.ExecuteList<Sales>(sql, new SalesMapper());
            }

            return sales;
        }


         public void UpdatePrintCounter(string salesCode)
        {
            int printCounter = 0;

             using(var em=EntityManagerFactory.CreateInstance(ds))
             {
                Sales sales = GetByCode(salesCode);
                if (sales != null)
                {
                    printCounter = sales.PrintCounter + 1;
                    string sql = "UPDATE " + tableName + " SET PrintCounter = " + printCounter + " WHERE SalesCode='" + salesCode + "'";
                    em.ExecuteNonQuery(sql);

                }
             }
            

        }




    }
}
