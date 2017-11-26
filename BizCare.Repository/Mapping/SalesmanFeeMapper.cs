using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using System.Data;
using BizCare.Model;


namespace BizCare.Repository.Mapping
{
    public class SalesmanFeeMapper : IDataMapper<SalesmanFee>
    {

        public SalesmanFee Map(IDataReader rdr)
        {

            var salesmanFee = new SalesmanFee();
            
            salesmanFee.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            salesmanFee.ActiveYear = rdr["ActiveYear"] is DBNull ? 0 : (int)rdr["ActiveYear"];
            salesmanFee.ActiveMonth = rdr["ActiveMonth"] is DBNull ? 0 : (int)rdr["ActiveMonth"];

            salesmanFee.SalesmanId = rdr["SalesmanId"] is DBNull ? Guid.Empty : (Guid)rdr["SalesmanId"];
            if (salesmanFee.Salesman == null) salesmanFee.Salesman = new Salesman();
            salesmanFee.Salesman.Name = rdr["SalesmanName"] is DBNull ? string.Empty : (string)rdr["SalesmanName"];

            
            salesmanFee.FeePercentage = rdr["FeePercentage"] is DBNull ? 0 : (int)rdr["FeePercentage"];
            salesmanFee.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            salesmanFee.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];


            return salesmanFee;
        }

    }
}
