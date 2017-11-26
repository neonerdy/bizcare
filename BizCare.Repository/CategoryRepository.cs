using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityMap;
using System.Data;
using BizCare.Model;
using BizCare.Repository.Mapping;

namespace BizCare.Repository
{
    public interface ICategoryRepository
    {
        Category GetById(Guid id);
        Category GetByName(String name);
        Category GetLast();
        List<Category> GetAll();
        void Save(Category category);
        void Update(Category category);
        void Delete(Guid id);
        bool IsCategoryUsedByProduct(Guid categoryId);
        bool IsCategoryNameExisted(string categoryName);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private string tableName = "Category";
        private DataSource ds;

        public CategoryRepository(DataSource ds)
        {
            this.ds = ds;
        }


        
        public Category GetById(Guid id)
        {
            Category category = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ID").Equal("{" + id + "}");
                category = em.ExecuteObject<Category>(q.ToSql(), new CategoryMapper());
            }

            return category;        
        }


        public Category GetLast()
        {
            Category category = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().Select("TOP 1 *").From(tableName);

                category = em.ExecuteObject<Category>(q.ToSql(), new CategoryMapper());
            }

            return category;
        }

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).OrderBy("CategoryName");
                categories = em.ExecuteList<Category>(q.ToSql(), new CategoryMapper());
            }

            return categories;        
        }


        public Category GetByName(string name)
        {
            Category category = new Category();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("CategoryName").Equal(name);
                category = em.ExecuteObject<Category>(q.ToSql(), new CategoryMapper());
            }

            return category;        

        }



        public void Save(Category category)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = { "ID","CategoryName","Notes" };
                    object[] values = { Guid.NewGuid(),category.Name,category.Notes };

                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Update(Category category)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = { "CategoryName", "Notes" };
                    object[] values = { category.Name, category.Notes };

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + category.ID + "}");

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
                    var q = new Query().From(tableName).Delete()
                        .Where("ID").Equal("{" + id + "}");

                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public bool IsCategoryUsedByProduct(Guid categoryId)
        {
            bool isUsed = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("Product").Where("CategoryId").Equal("{" + categoryId + "}");

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


        public bool IsCategoryNameExisted(string categoryName)
        {
            bool isExisted = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From("Category").Where("CategoryName").Equal(categoryName);

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
