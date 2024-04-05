using SolidBankingApp;
using System.Security.Principal;

class Program
{
    public static void Main(string[] args)
    {
        var savingsAccount = new SavingsAccount();
        var currentAccount = new CurrentAccount();
        var fdAccount = new Fd();

        Console.WriteLine("Deposited in Savings Account= "+savingsAccount.Deposit(1000));
        Console.WriteLine("Withdrawn from Savings Account= "+ savingsAccount.Withdraw(200));

        Console.WriteLine("Deposited in Current Account= "+ currentAccount.Deposit(2000));
        Console.WriteLine("Withdrawn from Current Account= " + currentAccount.Withdraw(500));

        Console.WriteLine("Deposited in FD Account= " + fdAccount.Deposit(5000));
        Console.WriteLine("Withdrawn from FD Account= " + fdAccount.Withdraw(1000));

        // You can treat any account type as an Account:
        BankOperator genericAccount = savingsAccount;
        Console.WriteLine("Deposited in Savings Account= " + genericAccount.Deposit(1000)); // here it will call deposit method from savings account

        // More operations and scenarios can be added as needed.
        Console.ReadLine();
    }
}