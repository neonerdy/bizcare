using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using System.Data;
using BizCare.Model;


namespace BizCare.Repository.Mapping
{
    public class CompanyMapper : IDataMapper<Company>
    {
        public Company Map(IDataReader rdr)
        {
            var company = new Company();

            company.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            company.Code = rdr["Code"] is DBNull ? string.Empty : (string)rdr["Code"];
            company.Name = rdr["CompanyName"] is DBNull ? string.Empty : (string)rdr["CompanyName"];
            company.Address = rdr["Address"] is DBNull ? string.Empty : (string)rdr["Address"];
            company.Phone1 = rdr["Phone1"] is DBNull ? string.Empty : (string)rdr["Phone1"];
            company.Phone2 = rdr["Phone2"] is DBNull ? string.Empty : (string)rdr["Phone2"];
            company.Fax = rdr["Fax"] is DBNull ? string.Empty : (string)rdr["Fax"];
            company.Email = rdr["Email"] is DBNull ? string.Empty : (string)rdr["Email"];
            company.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];
            company.ReportDivider = rdr["ReportDivider"] is DBNull ? 0 : (int)rdr["ReportDivider"];
            company.FirstUsedDate = rdr["FirstUsedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["FirstUsedDate"];
            company.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            company.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];

            return company;
        }

    }
}
