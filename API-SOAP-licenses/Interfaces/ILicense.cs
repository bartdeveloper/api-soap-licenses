using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace API_SOAP_licenses
{

    [ServiceContract]
    public interface ILicense
    {

        [OperationContract]
        bool CheckValidityLicenseByNip(string nip);

    }

}
