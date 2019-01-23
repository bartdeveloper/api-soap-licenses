using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace API_SOAP_licenses
{

    [ServiceContract]
    interface IVersion
    {
        [OperationContract]
        VersionItem GetNewestVersion();
    }
}
