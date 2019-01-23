using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_SOAP_licenses.Core
{
    public class VersionEngine
    {

        public VersionItem GetNewestVersion()
        {
            API_LicenseEntities db = new API_LicenseEntities();

            var version = db.versions.OrderByDescending(p => p.ver_id).FirstOrDefault();

            if (version != null)
            {
                return new VersionItem { Name = version.ver_name, Version = version.ver_version };
            } else {
                return new VersionItem { Name = "unnamed", Version = "-1" };
            }
        }

    }
}