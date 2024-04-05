using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidBankingApp
{
    public class Fd : BankOperator
    {
        public Fd()
        {
            Console.WriteLine("Fixed Deposit");
        }
        int balance = 2000000;
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
