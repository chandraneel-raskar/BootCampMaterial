using System.Data.SqlClient;
using System.Transactions;

namespace LibraryManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            LibraryManager libraryManager = new LibraryManager();

            while (true)
            {
                Console.WriteLine("Welcome to the Library Admin Profile");
                Console.WriteLine("Choose an Action to be Performed.");
                Console.WriteLine("1.Add New Book");
                Console.WriteLine("2.Delete Book");
                Console.WriteLine("3.Add Student");
                Console.WriteLine("4.Remove Student");
                Console.WriteLine("5.View General Report");
                Console.WriteLine("6.View Issued Books Report");

                int adminChoice=Convert.ToInt32(Console.ReadLine());

                switch (adminChoice)
                {
                    case 1:
                        Console.WriteLine("Enter the Name of the book");
                        string newBook= Console.ReadLine();

                        Console.WriteLine("How Many Authors does the book have??");
                        int noOfAuthors=Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter the Author Names");
                        List<string> authorList = new List<string>();
                        for (int i=0;i<noOfAuthors;i++)
                        {
                            string authorName= Console.ReadLine();
                            authorList.Add(authorName);
                        }

                        Book book= new Book(newBook, authorList);

                        libraryManager.AddNewBook(book);
                    
                        break;

                    case 2:
                        Console.WriteLine("Enter the Name of the book");
                        string deleteBookName = Console.ReadLine();
                        libraryManager.DeleteBook(deleteBookName);
                        break;

                    case 3:
                        Console.WriteLine("Enter the Student Name");
                        string studentName = Console.ReadLine();
                        Console.WriteLine("Enter the Student Id");
                        int studentId = Convert.ToInt32(Console.ReadLine());

                        libraryManager.AddNewStudent(studentName,studentId);
                        break;

                    case 4:
                        Console.WriteLine("Enter the Student Name");
                        string studentNameToBeDeleted = Console.ReadLine();
                        Console.WriteLine("Enter the Student ID");
                        int studentIdToBeDeleted = Convert.ToInt32(Console.ReadLine());
                    

                        libraryManager.RemoveStudent(studentNameToBeDeleted,studentIdToBeDeleted);
                        break;

                    case 5:
                        libraryManager.ViewGeneralReport();
                        break;

                    case 6:
                        libraryManager.ViewIssuedBooksReport();
                        break;
                }

            }
        }
    }
}
