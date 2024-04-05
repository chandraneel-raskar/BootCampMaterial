using LibraryManagementSystem;
using System.Transactions;
namespace FrontDeskProfile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FrontDesk frontDesk = new FrontDesk();
            while (true)
            {
                Console.WriteLine("Welcome to Front Desk");
                Console.WriteLine("Enter 1 to Issue Book");
                Console.WriteLine("Enter 2 to Return Book");
                int actionChoice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Student ID");
                int studentId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Book Id");
                int BookId = Convert.ToInt32(Console.ReadLine());

                switch (actionChoice)
                {
                    case 1:

                        frontDesk.IssueBook(studentId, BookId);

                        break;

                    case 2:

                        frontDesk.ReturnBook(BookId, studentId);

                        break;
                }
            }

        }
    }
}
