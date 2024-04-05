using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Practice
{

     interface IServices
    {
         void DepositAmount(int amount);
         void WithdrawAmount(int amount);
         void CheckBalance();
    }
    internal class CurrentAccount(int amount) : IServices
    {
        int amount = amount;
        public void DepositAmount(int amount)
        {
            Console.WriteLine($"Amount Withdrawn: {amount}");
            this.amount += amount;
        }        
        public void WithdrawAmount(int amount)
        {
            Console.WriteLine($"Amount Deposited: {amount}");
            this.amount -= amount;
        }        
        public void CheckBalance()
        {
            Console.WriteLine($"Balance: {amount}");
        }

    }    
    
    internal class SavingsAccount(int amount) : IServices
    {
        int amount=amount;
        public void DepositAmount(int amount)
        {
            Console.WriteLine($"Amount Withdrawn: {amount}");
            this.amount += amount;
        }        
        public void WithdrawAmount(int amount)
        {
            Console.WriteLine($"Amount Deposited: {amount}");
            this.amount -= amount;
        }        
        public void CheckBalance()
        {
            Console.WriteLine($"Balance: {amount}");
        }

    }
}
