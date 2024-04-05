using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using VehicleDataManagerLibrary.Models;

namespace VehicleDataManagerLibrary
{
    public class VehicleDataManager
    {
        public List<Vehicle> GetData(string filePath)
        {
            string existingRecords = File.ReadAllText(filePath);
            var listVehicleRecords = JsonConvert.DeserializeObject<List<Vehicle>>(existingRecords);
            return listVehicleRecords;
        }
         
        public void SaveData(string filePath, List<Vehicle> list)
        {
            var convertedJson2 = JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, convertedJson2);
        }
    }
}
