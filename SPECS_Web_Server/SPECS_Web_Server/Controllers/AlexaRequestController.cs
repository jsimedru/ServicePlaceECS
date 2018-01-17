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
using System.Threading.Tasks;
using Alexa.NET.Request;

namespace SPECS_Web_Server.Controllers
{
    public class AlexaRequestController : Controller
    {


        //POST api/alexarequest
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SkillRequest body)
        {
            var speechlet = new AlexaSkillRequest(body);

            //Return built response from alexa/alexaSkills
            //FIX
            return new OkObjectResult(body);
            
        }
    }
    
}
