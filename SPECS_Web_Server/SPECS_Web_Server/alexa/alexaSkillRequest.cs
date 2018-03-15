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
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Threading.Tasks;

namespace SPECS_Web_Server.Controllers
{
    /// <summary>
    /// Process incoming alexa request, and route to appropriate entity TODO: Full Re-Implementation
    /// </summary>
    public class AlexaSkillRequest
    {
        //TODO: Move to proper storage location
        private const string ALEXA_APPLICATION_ID = "amzn1.ask.skill.18e1bdcd-32e1-444b-8ef2-336b371e2d82";
        private const string TWILIO_ACCOUNT_SID = "ACbfd1cdfeca56268e901a060afab370d4";
        private const string TWILIO_AUTH_TOKEN = "1b11a32283f190d5b66c3ec11e09ba34";
        private SkillRequest intentRequest;

        public AlexaSkillRequest(SkillRequest _intentRequest)
        {
            intentRequest = _intentRequest;
        }

        //TODO: Use Alexa.NET.Middleware to verify requests come from Amazon
        public SkillResponse ProcessRequest(SkillRequest _skillRequest)
        {
            Models.User result;
            var intentRequest = _skillRequest.Request as IntentRequest;
            var speech = new Alexa.NET.Response.SsmlOutputSpeech();
            var response = new SkillResponse();

            //Get User which triggered request
            using (var db = new AppDb())
            {
                db.Connection.OpenAsync();
                var query = new UserQuery(db);
                result = query.FindAlexaUser(_skillRequest.Session.User.UserId);
            }

            if (result != null)
            {
                switch (intentRequest.Intent.Name){
                    case "sendalert":
                        safetyAlert(result);
                        //Generate Alexa request
                        var safetyResponse = new Alexa.NET.Response.SsmlOutputSpeech();
                        safetyResponse.Ssml = "<speak>I have sent an alert to your emergency contact.</speak>";
                        response = ResponseBuilder.Tell(safetyResponse);
                        break;

                    default:
                        var defaultResponse = new Alexa.NET.Response.SsmlOutputSpeech();
                        defaultResponse.Ssml = "<speak>An error occured, please try again.</speak>";
                        response = ResponseBuilder.Tell(defaultResponse);
                        break;
                }
            }
            else
            {
                speech.Ssml = "<speak>Please try again. Error 1</speak>";
                response = ResponseBuilder.Tell(speech);
            }
            return response;
        }

        //TODO: Further develop Emergency Contact system & propery retrieve emergency contacts and contact first one on the list.
        private async void safetyAlert(Models.User user){
            TwilioClient.Init(TWILIO_ACCOUNT_SID, TWILIO_AUTH_TOKEN);
            try {
                //Send Message through Twilio API
                var message = await MessageResource.CreateAsync(
                    to: new PhoneNumber(user.Phone.ToString()),
                    from: new PhoneNumber("+16147675740"),
                    body: user.FirstName + " " + user.LastName + " has triggered an alert. Please get in contact.");

                Console.WriteLine(message.Sid);

            } catch (Exception e){
                Console.WriteLine(e.Message);
                Console.WriteLine(e);
            }
        }
    }
}