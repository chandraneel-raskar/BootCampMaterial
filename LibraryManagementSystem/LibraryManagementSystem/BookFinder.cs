using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManagementSystem
{
    public class BookFinder
    {
        // Searches the Database with the book name entered by the User and prints it using the table Printer.
        public bool SearchBookByName(string name)
        {
            // The Search Query
            string searchByNameQuery = $"BEGIN\r\n\tIF NOT EXISTS\r\n\t\t(\r\n\t\t\tSELECT LibraryTable.bookName,AuthorNames.authorName,LibraryTable.issuedCopies,LibraryTable.availableCopies, LibraryTable.bookId \r\n\t\t\tFROM BooksAndAuthors \r\n\t\t\tJOIN LibraryTable ON BooksAndAuthors.bookId = LibraryTable.bookId \r\n\t\t\tJOIN AuthorNames ON AuthorNames.authorId = BooksAndAuthors.AuthorId \r\n\t\t\tWHERE LibraryTable.bookName LIKE '%{name}%'\r\n\t\t)\r\n\r\n\tTHROW 50001,'Book Not Found in Database',1;\r\n\tELSE\r\n\t(\r\n\t\t\tSELECT LibraryTable.bookName,AuthorNames.authorName,LibraryTable.issuedCopies,LibraryTable.availableCopies, LibraryTable.bookId \r\n\t\t\tFROM BooksAndAuthors \r\n\t\t\tJOIN LibraryTable ON BooksAndAuthors.bookId = LibraryTable.bookId \r\n\t\t\tJOIN AuthorNames ON AuthorNames.authorId = BooksAndAuthors.AuthorId \r\n\t\t\tWHERE LibraryTable.bookName LIKE '%{name}%'\r\n\t\r\n\t)\r\nEND";

            // Initialising the database operator class
            DatabaseOperator databaseOperator = new DatabaseOperator();

            // Getting the search results in a Sql data reader
            SqlDataReader searchBooksByNameResults = databaseOperator.SearchBookInDatabase(searchByNameQuery);

            // Printing the search results
            if(searchBooksByNameResults != null )
            {
                databaseOperator.SearchBookByNameResultsPrinter(searchBooksByNameResults);
            }
            return true;
        }

        // Searches the Database with the author name enterd by the User
        public bool SearchBookByAuthor(string author)
        {
            // Search by author Query
            string searchByAuthorQuery = $"BEGIN\r\n\tIF NOT EXISTS\r\n\t\t(\r\n\t\t\tSELECT LibraryTable.bookName,AuthorNames.authorName,LibraryTable.issuedCopies,LibraryTable.availableCopies, LibraryTable.bookId \r\n\t\t\tFROM BooksAndAuthors \r\n\t\t\tJOIN LibraryTable ON BooksAndAuthors.bookId = LibraryTable.bookId \r\n\t\t\tJOIN AuthorNames ON AuthorNames.authorId = BooksAndAuthors.AuthorId \r\n\t\t\tWHERE AuthorNames.authorName LIKE '%{author}%'\r\n\t\t)\r\n\r\n\tTHROW 50001,'Book Not Found in Database',1;\r\n\tELSE\r\n\t(\r\n\t\t\tSELECT LibraryTable.bookName,AuthorNames.authorName,LibraryTable.issuedCopies,LibraryTable.availableCopies, LibraryTable.bookId \r\n\t\t\tFROM BooksAndAuthors \r\n\t\t\tJOIN LibraryTable ON BooksAndAuthors.bookId = LibraryTable.bookId \r\n\t\t\tJOIN AuthorNames ON AuthorNames.authorId = BooksAndAuthors.AuthorId \r\n\t\t\tWHERE AuthorNames.authorName LIKE '%{author}%'\r\n\t\r\n\t)\r\nEND";

            // Initialising the databse operator class
            DatabaseOperator databaseOperator = new DatabaseOperator();

            // Getting the Search results in a Sql data reader
            SqlDataReader searchBooksByAuthorResults = databaseOperator.SearchBookInDatabase(searchByAuthorQuery);

            if (searchBooksByAuthorResults != null)
            {
                // Printing the Search Results
                databaseOperator.SearchBookByNameResultsPrinter(searchBooksByAuthorResults);
            }
            return true;
        }
    }
}
