using System;
using System.Collections.Generic;
using Alexa.NET;
using Alexa.NET.Helpers;
using Alexa.NET.Request;
using Newtonsoft.Json;

namespace SPECS_Web_Server.Models
{
    public class AlexaSession
    {
        public int ID { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonConverter(typeof(MixedDateTimeConverter))]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("apiAccessToken")]
        public string ApiAccessToken { get; set; }

        [JsonProperty("apiEndpoint")]
        public string ApiEndpoint { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
        
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("deviceId")]
        public string DeviceID { get; set; }
        
        public string FulfillmentStatus { get; set; }
    }
}