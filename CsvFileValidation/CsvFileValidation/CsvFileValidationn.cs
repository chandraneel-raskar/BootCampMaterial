using System;
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic.FileIO;




namespace CsvFileValidation
{
    public class CsvFileValidationn
    {
        static void Main(string[] args)
        {
            // Starting with Try Catch block to handle FileNotFound Exception.
            try
            {
                // Reading the CSV File
                using (var reader = new StreamReader(@"C:\CSV\Sample CSV File.csv"))
                {
                    string Contents = reader.ReadToEnd();
                    Contents = Contents.Trim();


                    // Checking for Valid CSV Format
                    String[] rows = Contents.Split('\n');

                    // Counting Number of Commas per Line
                    string row = rows[0];
                    int comma = 0;
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (row[i] == ',')
                            comma++;

                    }

                    // Comparing no of commas in each row
                    foreach (var record in rows)
                    {
                        int count = 0;

                        for (int i = 1; i < record.Length; i++)
                        {
                            if (record[i] == ',')
                                count++;

                        }

                        //Console.WriteLine(count);
                        try
                        {
                            if (count != comma) throw new Exception("Invalid Comma Characters");

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid CSV Format");

                        }

                    }

                   
                    // Populating object with data

                   List<Employee> database= new List<Employee>();
                   database = PopulateObject.LoadCsvFileData(rows);

                    Console.WriteLine("How would you like to search the employee details?");
                    Console.WriteLine("Enter 1 to search by name,");
                    Console.WriteLine("Enter 2 to search by manager,");
                    Console.WriteLine("Enter 3 to search by joining date,");
                    Console.WriteLine("Enter 4 to print all the Data");

                     int userInput = int.Parse(Console.ReadLine());

                    switch (userInput)
                    {
                        case 1:
                            Console.WriteLine("Enter the employee name:");
                            string inputName = Console.ReadLine();
                            SearchEmployee.SearchByName(database,inputName);
                            break;
                        case 2:
                            Console.WriteLine("Enter the manager name:");
                            string inputManager = Console.ReadLine();
                            SearchEmployee.SearchByManager(database, inputManager);
                            break;
                        case 3:
                            Console.WriteLine("Enter the joining date:");
                            int inputDate = int.Parse(Console.ReadLine());
                            SearchEmployee.SearchByYear(database, inputDate);
                            break;
                        case 4:
                            foreach(Employee e in database)
                            {
                                PrintDetails.PrintAllDetails(e);
                            }
                            break;
                    }









                }
            }




            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
