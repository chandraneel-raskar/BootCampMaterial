using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OOD_Practice
{
    public abstract class Employee
    {
        public string name;
        public int emp_ID;
        public string address;
        public int salary;
        public virtual void DisplayDetails()
        {
            Console.WriteLine(emp_ID);
            Console.WriteLine(name);
            Console.WriteLine(address);
            Console.WriteLine(salary);
            Console.WriteLine();
        }
    }
    public class PermanentEmp() : Employee
    {
        //public void DisplayDetails()
        //{
        //    Console.WriteLine(name);
        //    Console.WriteLine(emp_ID);
        //    Console.WriteLine(address);
        //    Console.WriteLine(salary);

        //}
    }
    public class TemporaryEmp() : Employee
    {
        public void DisplayDetails(int days)
        {            
            Console.WriteLine(name);
            Console.WriteLine(emp_ID);
            Console.WriteLine(address);
            Console.WriteLine(salary*days);
            Console.WriteLine();
        }
    }

    public class EmpDetails
    {
        public static void Main(string[] args)
        {
            PermanentEmp permanentEmp = new PermanentEmp();
            TemporaryEmp temporaryEmp = new TemporaryEmp();

            permanentEmp.name = "Neel";
            permanentEmp.emp_ID = 1;
            permanentEmp.address = "Baner";
            permanentEmp.salary = 4000;

            temporaryEmp.name = "Neel";
            temporaryEmp.emp_ID = 2;
            temporaryEmp.address = "Baner";
            temporaryEmp.salary = 1000;

            permanentEmp.DisplayDetails();
            temporaryEmp.DisplayDetails(30);


            



        }
    }
}
