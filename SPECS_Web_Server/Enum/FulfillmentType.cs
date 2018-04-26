using System;
using System.Collections.Generic;
using Alexa.NET;
using Alexa.NET.Helpers;
using Alexa.NET.Request;
using Newtonsoft.Json;

namespace SPECS_Web_Server.Models
{
    public enum FulfillmentType
    {
        Critical,
        High,
        Medium,
        Low
    }
}