
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;
using Corbis.Repository;

namespace BizCare.Repository
{
    public interface IProductRepository
    {
        Product GetById(Guid id);
        Product GetLast();
        List<Product> GetAll();
        List<string> FilterByName(string name);
        List<Product> GetActiveProduct();
        List<Product> Search(string value);
        void Save(Product product);
        void Update(Product product);
        void Delete(Guid id);
        bool IsProductUsedBySalesItem(Guid productId);
        bool IsProductNameExisted(String productName);
        bool IsProductCodeExisted(String productCode);
    
    }


    public class ProductRepository : IProductRepository
    {

        private string tableName = "Product";
        private DataSource ds;

        private IProductQtyRepository productQtyRepository;

        public ProductRepository(DataSource ds)
        {
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();
            this.ds = ds;
        }
        

        public Product GetById(Guid id)
        {
            Product product = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT p.ID,p.ProductCode AS ProductCode,ProductName, c.ID AS CategoryID,c.CategoryName,"
                           + "Unit, p.Notes, p.IsActive, "
                           + "p.CreatedDate,p.ModifiedDate "
                           + "FROM (Product p INNER JOIN Category c on p.CategoryId=c.ID) "
                           + "WHERE p.ID='" + id + "' Order By p.ProductCode Asc";                

                product = em.ExecuteObject<Product>(sql, new ProductMapper());
            }

            return product;
        }


        public Product GetLast()
        {
            Product product = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {

                string sql = "SELECT TOP 1 p.ID,p.ProductCode,p.ProductName,c.ID AS CategoryID,c.CategoryName,"
                           + "Unit, p.Notes, p.IsActive, p.CreatedDate,p.ModifiedDate "
                           + "FROM (Product p INNER JOIN Category c on p.CategoryId=c.ID) "
                           + "ORDER BY p.ProductCode Asc";
                       
                product = em.ExecuteObject<Product>(sql, new ProductMapper());
                                
            }

            return product;
        }



        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT p.ID,p.ProductCode,p.ProductName,c.ID AS CategoryID,c.CategoryName,"
                         + "Unit,p.Notes, p.IsActive, p.CreatedDate,p.ModifiedDate "
                         + "FROM (Product p INNER JOIN Category c on p.CategoryId=c.ID) "
                         + "ORDER BY p.ProductCode Asc";
    
                products = em.ExecuteList<Product>(sql, new ProductMapper());          
            }

            return products;
        }


        public List<string> FilterByName(string name)
        {
            List<string> productName = new List<string>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ProductName").Like("%" + name + "%")
                    .And("IsActive=true").OrderBy("ProductCode ASC");

                using(var rdr=em.ExecuteReader(q.ToSql()))
                {
                    while(rdr.Read())
                    {
                        productName.Add(rdr["ProductName"].ToString());
                    }
                }                           
            }

            return productName;
        }



        public List<Product> GetActiveProduct()
        {
            List<Product> products = new List<Product>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT p.ID,p.ProductCode,p.ProductName,c.ID AS CategoryID,c.CategoryName,"
                         + "Unit,p.Notes, p.IsActive, p.CreatedDate,p.ModifiedDate "
                         + "FROM (Product p INNER JOIN Category c on p.CategoryId=c.ID) "
                         + "WHERE p.IsActive=true "
                         + "ORDER BY p.ProductCode asc";

                products = em.ExecuteList<Product>(sql, new ProductMapper());
            }

            return products;
        }
        

        public List<Product> Search(string value)
        {
            List<Product> products = new List<Product>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT p.ID,p.ProductCode,p.ProductName,c.ID AS CategoryID,c.CategoryName,"
                        + "Unit,p.Notes, p.IsActive, p.CreatedDate,p.ModifiedDate "
                        + "FROM (Product p INNER JOIN Category c on p.CategoryId=c.ID) "
                        + "WHERE "
                        + "p.ProductCode Like '%" + value + "%' "
                        + "OR p.ProductName Like '%" + value + "%' "
                        + "OR c.CategoryName Like '%" + value + "%' "
                        + "OR Unit Like '%" + value + "%' "
                        + "OR p.Notes Like '%" + value + "%' "
                        + "ORDER BY p.ProductCode asc";
  
                products = em.ExecuteList<Product>(sql, new ProductMapper());
            }

            return products;        
        }


       

       
        public void Save(Product product)
        {
            Transaction tx=null;
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    Guid ID=Guid.NewGuid();

                    string[] columns = { "ID","ProductCode", "ProductName", "CategoryId", "Unit", "Notes",  
                                       "IsActive", "CreatedDate","ModifiedDate"};

                    object[] values = { ID,product.Code,product.Name,product.CategoryId,product.Unit, product.Notes,
                                        product.IsActive==true?1:0,
                                        DateTime.Now.ToShortDateString(),DateTime.Now.ToShortDateString()};
                    
                    var q = new Query().Select(columns).From(tableName).Insert(values);
                    
                    em.ExecuteNonQuery(q.ToSql(),tx);

                    var productQty=new ProductQty();
 
                    productQty.ActiveYear=Store.ActiveYear;
                    productQty.ActiveMonth=Store.ActiveMonth;
                    productQty.ProductId=ID;
                    productQty.QtyIn = 0;
                    productQty.QtyOut = 0;
                    productQty.QtyEnd = 0;

                    productQtyRepository.Save(em,tx,productQty);

                    tx.Commit();
                }

            }
            catch (Exception ex)
            {
                tx.Rollback();               
                throw ex;
            }
        }

    


        
        public void Update(Product product)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    tx = em.BeginTransaction();
                    
                    string[] columns = { "ProductCode", "ProductName", "CategoryId", "Unit", "Notes",
                                         "IsActive", "ModifiedDate"};
                    
                    object[] values = { product.Code,product.Name,product.CategoryId,product.Unit, product.Notes,
                                          product.IsActive==true?1:0,
                                        DateTime.Now.ToShortDateString()};

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + product.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(),tx);

                    productQtyRepository.Delete(em, tx, product.ID);

                    foreach (var pq in product.ProductQty)
                    {
                        productQtyRepository.Save(em, tx, pq);
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



        public bool IsProductUsedBySalesItem(Guid productId)
        {
            bool isUsed = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("SalesItem").Where("ProductId").Equal("{" + productId + "}");

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


        public bool IsProductNameExisted(String productName)
        {
            bool isExisted = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("Product").Where("ProductName").Equal(productName);

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


        public bool IsProductCodeExisted(String productCode)
        {
            bool isExisted = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("Product").Where("ProductCode").Equal(productCode);

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





    }
}
