using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Alexa.NET;
using Alexa.NET.Helpers;
using Alexa.NET.Request;
using Newtonsoft.Json;

namespace SPECS_Web_Server.Models
{
    public enum FulfillmentStatus
    {
        [Display(Name = "Unfulfilled")]
        Unfulfilled,

        [Display(Name = "In-Progress")]
        InProgress,

        [Display(Name = "Fulfilled")]
        Fulfilled
    }
}