using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using EntityMap;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class SupplierMapper : IDataMapper<Supplier>
    {

        public Supplier Map(IDataReader rdr)
        {
            var supplier = new Supplier();

            supplier.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            supplier.Name = rdr["supplierName"] is DBNull ? string.Empty : (string)rdr["supplierName"];
            supplier.Address = rdr["Address"] is DBNull ? string.Empty : (string)rdr["Address"];
            supplier.Phone = rdr["Phone"] is DBNull ? string.Empty : (string)rdr["Phone"];
            supplier.Fax = rdr["Fax"] is DBNull ? string.Empty : (string)rdr["Fax"];
            supplier.Email = rdr["Email"] is DBNull ? string.Empty : (string)rdr["Email"];
            supplier.ContactPerson = rdr["ContactPerson"] is DBNull ? string.Empty : (string)rdr["ContactPerson"];
            supplier.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];
            supplier.IsActive = rdr["IsActive"] is DBNull ? false : (bool)rdr["IsActive"];
            supplier.Plafon = rdr["Plafon"] is DBNull ? 0 : (decimal)rdr["Plafon"];
            supplier.TermOfPayment = rdr["TermOfPayment"] is DBNull ? 0 : (int)rdr["TermOfPayment"];
            supplier.FirstBalance = rdr["FirstBalance"] is DBNull ? 0 : (decimal)rdr["FirstBalance"];
            supplier.LastBalance = rdr["LastBalance"] is DBNull ? 0 : (decimal)rdr["LastBalance"];
            supplier.LastMonthPayment = rdr["LastMonthPayment"] is DBNull ? 0 : (decimal)rdr["LastMonthPayment"];
            supplier.ThisMonthPayment = rdr["ThisMonthPayment"] is DBNull ? 0 : (decimal)rdr["ThisMonthPayment"];
            supplier.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            supplier.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];


            return supplier;

        }
    }
}
