using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;

namespace BizCare.Repository.Mapping
{
    public class CustomerMapper : IDataMapper<Customer>
    {

        public Customer Map(System.Data.IDataReader rdr)
        {
            var customer = new Customer();

            customer.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            customer.Name = rdr["CustomerName"] is DBNull ? string.Empty : (string)rdr["CustomerName"];
            customer.Address = rdr["Address"] is DBNull ? string.Empty : (string)rdr["Address"];
            customer.Phone = rdr["Phone"] is DBNull ? string.Empty : (string)rdr["Phone"];
            customer.Fax = rdr["Fax"] is DBNull ? string.Empty : (string)rdr["Fax"];
            customer.Email = rdr["Email"] is DBNull ? string.Empty : (string)rdr["Email"];
            customer.ContactPerson = rdr["ContactPerson"] is DBNull ? string.Empty : (string)rdr["ContactPerson"];
            customer.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];
            customer.IsActive = rdr["IsActive"] is DBNull ? false : (bool)rdr["IsActive"];
            customer.Plafon = rdr["Plafon"] is DBNull ? 0 : (decimal)rdr["Plafon"];
            customer.TermOfPayment = rdr["TermOfPayment"] is DBNull ? 0 : (int)rdr["TermOfPayment"];
            customer.FirstBalance = rdr["FirstBalance"] is DBNull ? 0 : (decimal)rdr["FirstBalance"];
            customer.LastBalance = rdr["LastBalance"] is DBNull ? 0 : (decimal)rdr["LastBalance"];
            customer.LastMonthPayment = rdr["LastMonthPayment"] is DBNull ? 0 : (decimal)rdr["LastMonthPayment"];
            customer.ThisMonthPayment = rdr["ThisMonthPayment"] is DBNull ? 0 : (decimal)rdr["ThisMonthPayment"];
            customer.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            customer.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];
                        
            return customer;
        }
    }
}
