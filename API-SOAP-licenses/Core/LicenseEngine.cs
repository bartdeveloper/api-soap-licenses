using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_SOAP_licenses.Core
{
    public class LicenseEngine: ILicense
    {

        public bool CheckValidityLicenseByNip(string nip)
        {
            API_LicenseEntities db = new API_LicenseEntities();

            bool isValidLicense = (from license in db.licenses
                                     join company in db.companies on license.lic_cmpid equals company.cmp_id
                                     where company.cmp_nip.Equals(nip)
                                     select new { license, company }).Any();

            return isValidLicense;
        }

    }
}