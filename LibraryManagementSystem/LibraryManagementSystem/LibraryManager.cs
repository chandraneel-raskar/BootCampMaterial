
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManagementSystem
{
    // Class that handles Library manager functions
    public class LibraryManager
    {
        // Declaring the Database Operator Class Object to handle the Database operations
        DatabaseOperator databaseOperator = new DatabaseOperator();

        // Function to add New Book to the Database
        public bool AddNewBook(Book newBook)
        {
            return databaseOperator.AddNewBookToDataBase(newBook);

        }

        // Function to Delete a book from the Database
        public bool DeleteBook(string bookName)
        {
            // Check if There are More than 1 Copies Available
            if (databaseOperator.CheckNumberOfCopiesAvailable(bookName) > 1)
            {
                // If more than one book copy available delete Book copy
                databaseOperator.DeleteBookCopy(bookName);
            }
            else
            {
                // If only one book available delete the copy data from the Library Database
                databaseOperator.DeleteBook(bookName);
            }

            return true;

        }

        // Function to add new student to database
        public bool AddNewStudent(string studentName,int studentId)
        {
            try
            {
                // Adding a student to database 
                databaseOperator.AddStudentToDatabase(studentName);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Function to Remove student details from database
        public bool RemoveStudent(string studentName,int studentId)
        {
            // Check if student Present else print student Not Present
            if (databaseOperator.CheckIfAlreadyPresent(studentName))
            {
                // If student Present Delete from database
                databaseOperator.DeleteStudentFromDatabase(studentName);
                return true;
            }
            else 
            {
                Console.WriteLine("Student Not Present");
                return false;
            }

        }

        // Function to View General Report(Book Name,Author Name,Issued Copies,Available Copies and total copies present)
        public void ViewGeneralReport()
        {
            // Query to fetch the required Data from Database
            string generalReportQuery = $"SELECT LibraryTable.bookName,AuthorNames.authorName,LibraryTable.issuedCopies,LibraryTable.availableCopies FROM BooksAndAuthors JOIN LibraryTable ON BooksAndAuthors.bookId = LibraryTable.bookId JOIN AuthorNames ON AuthorNames.authorId = BooksAndAuthors.AuthorId;";

            // Generating the results and storing it in Data reader
            SqlDataReader generalReportResults = databaseOperator.ViewGeneralReport(generalReportQuery);

            // Calling the Data Printer Function
            databaseOperator.GeneralReportTablePrinter(generalReportResults);
            
        }

        // Function to Generate View issued books Report (Book name, Student name, Issue Date, Number of days passed)
        public void ViewIssuedBooksReport()
        {
            // Query to fetch the required Data from Database
            string issuedBooksReportQuery = $"SELECT StudentDetails.studentName,LibraryTable.bookName,IssueTable.date,(datediff(day,IssueTable.date ,GETDATE()))AS DaysPassed FROM IssueTable\r\nJOIN StudentDetails ON IssueTable.studentId=StudentDetails.studentId\r\nJOIN LibraryTable ON IssueTable.bookId=LibraryTable.bookId";

            // Generating the results and storing it in Data reader
            SqlDataReader issuedBooksReportResults = databaseOperator.ViewIssuedBooksReport(issuedBooksReportQuery);

            // Calling the Data Printer Function
            databaseOperator.IssueTablePrinter(issuedBooksReportResults);

        }

    }
}
