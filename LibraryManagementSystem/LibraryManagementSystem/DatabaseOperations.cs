using System.Data.SqlClient;
using System.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;

namespace LibraryManagementSystem
{
    // Class That handles all interactions with the database
    public class DatabaseOperator
    {
        // Declaring the Connection String
        public string connectionString = "Data Source=MIC348\\SQLEXPRESS; Initial Catalog = LibraryManagementSystem; Integrated Security = True; Encrypt=True;TrustServerCertificate=True";

        // Function that searches books in the database
        public SqlDataReader SearchBookInDatabase(string query)
        {
            // Initialising Sql Connection class object.
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Opening Connection
            sqlConnection.Open();
            Console.WriteLine("Connection Established...");

            // Generating the Sql Command Object and loading it with the Query
            SqlCommand searchBookByNameCommand = new SqlCommand(query, sqlConnection);
            try
            {
                // Firing the Query and loading the search details into a Sql Data reader
                SqlDataReader searchBookByNameResults = searchBookByNameCommand.ExecuteReader();

                // Returning the Search Results
                return searchBookByNameResults;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please Search for another Book");
                return null;
            }


        }

        // Updating the Issue Book Table with the issuing of the Books
        public bool UpdateIssueBookTableInDatabase(string query)
        {

            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                // Opening Connection to Database
                sqlConnection.Open();
                Console.WriteLine("Connection Established...");

                // Generating the Issue Book Command
                SqlCommand issueBookCommand = new SqlCommand(query, sqlConnection);

                // Using try catch block to catch any exceptions that might arise and display them
                try
                {
                    // Executing the Sql Query
                    issueBookCommand.ExecuteNonQuery();
                    return true;
                }

                catch (Exception ex)
                {
                    // Printing the Exception
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }
        }

        public bool UpdateReturnBookInDatabase(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                // Opening Connection to Database
                sqlConnection.Open();
                Console.WriteLine("Connection Established...");

                // Generating the Return Book Command
                SqlCommand returnBookCommand = new SqlCommand(query, sqlConnection);

                // Using try catch block to catch any exceptions that might arise and display them
                try
                {
                    // Executing the Sql Query
                    returnBookCommand.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    // Printing the Exception
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }
        }

        // Function that Generates General Report for the Librarian
        public SqlDataReader ViewGeneralReport(string query)
        {
            return SearchBookInDatabase(query);
        }

        // Function that Generates Issued books Report for the Librarian
        public SqlDataReader ViewIssuedBooksReport(string query)
        {
            return SearchBookInDatabase(query);
        }

        // Function that returns the number of copies that are available for a particular Book
        public int CheckNumberOfCopiesAvailable(string bookName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                // Opening the Sql Database Connection
                sqlConnection.Open();

                // Sql Query to search and select the Number of Copies
                string checkTotalCopiesQuery = $"SELECT totalCopies FROM LibraryTable WHERE bookName='{bookName}'";

                // Generating Command to check number of copies
                SqlCommand checkNumberOfCopiesAvailable = new SqlCommand(checkTotalCopiesQuery, sqlConnection);

                // Executing the Command
                int copies = (int)checkNumberOfCopiesAvailable.ExecuteScalar();

                Console.WriteLine(copies);

                return copies;
            }
        }


        // Function to Delete a Copy From the Database
        public bool DeleteBookCopy(string bookName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                // Opening the Sql Conection
                sqlConnection.Open ();

                // Query for Deleteing the Copy
                string deleteBookCopyQuery = $"UPDATE LibraryTable SET totalCopies=totalCopies-1 WHERE bookName='{bookName}';";

                // Generating Sql Command
                SqlCommand deleteBookCopyCommand = new SqlCommand(deleteBookCopyQuery, sqlConnection);

                try
                {
                    // Executing the Delete Book Command
                    deleteBookCopyCommand.ExecuteNonQuery();
                    Console.WriteLine("A Copy of the book has been Discarded");
                    return true;
                }
                catch (Exception ex)
                {
                    // printing an Exception if it Occurs
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        // Function to Delete a book from the Table
        public bool DeleteBook(string bookName)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                // Opening Sql Connection
                sqlConnection.Open();

                // Query for Deleting the Book Details from the Database
                string deleteBookCopyQuery = $"DELETE FROM LibraryTable WHERE bookName='{bookName}';";

                // Generating the Sql Command
                SqlCommand deleteBookCopyCommand = new SqlCommand(deleteBookCopyQuery, sqlConnection);

                try
                {
                    // Executing the Query
                    deleteBookCopyCommand.ExecuteNonQuery();

                    Console.WriteLine("The Book has been removed from the Library");

                    return true;
                }
                catch (Exception ex)
                {
                    // Printing any Exception that occurs
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }
        }

        // Functions that checks if a student is already present in the database.
        public bool CheckIfAlreadyPresent(string studentName)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                // Opening the Sql Connection
                sqlConnection.Open();

                // Sql Query for Checking if Student Details are present or not
                string checkIfAlreadyPresentQuery = $"SELECT studentId FROM StudentDetails WHERE studentName='{studentName}'";

                // Generating Sql Command
                SqlCommand checkIfAlreadyPresentCommand = new SqlCommand(checkIfAlreadyPresentQuery, sqlConnection);

                try
                {
                    // Returning True if the Student is Present in the Database
                    if ((int)checkIfAlreadyPresentCommand.ExecuteScalar() != 0)
                    {
                        Console.WriteLine("Student Already Present");
                        return true;
                    }
                    else return false;
                }

                catch(Exception ex)
                {
                    // Printing any Exception taht Occurs
                    Console.WriteLine (ex.Message);
                    return false;
                }

            }
        }


        // Function to add new Student to Database
        public bool AddStudentToDatabase(string studentName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                // Opening Connection to the Server
                sqlConnection.Open();

                // Query to add a student to a database if the student isn't already present
                string addStudentToDatabaseQuery = $"BEGIN\r\n\tIF NOT EXISTS\r\n\t(\r\n\t\tSELECT StudentDetails.studentName FROM StudentDetails WHERE StudentDetails.studentName='{studentName}'\r\n\t)\r\n\r\n\tINSERT INTO StudentDetails VALUES ('{studentName}');\r\nEND";

                // Generating Sql Command with above Query
                SqlCommand addStudentToDatabaseCommand = new SqlCommand(addStudentToDatabaseQuery, sqlConnection);

                try
                {
                    // Executing Command
                    addStudentToDatabaseCommand.ExecuteNonQuery();
                    Console.WriteLine("Student Successfully Added"); return true;
                }
                catch (Exception ex)
                {
                    // Printing the Exception
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }


        // Function to Delete Student Details from the Database
        public bool DeleteStudentFromDatabase(string studentName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                // Opening Connection to the Server
                sqlConnection.Open();

                // Query to Delete Students Record
                string deleteStudentFromDataBaseQuery = $"DELETE FROM StudentDetails WHERE studentName='{studentName}'";

                // Generating the SQL Command
                SqlCommand deleteStudentFromDataBaseCommand= new SqlCommand(deleteStudentFromDataBaseQuery, sqlConnection);

                try
                {
                    // Executing the SQL Command
                    deleteStudentFromDataBaseCommand.ExecuteNonQuery();
                    Console.WriteLine("Student Successfully Deleted");    return true;
                }
                catch (Exception ex)
                {
                    // Printing the Exception on Console
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }
        }

        // Function to add new Book Details to the Database 
        public bool AddNewBookToDataBase(Book newBook)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                // Opening New Connection to the Server
                sqlConnection.Open();

                // Query to add a new Book to the Database
                string addNewBookQuery = $"BEGIN\r\n\t\tIF EXISTS\r\n\t(\r\n\t\t(\r\n\t\t\tSELECT LibraryTable.bookName \r\n\t\t\tFROM LibraryTable\r\n\t\t\tWHERE LibraryTable.bookName='{newBook.bookName}'\r\n\t\t)\r\n\t)\r\n\tUPDATE LibraryTable SET totalCopies=totalCopies+1, availableCopies=availableCopies+1\r\n\tWHERE bookName='{newBook.bookName}'\r\n\t\r\nEND\r\n\r\nBEGIN\r\n\r\n\tIF NOT EXISTS\r\n\t(\r\n\t\t(\r\n\t\t\tSELECT LibraryTable.bookName \r\n\t\t\tFROM LibraryTable\r\n\t\t\tWHERE LibraryTable.bookName='{newBook.bookName}'\r\n\t\t)\r\n\t)\r\n\tINSERT INTO LibraryTable (bookName,issuedCopies,totalCopies,availableCopies)\r\n\tVALUES ('{newBook.bookName}',0,1,1);\t\r\n\r\nEND";

                // Generating the SQL Command
                SqlCommand addNewBookCommand = new SqlCommand(addNewBookQuery, sqlConnection);

                try
                {
                    // Executing the Command
                    addNewBookCommand.ExecuteNonQuery();
                    Console.WriteLine("New Book Added");
                }
                catch (Exception ex)
                {
                    // Printing the Exception Message
                    Console.WriteLine(ex.Message);
                    return false;
                }

                // Query that Tkes the list of authors to a particular book and adds it to the Author names Table
                foreach(string authorName in newBook.authorList)
                {
                    string addNewAuthorQuery = $"BEGIN\r\n\r\nIF NOT EXISTS\r\n(\r\n\tSELECT AuthorNames.authorName \r\n\tFROM AuthorNames \r\n\tWHERE AuthorNames.AuthorName = '{authorName}'\r\n)\r\n\r\n\r\n\tINSERT INTO AuthorNames (authorName)\r\n\tVALUES ('{authorName}')\r\n\r\nEND\r\n\r\nBEGIN\r\n\tIF NOT EXISTS\r\n\t(\r\n\tSELECT BooksAndAuthors.AuthorId, BooksAndAuthors.bookId\r\n\tFROM BooksAndAuthors\r\n\tWHERE BooksAndAuthors.AuthorId=( SELECT AuthorNames.authorId FROM AuthorNames WHERE AuthorNames.authorName='{authorName}')\r\n\tAND BooksAndAuthors.bookId=(SELECT LibraryTable.bookId FROM LibraryTable WHERE LibraryTable.bookName='{newBook.bookName}')\r\n\r\n\t)\r\n\r\n\tINSERT INTO BooksAndAuthors(bookId,AuthorId)\r\n\tVALUES \r\n\t(\r\n\t(SELECT LibraryTable.bookId FROM LibraryTable WHERE LibraryTable.bookName='{newBook.bookName}'),\r\n\t(SELECT AuthorNames.AuthorId FROM AuthorNames WHERE AuthorNames.AuthorName='{authorName}')\r\n\t)\r\nEND";

                    // Generating the Command for each new Author
                    SqlCommand addNewAuthorCommand = new SqlCommand(addNewAuthorQuery, sqlConnection);

                    try
                    {
                        // Executing the Query for each Author
                        addNewAuthorCommand.ExecuteNonQuery();
                        Console.WriteLine($"{authorName} Added to the Author List");
                    }
                    catch (Exception ex)
                    {
                        // Printing the Exception to the Console
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
                return true;

            }
        }

        // Function that Prints the Issued Books Table to the Console
        public  void IssueTablePrinter(SqlDataReader dataReader)
        {
            // Formatting the Column Names
            Console.WriteLine(
            System.String.Format("|{0,-35}|{1,-20}|{2,-10}|{3,-10}|", "Book Name", "Student Name", "Issue Date", "Days Passed"));

            // Printing every Row
            while ( dataReader.Read())
            {
                Console.WriteLine(
                    System.String.Format("|{0,-20}|{1,-35}|{2,-10}|{3,-5}|",
                    (dataReader.GetValue(0).ToString()),
                    (dataReader.GetValue(1).ToString()),
                    ((DateTime)(dataReader.GetValue(2))).ToString("dd-MM-yy"),
                    dataReader.GetValue(3)
                    ));
            }

        }

        // Printing General Report for the Librarian Profile
        public  void GeneralReportTablePrinter(SqlDataReader dataReader)
        {
            // Printing Column Names
            Console.WriteLine(
                    System.String.Format("|{0,-35}|{1,-20}|{2,-10}|{3,-10}|", "Book Name", "Author Name", "Total Copies", "Available Copies"));

            // Printing the Rows of the Table
            while (dataReader.Read())
            {


                Console.WriteLine(
                    System.String.Format("|{0,-35}|{1,-20}|{2,-12}|{3,-16}|",
                    (dataReader.GetValue(0).ToString()),
                    (dataReader.GetValue(1).ToString()),
                    dataReader.GetValue(2),
                    dataReader.GetValue(3)
                    ));
            }
        }

        public void SearchBookByNameResultsPrinter(SqlDataReader searchBooksByNameResults)
        {
            // Formatting the Column Names
            Console.WriteLine(
            System.String.Format("|{0,-10}|{1,-35}|{2,-20}|{3,-10}|","Book Id", "Book Name", "Author Name", "Available Copies"));

            // Printing every Row
            while (searchBooksByNameResults.Read())
            {
                Console.WriteLine(
                    System.String.Format("|{0,-10}|{1,-35}|{2,-20}|{3,-10}|",
                    (searchBooksByNameResults.GetValue(4).ToString()),
                    (searchBooksByNameResults.GetValue(0).ToString()),
                    (searchBooksByNameResults.GetValue(1).ToString()),
                    (searchBooksByNameResults.GetValue(2)),
                    searchBooksByNameResults.GetValue(3)
                    ));
            }
        }
    }
}
