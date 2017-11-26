using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using EntityMap;
using BizCare.Model;

namespace BizCare.Repository.Mapping
{
    public class CategoryMapper : IDataMapper<Category>
    {
        public Category Map(IDataReader rdr)
        {
            var category = new Category();

            category.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            category.Name = rdr["CategoryName"] is DBNull ? string.Empty : (string)rdr["CategoryName"];
            category.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];

            return category;

        }
    }
}
