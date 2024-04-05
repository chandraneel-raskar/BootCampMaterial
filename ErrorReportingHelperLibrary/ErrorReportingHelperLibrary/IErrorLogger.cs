using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorReportingHelperLibrary
{
    public interface IErrorLogger
    {
        public bool LogError(Error error);
    }
}
