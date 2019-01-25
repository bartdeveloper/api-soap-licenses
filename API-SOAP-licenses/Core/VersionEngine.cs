using API_SOAP_licenses.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_SOAP_licenses.Core
{
    public class VersionEngine
    {
        private readonly IRepositoryContext repoContext;

        public VersionEngine()
        {
            this.repoContext = new API_LicenseEntities();
        }

        public VersionEngine(IRepositoryContext repoContext)
        {
            this.repoContext = repoContext;
        }

        public VersionItem GetNewestVersion()
        {
            var version = repoContext.Versions.OrderByDescending(p => p.ver_id).FirstOrDefault();

            if (version != null)
            {
                return new VersionItem { Name = version.ver_name, Version = version.ver_version };
            } else {
                return new VersionItem { Name = "unnamed", Version = "-1" };
            }
        }

    }
}