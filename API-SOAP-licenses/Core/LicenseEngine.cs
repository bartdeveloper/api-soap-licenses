using API_SOAP_licenses.Repository;
using API_SOAP_licenses.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_SOAP_licenses.Core
{
    public class LicenseEngine: ILicense
    {

        private readonly IRepositoryContext repoContext;

        public LicenseEngine()
        {
            this.repoContext = new API_LicenseEntities();
        }

        public LicenseEngine(IRepositoryContext repoContext)
        {
            this.repoContext = repoContext;
        }

        public bool CheckValidityLicenseByNip(string nip)
        {
            nip = SanitizeInput.SanitizeNIP(nip);

            bool isValidLicense = (from license in repoContext.licenses
                                     join company in repoContext.companies on license.lic_cmpid equals company.cmp_id
                                     where company.cmp_nip.Equals(nip)
                                     select new { license, company }).Any();

            return isValidLicense;
        }

    }
}