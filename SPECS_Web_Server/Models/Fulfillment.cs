using System;
using System.Collections.Generic;
using Alexa.NET;
using Alexa.NET.Helpers;
using Alexa.NET.Request;
using Newtonsoft.Json;

namespace SPECS_Web_Server.Models
{
    public class Fulfillment
    {
        public int ID { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public FulfillmentType Type { get; set; }

        public FulfillmentCategory Category { get; set; }

        [JsonConverter(typeof(MixedDateTimeConverter))]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        public string DeviceID { get; set; }
        
        public FulfillmentStatus Status { get; set; }

        public string Note { get; set; }
    }
}