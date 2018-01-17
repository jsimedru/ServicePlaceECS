using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Alexa.NET;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Alexa.NET.Request.Type;

namespace SPECS_Web_Server.Controllers
{
    public class AlexaSkillRequest
    {
        private const string ALEXA_APPLICATION_ID = "amzn1.ask.skill.90cd2822-d0b2-4b14-bebe-8a14f4b44718";
        
        public static SkillResponse ProcessRequest(SkillRequest _intentRequest)
        {
            var intentRequest = _intentRequest.Request as IntentRequest;
            var speech = new Alexa.NET.Response.SsmlOutputSpeech();
            var response = new SkillResponse();
            if (intentRequest.Intent.Name.Equals("color_get"))
            {
                speech.Ssml = "<speak>Your color is blue</speak>";
                response = ResponseBuilder.Tell(speech);
            } else if(intentRequest.Intent.Name.Equals("color_set")) {
                speech.Ssml = "<speak>Your color set to blue</speak>";
                response = ResponseBuilder.Tell(speech);
            } else
            {
                speech.Ssml = "<speak>Please try again</speak>";
                response = ResponseBuilder.Tell(speech);
            }
            return response;
        }
    }
}