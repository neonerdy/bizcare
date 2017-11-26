using System;
using System.Collections.Generic;

using System.Data;
using EntityMap;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class UserAccessMapper : IDataMapper<UserAccess>
    {

        #region IDataMapper<UserAccess> Members

        public UserAccess Map(IDataReader rdr)
        {
            var userAccess = new UserAccess();

            userAccess.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            userAccess.UserId = rdr["UserId"] is DBNull ? Guid.Empty : (Guid)rdr["UserId"];
            userAccess.FullName = rdr["FullName"] is DBNull ? string.Empty : (string)rdr["FullName"];
            userAccess.ObjectType = rdr["ObjectType"] is DBNull ? 1 : (int)rdr["ObjectType"];
            userAccess.ObjectName = rdr["ObjectName"] is DBNull ? string.Empty : (string)rdr["ObjectName"];
            userAccess.IsOpen = rdr["IsOpen"] is DBNull ? false : (bool)rdr["IsOpen"];
            userAccess.IsAdd = rdr["IsAdd"] is DBNull ? false : (bool)rdr["IsAdd"];
            userAccess.IsEdit = rdr["IsEdit"] is DBNull ? false : (bool)rdr["IsEdit"];
            userAccess.IsDelete = rdr["IsDelete"] is DBNull ? false : (bool)rdr["IsDelete"];
            userAccess.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
           
            return userAccess;

        }

        #endregion
    }
}
