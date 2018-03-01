using System;
using Newtonsoft.Json;
using SPECS_Web_Server.Data;

namespace SPECS_Web_Server.Models
{
    public class MedicalSensorData
    {
        [JsonIgnore]

        public int userID { get; set; }

        public float SpO2 { get; set; }

        public float ECG { get; set; }

        public int Pulse { get; set; }

        public string BloodPressure { get; set; }
    }
}