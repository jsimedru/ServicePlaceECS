﻿using Newtonsoft.Json.Linq;
using SPECS_Web_Server.Data;
using SPECS_Web_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Security;
using Alexa.NET.Response;

namespace SPECS_Web_Server.Controllers
{
    [Route("api/[controller]")]
    public class AlexaRequestController : Controller
    {
        //POST api/alexarequest
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SkillRequest body)
        {
            AlexaSkillRequest request = new AlexaSkillRequest(body);
            SkillResponse response = request.ProcessRequest(body);
            //Return built response from alexa/alexaSkills
            //FIX
            return new OkObjectResult(response);

        }
    }

}
