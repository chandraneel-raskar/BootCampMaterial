using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorReportingHelperLibrary
{
    public class WindowsEventLogger : IErrorLogger
    {
        public bool LogError(Error error) 
        {

            try
            {
                // Using the EventLog to log a new event in Windows Event Viewer
                EventLog eventLog = new EventLog();

                eventLog.Source = "Application";
                eventLog.WriteEntry(error.errorDescription, EventLogEntryType.Error, error.errorCode);

                return true;
            }
            catch (Exception e)
            {
                // Catching and printing Exception
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
