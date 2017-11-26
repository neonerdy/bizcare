using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;

namespace BizCare.Repository
{
    public interface ICompanyRepository
    {
        Company GetById(Guid id);
        List<Company> GetAll();
        List<Company> Search(string column, string value);
        void Update(Company company);
    }

    public class CompanyRepository : ICompanyRepository
    {
        private string tableName = "Company";
        private DataSource ds;

        public CompanyRepository(DataSource ds)
        {
            this.ds = ds;
        }

        public Company GetById(Guid id)
        {
            Company company = null;
            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("ID").Equal("{" + id + "}");
                company = em.ExecuteObject<Company>(q.ToSql(), new CompanyMapper());
            }
            return company;
        }

        public List<Company> GetAll()
        {
            List<Company> companies = new List<Company>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName);
                companies = em.ExecuteList<Company>(q.ToSql(), new CompanyMapper());
            }

            return companies;
        }


        public List<Company> Search(string column, string value)
        {
            List<Company> companies = new List<Company>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where(column).Equal(value);
                companies = em.ExecuteList<Company>(q.ToSql(), new CompanyMapper());
            }

            return companies;
        }



        public void Update(Company company)
        {
            try
            {

                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string[] columns = {"Code", "CompanyName","Address", "Phone1", "Phone2", "Fax", "Email", "ReportDivider",
                                        "FirstUsedDate", "ModifiedDate", "Notes"};

                    object[] values = {company.Code, company.Name, company.Address, company.Phone1, company.Phone2, company.Fax, 
                                       company.Email, company.ReportDivider, company.FirstUsedDate.ToShortDateString(), DateTime.Now.ToShortDateString(), company.Notes};

                    var q = new Query().Select(columns).From(tableName).Update(values).Where("ID").Equal("{" + company.ID + "}");

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
