using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileValidation
{
    public class Employee()
    {
        public string name;
        public string gender;
        public string manager;
        public string team;
        public string role;

       public  DateTime joining = new DateTime();
    
    }

    //Printing all employee details
    public class PrintDetails()
    {
        public static void PrintAllDetails(Employee emp)
        {
            Console.WriteLine($"Name: {emp.name}");
            Console.WriteLine($"Gender: {emp.gender}");
            Console.WriteLine($"Team: {emp.team}");
            Console.WriteLine($"Manager: {emp.manager}");
            Console.WriteLine($"Role: {emp.role}");
            Console.WriteLine($"Joining Date: {emp.joining.ToString("MM-dd-yyyy")}");
            Console.WriteLine($"******************************************");

        }
    }

   
}