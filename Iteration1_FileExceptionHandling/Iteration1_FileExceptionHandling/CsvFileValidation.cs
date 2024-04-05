using System;
using System.Data;
using System.IO;
using Microsoft.VisualBasic.FileIO;




namespace Iteration1_FileExceptionHandling
{
    public class CsvFileValidation
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
                    Contents= Contents.Trim();
                    //Console.WriteLine(Contents);


                    // Checking for Valid CSV Format
                    String[] rows=Contents.Split('\n');

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

                        for(int i=1;i<record.Length; i++)
                        {
                            if (record[i] == ',')
                                count++;
                                
                        }

                        //Console.WriteLine(count);
                        try
                        {
                            if (count != comma) throw new Exception("Invalid Comma Characters");

                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Invalid CSV Format");

                        }  

                    }

                    //Console.WriteLine(); 

                    //Checking for missing Data values.
                    //int line = 1;
                    //for (int i = 0; i < rows.Length; i++)
                    //{
                    //    String[] record = rows[i].Split(",");

                    //    int feild = 1;
                    //    foreach(var feilds in record)
                    //    {
                         
                    //        try
                    //        {
                    //            if (feilds == "") throw new Exception("MissingDataException");

                    //        }
                    //        catch(Exception e)
                    //        {
                    //            Console.WriteLine($"Missing Value at {line}th record and {feild}th feild");
                    //        }
                    //        feild++;
                    //    }
                    //    line++;
                    //}

                    List<Employee> database = new List<Employee>();
                    for(int j=1;j<rows.Length;j++)
                    {
                        Employee emp = new Employee();
                        string[] feilds = rows[j].Split(",");
                        for (int i=0; i<feilds.Length; i++)
                        {
                            switch(i)
                            {
                                case 0:
                                    emp.name = feilds[i]; break;
                                case 1:
                                    emp.gender = feilds[i]; break;
                                case 2:
                                    emp.team = feilds[i]; break;
                                case 3:
                                    emp.manager = feilds[i]; break;
                                case 4:
                                    emp.role = feilds[i]; break;
                                case 5:
                                    //string d = (feilds[i].Length==9)?feilds[i].Substring(7):feilds[i].Substring(6);
                                    //Console.WriteLine($"{d}");
                                    //int year;
                                    //if(int.TryParse(d, out year))
                                    //{
                                    //emp.joining = year+2000; 

                                    //}
                                    emp.joining = feilds[i].Substring(feilds[i].Length-2);

                                    break;
                                    

                            }

                        }
                        database.Add(emp);
                    }

                    //for(int i=0; i<database.Count; i++)
                    //{
                    //    Console.WriteLine(database[i].name);
                    //     Console.WriteLine(database[i].gender);
                    //     Console.WriteLine(database[i].team);
                    //     Console.WriteLine(database[i].manager);
                    //     Console.WriteLine(database[i].role);
                    //     Console.WriteLine(database[i].joining);
                    
                    //}


                    Console.WriteLine("How would you like to search the employee details?");
                    Console.WriteLine("Enter 1 to search by name,");
                    Console.WriteLine("Enter 2 to search by manager,");
                    Console.WriteLine("Enter 3 to search by joining date,");
                   
                    int userInput= int.Parse(Console.ReadLine());

                    switch(userInput)
                    {
                        case 1:
                            Console.WriteLine("Enter the employee name:");
                            string inputName=Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter the manager name:");
                            string inputManager=Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter the joining date:");
                            int inputDate=int.Parse(Console.ReadLine());
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
