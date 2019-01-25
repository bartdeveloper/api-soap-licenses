using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_SOAP_licenses.Tools
{
    public class SanitizeInput
    {
        public static string SanitizeNIP(string nip) => nip.Replace("-", "").Replace(" ", "");
    }
}