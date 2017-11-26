using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using System.Data;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class SalesmanMapper : IDataMapper<Salesman>
    {

        public Salesman Map(IDataReader rdr)
        {
            var salesman = new Salesman();
            
            salesman.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            salesman.Name = rdr["SalesmanName"] is DBNull ? string.Empty : (string)rdr["SalesmanName"];
            salesman.Address = rdr["Address"] is DBNull ? string.Empty : (string)rdr["Address"];
            
            salesman.Phone1 = rdr["Phone1"] is DBNull ? string.Empty : (string)rdr["Phone1"];
            salesman.Phone2 = rdr["Phone2"] is DBNull ? string.Empty : (string)rdr["Phone2"];
            salesman.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];
            salesman.IsActive = rdr["IsActive"] is DBNull ? false : (bool)rdr["IsActive"];
            salesman.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            salesman.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];

            return salesman;

        }
    }
}
