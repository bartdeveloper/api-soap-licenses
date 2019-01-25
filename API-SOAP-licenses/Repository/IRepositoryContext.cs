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
        IDbSet<company> Companies { get; set; }
        IDbSet<license> Licenses { get; set; }
        IDbSet<version> Versions { get; set; }
    }
   
}
