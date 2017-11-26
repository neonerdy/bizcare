using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Corbis.Repository.Mapping
{
    public interface IDataMapper<T>
    {
        T Map(IDataReader rdr);
    }
}
