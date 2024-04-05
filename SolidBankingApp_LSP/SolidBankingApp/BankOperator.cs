using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidBankingApp
{
    public class BankOperator
    {
        int balance = 10000;
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
