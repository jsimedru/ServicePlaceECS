using System;
using Newtonsoft.Json;
using SPECS_Web_Server.Data;

namespace SPECS_Web_Server.Models
{
    public class MedicalSensorData
    {
        [JsonIgnore]

        public int ID { get; set; }

        public int SpO2 { get; set; }

        public int ECG { get; set; }

        public int Pulse { get; set; }

        public int BloodPressure { get; set; }
    }
}
