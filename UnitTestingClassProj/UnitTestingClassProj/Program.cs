namespace UnitTestingClassProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class FizzBuzzSoln
    {
        public string FizzBuzz(int n)
        {
            if (n % 15 == 0) return "FizzBuzz";
            if (n % 3 == 0) return "Fizz";
            if (n % 5 == 0) return "Buzz";
            return "not a FIZZBUZZ";

        }
    }
}
