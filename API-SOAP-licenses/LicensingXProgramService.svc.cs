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
    
    public class LicensingXProgramService : ILicensingXProgramService
    {
        public bool CheckValidityLicenseByNip(string nip)
        {
            API_LicenseEntities db = new API_LicenseEntities();

            var queryCheckLicense = (from license in db.licenses
                                     join company in db.companies on license.lic_cmpid equals company.cmp_id
                                     where company.cmp_nip.Equals(nip)
                                     select new { license, company }).Count();

            return queryCheckLicense > 0;

        }

        public VersionItem GetNewestVersion()
        {
            API_LicenseEntities db = new API_LicenseEntities();

            var version = db.versions.OrderByDescending(p => p.ver_id).FirstOrDefault();

            if (version != null)
            {

                return new VersionItem { Name = version.ver_name, Version = version.ver_version };

            }
            else
            {

                return new VersionItem { Name = "unnamed", Version = "-1" };

            }
        }
    }
}
