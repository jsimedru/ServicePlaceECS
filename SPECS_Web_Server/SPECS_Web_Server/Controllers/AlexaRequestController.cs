using Newtonsoft.Json.Linq;
using SPECS_Web_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SPECS_Web_Server.Controllers
{
    public class AlexaRequestController : ApiController
    {
        

            [Route("alexa/alexa-session")]
            [HttpPost]
            public HttpResponseMessage SampleSession()
            {
            var speechlet = new alexaSkillsSpeechlet();
                return speechlet.GetResponse(Request);
            }

    }
    
}
