using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;

namespace BizCare.Repository
{
    public interface IUserLoginRepository
    {
        bool IsValidate(string userName, string password);
        UserLogin GetByUserAndPassword(string userName, string password);
        UserLogin GetById(Guid id);
        UserLogin GetByName(string fullName);
        List<UserLogin> GetAll();
        UserLogin GetLast();
        void Save(UserLogin user);
        void Update(UserLogin user);
        void UpdateLastLogin(Guid id);
        void Delete(Guid id);
    }
    

    public class UserLoginRepository : IUserLoginRepository
    {
        private string tableName = "UserLogin";
        private DataSource ds;
             
        public UserLoginRepository(DataSource ds)
        {
            this.ds = ds;
        }


        public bool IsValidate(string userName, string password)
        {
            bool isValid = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("UserName").Equal(userName)
                    .And("UserPassword").Equal(password);

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    if (rdr.Read())
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }


        public UserLogin GetByUserAndPassword(string userName, string password)
        {
            UserLogin user = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("UserName").Equal(userName)
                    .And("UserPassword").Equal(password);

                user = em.ExecuteObject<UserLogin>(q.ToSql(), new UserLoginMapper());
            }

            return user;
        }


        public UserLogin GetById(Guid id)
        {
            UserLogin user = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ID").Equal(id);
                user = em.ExecuteObject<UserLogin>(q.ToSql(), new UserLoginMapper());
            }

            return user;
        }



        public  UserLogin GetByName(string fullName)
        {
            UserLogin user = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("FullName").Equal(fullName);
                user = em.ExecuteObject<UserLogin>(q.ToSql(), new UserLoginMapper());
            }
            return user;
        }

       


        public List<UserLogin> GetAll()
        {
            List<UserLogin> users = new List<UserLogin>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName);
                users = em.ExecuteList<UserLogin>(q.ToSql(), new UserLoginMapper());
            }

            return users;
        }


        public UserLogin GetLast()
        {
            UserLogin user = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().Select("TOP 1 *").From(tableName);
             
                user = em.ExecuteObject<UserLogin>(q.ToSql(), new UserLoginMapper());
            }

            return user;
        }




        public void Save(UserLogin user)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = { "ID", "UserName", "UserPassword", "FullName", "IsAdministrator","Notes","CreatedDate" };
                    object[] values = { Guid.NewGuid(), user.UserName,user.Password,user.FullName,user.IsAdministrator==true?1:0,
                                        user.Notes,DateTime.Now.ToShortDateString() };

                    var q = new Query().Select(columns).From(tableName).Insert(values);
                    
                    em.ExecuteNonQuery(q.ToSql());

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        
        public void Update(UserLogin user)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = { "UserName", "UserPassword", "FullName", "IsAdministrator", "Notes" };
                    object[] values = { user.UserName, user.Password, user.FullName, user.IsAdministrator==true?1:0, user.Notes };

                    var q = new Query().Select(columns).From(tableName).Update(values).Where("ID").Equal("{" + user.ID + "}");

                    em.ExecuteNonQuery(q.ToSql());
                }        
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void UpdateLastLogin(Guid id)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string sql = "UPDATE " + tableName + " SET LastLogin='" 
                        + DateTime.Now + "' "
                        + "WHERE ID='{" + id + "}'";

                    em.ExecuteNonQuery(sql);
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
                using(var em=EntityManagerFactory.CreateInstance(ds))
                {
                    var q = new Query().From(tableName).Delete().Where("ID").Equal(id);
                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

    
    }
}
