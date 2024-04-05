using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidBankingApp
{
    public class SavingsAccount : BankOperator
    {
        public SavingsAccount() 
        {
            Console.WriteLine("Savings Account");
        }
        int balance = 3000;
        public int Withdraw(int Amount)
        {
            return balance -= Amount;
        }
        public int Deposit(int Amount)
        {
            return balance += Amount;
        }
    }
}
