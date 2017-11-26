using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using EntityMap;
using BizCare.Model;


namespace BizCare.Repository.Mapping
{
    public class ProductMapper : IDataMapper<Product>
    {
        public Product Map(IDataReader rdr)
        {
            var product = new Product();

            product.ID = rdr["ID"] is DBNull ? Guid.Empty : (Guid)rdr["ID"];
            product.Code = rdr["ProductCode"] is DBNull ? string.Empty : (string)rdr["ProductCode"];
            product.Name = rdr["ProductName"] is DBNull ? string.Empty : (string)rdr["ProductName"];

            product.CategoryId = rdr["CategoryId"] is DBNull ? Guid.Empty : (Guid)rdr["CategoryId"];
            if (product.Category == null) product.Category = new Category();
            product.Category.Name = rdr["CategoryName"] is DBNull ? string.Empty : (string)rdr["CategoryName"];

            product.Unit = rdr["Unit"] is DBNull ? string.Empty : (string)rdr["Unit"];
            product.Notes = rdr["Notes"] is DBNull ? string.Empty : (string)rdr["Notes"];
            product.IsActive = rdr["IsActive"] is DBNull ? false : (bool)rdr["IsActive"];

            product.CreatedDate = rdr["CreatedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["CreatedDate"];
            product.ModifiedDate = rdr["ModifiedDate"] is DBNull ? DateTime.Now : (DateTime)rdr["ModifiedDate"];

            return product;
        }
    }
}
