using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;

namespace BizCare.Repository
{

    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        List<Employee> GetAll();
        List<Employee> Search(string column, string value);
        void Save(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }


    public class EmployeeRepository : IEmployeeRepository
    {
        private string tableName = "Employees";
        private DataSource ds;

        public EmployeeRepository(DataSource ds)
        {
            this.ds = ds;
        }


        public Employee GetById(int id)
        {
            Employee employee = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ID").Equal(id);
                employee = em.ExecuteObject<Employee>(q.ToSql(), new EmployeeMapper());
            }

            return employee;
        }


        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName);
                employees = em.ExecuteList<Employee>(q.ToSql(), new EmployeeMapper());
            }

            return employees;
        }

        public List<Employee> Search(string column, string value)
        {
            List<Employee> employees = new List<Employee>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where(column).Like("%" + value + "%");
                employees = em.ExecuteList<Employee>(q.ToSql(), new EmployeeMapper());
            }

            return employees; 
        }


        public void Save(Employee employee)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = {"EmployeeName","Phone1","Phone2","Fee" };
                    object[] values = {employee.EmployeeName,employee.Phone1,employee.Phone2,employee.Fee };

                    var q = new Query().Select(columns).From(tableName).Insert(values);
                    
                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void Update(Employee employee)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = { "EmployeeName", "Phone1", "Phone2", "Fee" };
                    object[] values = { employee.EmployeeName, employee.Phone1, employee.Phone2, employee.Fee };

                    var q = new Query().Select(columns).From(tableName).Update(values).Where("ID").Equal(employee.ID);

                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void Delete(int id)
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







       
    }
}
