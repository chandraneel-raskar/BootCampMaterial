using LibraryManagementSystem;

namespace StudentProfile
{
    public class Program
    {

        static void Main(string[] args)
        {
                Console.WriteLine("Hello Student!!!");
            while (true)
            {
                Console.WriteLine("How would you like to search the books???");
                Console.WriteLine("1.By Book Name");
                Console.WriteLine("2.By Author Name");
                int studentChoice = Convert.ToInt32(Console.ReadLine());

                BookFinder bookFinder = new BookFinder();

                switch (studentChoice)
                {
                    case 1:
                        Console.WriteLine("Enter the Book Name");
                        string bookName = Console.ReadLine();

                        bookFinder.SearchBookByName(bookName);
                        break;

                    case 2:
                        Console.WriteLine("Enter the Author Name");
                        string authorName = Console.ReadLine();

                        bookFinder.SearchBookByAuthor(authorName);
                        break;
                }
                Console.WriteLine("\n\n");

            }
        }
    }
}
