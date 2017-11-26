using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using EntityMap;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class EmployeeMapper : IDataMapper<Employee>
    {
        public Employee Map(IDataReader rdr)
        {
            var employee = new Employee();

            employee.ID=rdr["ID"] is DBNull ? 0 : (int)rdr["ID"];
            employee.EmployeeName = rdr["EmployeeName"] is DBNull ? string.Empty : (string)rdr["EmployeeName"];
            employee.Phone1 = rdr["Phone1"] is DBNull ? string.Empty : (string)rdr["Phone1"];
            employee.Phone2 = rdr["Phone2"] is DBNull ? string.Empty : (string)rdr["Phone2"];
            employee.Fee = rdr["Fee"] is DBNull ? 0 : (decimal)rdr["Fee"];
            
            return employee;
        }
    }
}
