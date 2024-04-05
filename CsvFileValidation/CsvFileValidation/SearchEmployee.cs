using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileValidation
{
    public class SearchEmployee
        {

            public static void SearchByName(List<Employee> db, string userInput)
            {
                for (int i = 0; i < db.Count; i++)
                {
                string name = db[i].name.ToLower();
                userInput = userInput.ToLower();
                    if (name.Contains(userInput))
                    {
                        PrintDetails.PrintAllDetails(db[i]);
                    }
                }
            }

            public static void SearchByManager(List<Employee> db, string userInput)
            {
                for (int i = 0; i < db.Count; i++)
            {
                string manager = db[i].manager.ToLower();
                userInput = userInput.ToLower();
                if (manager.Contains(userInput))
                    {
                        PrintDetails.PrintAllDetails(db[i]);
                    }
                }
            }

            public static void SearchByYear(List<Employee> db, int userInput)
            {
                for (int i = 0; i < db.Count; i++)
                {
                    if ((int)db[i].joining.Year == userInput)
                    {
                        PrintDetails.PrintAllDetails(db[i]);
                    }
                }
            }

        }
    }

