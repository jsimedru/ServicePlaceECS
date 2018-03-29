<<<<<<< HEAD
﻿using System;
=======
using System;
>>>>>>> 712327e3e2453f47563feeedcc30a788b14ce3fb
using Newtonsoft.Json;
using SPECS_Web_Server.Data;

namespace SPECS_Web_Server.Models
{
    public class MedicalSensorData
    {
        [JsonIgnore]

<<<<<<< HEAD
        public int ID { get; set; }

        public int SpO2 { get; set; }

        public int ECG { get; set; }

        public int Pulse { get; set; }

        public int BloodPressure { get; set; }
    }
}
=======
        public long userID { get; set; }

        public float SpO2 { get; set; }

        public float ECG { get; set; }

        public int Pulse { get; set; }

        public string BloodPressure { get; set; }
    }
}
>>>>>>> 712327e3e2453f47563feeedcc30a788b14ce3fb
