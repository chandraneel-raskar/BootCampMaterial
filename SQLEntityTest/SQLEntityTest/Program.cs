using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SQLEntityTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=MIC348\SQLEXPRESS;Initial Catalog=new_database;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection Established...");

                //Create
                //Console.WriteLine("Enter city, lat, long, city code");
                //string city = Console.ReadLine();
                //int lat = int.Parse(Console.ReadLine());
                //int longi = int.Parse(Console.ReadLine());
                //int cityCode = int.Parse(Console.ReadLine());

                //string insertQuery = "INSERT INTO dbo.city (city_name,lat,long,country_id) VALUES ( '"+ city + "'," + lat + "," + longi + "," + cityCode + ");";
                //Console.WriteLine(insertQuery);

                //SqlCommand command = new SqlCommand(insertQuery,sqlConnection);
                //command.ExecuteNonQuery();
                //Console.WriteLine("Data Inserted");

                // Read

                //string displayQuery = "SELECT * FROM dbo.city;";
                //SqlCommand displayCommand = new SqlCommand(displayQuery,sqlConnection);
                //SqlDataReader reader = displayCommand.ExecuteReader();

                //while(reader.Read())
                //{
                //    Console.Write(reader.GetValue(0).ToString()+",");
                //    Console.Write((reader.GetValue(1).ToString()).Trim()+",");
                //    Console.Write(reader.GetValue(2).ToString()+",");
                //    Console.Write(reader.GetValue(3).ToString()+",");
                //    Console.Write(reader.GetValue(4).ToString()+",");
                //    Console.WriteLine("---------------------------------");
                //}
                string Query = "  BEGIN\r\n   IF NOT EXISTS\r\n   (\r\n\t\tSELECT * FROM city WHERE id=8\r\n\t)\r\n\tTHROW 50001,'Entry Not Found',0;\r\nEND";

                SqlCommand command = new SqlCommand(Query, sqlConnection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
