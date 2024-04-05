namespace ErrorReportingHelperLibrary
{
    public class TextFileLogger : IErrorLogger
    {
        string errorFilePath = @"C:\Users\craskar\source\repos\ErrorReportingHelperLibrary\ErrorLog.txt";
        public bool LogError(Error error)
        {
            // Setting up the Log in proper Formatting
            DateTime dateTime = DateTime.Now;

            string errorLog= dateTime.ToString()+Environment.NewLine+error.errorCode+Environment.NewLine+error.errorHeader+Environment.NewLine+error.errorDescription+Environment.NewLine+error.helperDocumentationUrl+Environment.NewLine+"---------------------------------------------------------";

            try
            {
                // Using StreamWriter to Write to a text File
                using (StreamWriter writer = new StreamWriter(errorFilePath,true))
                {
                    writer.WriteLine(errorLog);
                    writer.Close();
                }
                return true;
            }
            catch(Exception e)
            {
                // Catching and Printing the Exception
                Console.WriteLine(e.Message);
                return false;
            }
        }


    }
}
