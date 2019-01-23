using API_SOAP_licenses.Core;
using Newtonsoft.Json;
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
    
    public class LicensingXProgramService: IVersion, ILicense
    {

        public VersionItem GetNewestVersion()
        {
            var versionEngine = new VersionEngine();

            return versionEngine.GetNewestVersion();
        }

        public bool CheckValidityLicenseByNip(string nip)
        {
            var licenseEngine = new LicenseEngine();

            return licenseEngine.CheckValidityLicenseByNip(nip);
        }

    }
}
