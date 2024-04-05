namespace LibraryManagementSystem
{
    // Class that encapsulated the functions of the Front Desk Operations
    public class FrontDesk
    {
        // Initialising the Database Class Object to enable Database operations
        public DatabaseOperator databaseOperator = new DatabaseOperator();

        // Function to Issue Book
        public bool IssueBook(int studentId,int bookId)
        {
            // Query for Issuing of the Book
            string issueBookQuery = $"UPDATE LibraryTable SET issuedCopies=issuedCopies+1, availableCopies=availableCopies-1 WHERE bookId={bookId};\r\n" +
                $"INSERT INTO IssueTable VALUES({bookId},{studentId},GETDATE());";
            try
            {
                // Calling the Database Function
                databaseOperator.UpdateIssueBookTableInDatabase(issueBookQuery);

                // Displaying the Confirmation
                    Console.WriteLine($"Book ID={bookId} Issued Successfully to Student ID={studentId}");
                return true;
            }
            catch (Exception ex)
            {
                // Printing any Exception that Occurs
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        // Function to Return the Book and Update the Database
        public bool ReturnBook( int bookId,int studentId)
        {
            // Query to make Changes to the Database after the book has been Returned
            string returnBookQuery = $"UPDATE LibraryTable SET issuedCopies=issuedCopies-1, availableCopies=availableCopies+1 WHERE bookId={bookId};" +
                $"DELETE FROM IssueTable WHERE studentId={studentId} AND bookId={bookId}";

            try
            {
                // Calling the Database Function
                databaseOperator.UpdateReturnBookInDatabase(returnBookQuery);

                // Printing the Success Message
                Console.WriteLine($"Book ID={bookId} Returned Successfully.");
                return true;
            }

            catch (Exception ex)
            {
                // Printing the any Exception that Occurs
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
