using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;

namespace BizCare.Repository
{
    public interface IUserAccessRepository
    {
        List<UserAccess> GetAll();
        List<UserAccess> GetByName(string fullName);
        UserAccess GetById(Guid id);
        UserAccess GetLast();
        bool IsUserAccessExist(string fullName,string objectName);
        void Save(UserAccess userAccess);
        void Update(UserAccess userAccess);
        void Delete(Guid id);
    }


    public class UserAccessRepository : IUserAccessRepository
    {

        private DataSource ds;
        private string tableName = "UserAccess";

        public UserAccessRepository(DataSource ds)
        {
            this.ds = ds;
        }


        #region IUserAccessRepository Members

        public List<UserAccess> GetAll()
        {
            List<UserAccess> userAccess = new List<UserAccess>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT UserAccess.ID, UserAccess.UserId, UserLogin.FullName,UserAccess.ObjectType,UserAccess.ObjectName,"
                         + "UserAccess.IsOpen, UserAccess.IsAdd, UserAccess.IsEdit, UserAccess.IsDelete,UserAccess.CreatedDate "
                         + "FROM UserAccess INNER JOIN UserLogin ON UserAccess.UserId = UserLogin.ID "
                         + "ORDER BY UserLogin.FullName,UserAccess.ObjectType ASC,UserAccess.ObjectName ASC";
                
                userAccess=em.ExecuteList<UserAccess>(sql, new UserAccessMapper());
            }

            return userAccess;
        }


        public List<UserAccess> GetByName(string fullName)
        {
            List<UserAccess> userAccess = new List<UserAccess>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT UserAccess.ID, UserAccess.UserId, UserLogin.FullName,UserAccess.ObjectType,UserAccess.ObjectName,"
                         + "UserAccess.IsOpen, UserAccess.IsAdd, UserAccess.IsEdit, UserAccess.IsDelete,UserAccess.CreatedDate "
                         + "FROM UserAccess INNER JOIN UserLogin ON UserAccess.UserId = UserLogin.ID "
                         + "WHERE UserLogin.FullName='" + fullName + "' "
                         + "ORDER BY UserLogin.FullName,UserAccess.ObjectType ASC,UserAccess.ObjectName ASC";
                

                userAccess = em.ExecuteList<UserAccess>(sql, new UserAccessMapper());
            }

            return userAccess;
        }



        public UserAccess GetById(Guid id)
        {
            UserAccess userAccess = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT UserAccess.ID, UserAccess.UserId, UserLogin.FullName, UserAccess.ObjectType,UserAccess.ObjectName,"
                      + "UserAccess.IsOpen, UserAccess.IsAdd, UserAccess.IsEdit, UserAccess.IsDelete,UserAccess.CreatedDate "
                      + "FROM UserAccess INNER JOIN UserLogin ON UserAccess.UserId = UserLogin.ID "
                      + "WHERE UserAccess.ID='{" + id + "}'";
                
                userAccess = em.ExecuteObject<UserAccess>(sql, new UserAccessMapper());
            }

            return userAccess;
        }



        public UserAccess GetLast()
        {
            UserAccess userAccess = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT TOP 1 UserAccess.ID, UserAccess.UserId, UserLogin.FullName,UserAccess.ObjectType,UserAccess.ObjectName,"
                      + "UserAccess.IsOpen, UserAccess.IsAdd, UserAccess.IsEdit, UserAccess.IsDelete,UserAccess.CreatedDate "
                      + "FROM UserAccess INNER JOIN UserLogin ON UserAccess.UserId = UserLogin.ID ORDER BY UserAccess.CreatedDate DESC";

                userAccess = em.ExecuteObject<UserAccess>(sql, new UserAccessMapper());
            }

            return userAccess;
        }


        public bool IsUserAccessExist(string fullName,string objectName)
        {
            bool isExist = false;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT UserAccess.ID, UserAccess.UserId, UserLogin.FullName, UserAccess.ObjectType,UserAccess.ObjectName,"
                      + "UserAccess.IsOpen, UserAccess.IsAdd, UserAccess.IsEdit, UserAccess.IsDelete,UserAccess.CreatedDate "
                      + "FROM UserAccess INNER JOIN UserLogin ON UserAccess.UserId = UserLogin.ID "
                      + "WHERE UserLogin.FullName='" + fullName + "' AND UserAccess.ObjectName='" + objectName + "'";

                using (var rdr = em.ExecuteReader(sql))
                {
                    if (rdr.Read())
                    {
                        isExist = true;
                    }
                }
            }

            return isExist;
        }

        
        public void Save(UserAccess userAccess)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = { "ID","UserId","ObjectType","ObjectName","IsOpen","IsAdd","IsEdit","IsDelete","CreatedDate"};
                    object[] values = { Guid.NewGuid(),userAccess.UserId,userAccess.ObjectType,userAccess.ObjectName,userAccess.IsOpen==true?1:0,userAccess.IsAdd==true?1:0,
                                        userAccess.IsEdit==true?1:0,userAccess.IsDelete==true?1:0,DateTime.Now.ToShortDateString()};
                    
                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void Update(UserAccess userAccess)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = { "UserId", "ObjectType", "ObjectName", "IsOpen", "IsAdd", "IsEdit", "IsDelete", "CreatedDate" };
                    object[] values = { userAccess.UserId,userAccess.ObjectType,userAccess.ObjectName,userAccess.IsOpen==true?1:0,userAccess.IsAdd==true?1:0,
                                        userAccess.IsEdit==true?1:0,userAccess.IsDelete==true?1:0,DateTime.Now.ToShortDateString()};
                   
                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + userAccess.ID + "}");

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
                    var q = new Query().From(tableName).Delete().Where("ID").Equal(id);
                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
