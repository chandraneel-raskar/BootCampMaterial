using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorReportingHelperLibrary
{
    public class Error
    {
        public int errorCode;
        public string errorHeader;
        public string errorDescription;
        public string helperDocumentationUrl = "www.HelperDocURL.com";

        public Error(int errCode, string errHeader, string errDescription)
        {
            this.errorCode = errCode;
            this.errorHeader = errHeader;
            this.errorDescription = errDescription;
        }
    }
}
