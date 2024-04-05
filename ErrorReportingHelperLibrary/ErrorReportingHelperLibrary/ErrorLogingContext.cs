using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorReportingHelperLibrary
{
    public class ErrorLogger
    {
        public bool LogError(IErrorLogger errorLogger,Error error)
        {
           return errorLogger.LogError(error);
        }
    }
}
