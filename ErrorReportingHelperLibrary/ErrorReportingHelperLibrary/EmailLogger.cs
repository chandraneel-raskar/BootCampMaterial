using MimeKit;
using System;
using MailKit.Net.Smtp;
using MailKit;
using System.Threading.Channels;
namespace ErrorReportingHelperLibrary
{
    public class EmailLogger  : IErrorLogger
    {
        public bool LogError(Error error) 
        {
            // Creating the Error Details String
            DateTime dateTime = DateTime.Now;

            string errorLog = dateTime.ToString() + Environment.NewLine + error.errorCode + Environment.NewLine + error.errorHeader + Environment.NewLine + error.errorDescription + Environment.NewLine + error.helperDocumentationUrl + Environment.NewLine + "---------------------------------------------------------";

            // Creating Mime Email Object to populate the email fields like Subject, body, etc.
            MimeMessage email = new MimeMessage();

            // Specifying the Sender and Reciever
            email.From.Add(new MailboxAddress("Chandraneel Raskar", "chandraneel.microlise@gmail.com"));
            email.To.Add(new MailboxAddress("Chandraneel Raskar", "chandraneel.raskar@microlise.com"));

            // Creating the Mail Body
            email.Subject = "Test Error Log";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = errorLog
            }; 

            try
            {
                // Using Smtp Connection to send the mail
                using (SmtpClient smtp = new SmtpClient())
                {
                    // Starting the Connection
                    smtp.Connect("smtp.gmail.com", 587, false);

                    smtp.Authenticate("chandraneel.microlise@gmail.com", "dtci dakn kwqb awid");
                
                    smtp.Send(email);

                    // Closing the Connection
                    smtp.Disconnect(true);
                }
                return true;

            }
            catch (Exception e)
            {
                // Catching and printing any exception that is caught
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
