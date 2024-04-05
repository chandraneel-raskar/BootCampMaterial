using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileValidation
{
    public class PopulateObject
    {
        public static List<Employee> LoadCsvFileData(string[] rows) {
            List<Employee> database = new List<Employee>();
            for (int j = 1; j < rows.Length; j++)
            {
                Employee emp = new Employee();
                string[] fields = rows[j].Split(",");


                emp.name = fields[0];
                emp.gender = fields[1];
                emp.team = fields[2];
                emp.manager = fields[3];
                emp.role = fields[4];

                emp.joining = DateTime.Parse(fields[5]);

                database.Add(emp);


        
            }
            return database;
        }
    }
}
