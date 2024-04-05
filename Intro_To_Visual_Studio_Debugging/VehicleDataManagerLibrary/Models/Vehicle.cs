using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleDataManagerLibrary.Models
{
    public class Vehicle
    {
        public string VehicleId { get; set; }
        public string DisplayName { get; set; }
        public string RegistrationNumber { get; set; }
        public string VIN { get; set; }
        public string ContactNumber { get; set; }        
        public string VehicleModel { get; set; } 
        public string TrackingUnitId { get; set; } 
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; } 

    }
}
