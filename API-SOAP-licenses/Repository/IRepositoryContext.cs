using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_SOAP_licenses.Repository
{
    public interface IRepositoryContext
    {
        IDbSet<company> companies { get; set; }
        IDbSet<license> licenses { get; set; }
        IDbSet<version> versions { get; set; }
    }
   
}
