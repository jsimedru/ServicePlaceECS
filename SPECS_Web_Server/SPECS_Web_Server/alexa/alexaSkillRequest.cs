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
using SPECS_Web_Server.Data;

namespace SPECS_Web_Server.Controllers
{
    public class AlexaSkillRequest
    {
        private const string ALEXA_APPLICATION_ID = "amzn1.ask.skill.90cd2822-d0b2-4b14-bebe-8a14f4b44718";
        private SkillRequest intentRequest;

        public AlexaSkillRequest(SkillRequest _intentRequest)
        {
            intentRequest = _intentRequest;
        }
        public SkillResponse ProcessRequest(SkillRequest _skillRequest)
        {
            //TODO: Use Alexa.NET.Middleware to verify requests come from Amazon

            var intentRequest = _skillRequest.Request as IntentRequest;
            Models.User result;
            var speech = new Alexa.NET.Response.SsmlOutputSpeech();
            var response = new SkillResponse();

            using (var db = new AppDb())
            {
                db.Connection.OpenAsync();
                var query = new UserQuery(db);
                result = query.FindAlexaUser(_skillRequest.Session.User.UserId);
            }

            if (result != null)
            {
                if (intentRequest.Intent.Name.Equals("color_get"))
                {
                    if (intentRequest.Intent.Slots.ContainsKey("color"))
                    {
                        speech.Ssml = "<speak>Your color is " + result.Color + "</speak>";
                        response = ResponseBuilder.Tell(speech);
                    }
                }
                else if (intentRequest.Intent.Name.Equals("color_set"))
                {
                    if (intentRequest.Intent.Slots.ContainsKey("color"))
                    {
                        bool queryStatus;
                        Slot color = intentRequest.Intent.Slots.GetValueOrDefault("color");
                        using (var db = new AppDb())
                        {
                            db.Connection.OpenAsync();
                            var query = new UserQuery(db);
                            queryStatus = query.UpdateUserColorByAlexaID(result, color.Value);
                        }
                        if (queryStatus)
                        {
                            speech.Ssml = "<speak>Your color now set to " + color.Value + "</speak>";
                            //TODO: Call function to set user's color in db
                            response = ResponseBuilder.Tell(speech);
                        } else
                        {
                            speech.Ssml = "<speak>Please try again. Error 3</speak>";
                            response = ResponseBuilder.Tell(speech);
                        }
                        
                    }
                    
                }
            }
            else
            {
                speech.Ssml = "<speak>Please try again. Error 1</speak>";
                response = ResponseBuilder.Tell(speech);
            }
            return response;
        }
    }
}