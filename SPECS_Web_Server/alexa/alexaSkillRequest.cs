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
using SPECS_Web_Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AlexaSkillRequest(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SkillRequest _intentRequest)
        {
            intentRequest = _intentRequest;
            _context = context;
            _userManager = userManager;
        }

        //TODO: Use Alexa.NET.Middleware to verify requests come from Amazon
        public SkillResponse ProcessRequest(SkillRequest _skillRequest)
        {
            ApplicationUser user;
            var intentRequest = _skillRequest.Request as IntentRequest;
            var speech = new Alexa.NET.Response.SsmlOutputSpeech();
            var response = new SkillResponse();

            //Get User which triggered request
            //var queryResult = _userManager.Users
              //  .Single(b => b.AlexaID == _skillRequest.Session.User.UserId);
              var queryResult = _userManager.Users;

            var queryuser = queryResult.Single(b => b.AlexaID == _skillRequest.Session.User.UserId);
            
            user = _context.Users.Include(ApplicationUser => ApplicationUser.AlexaSessions)
                    .Include(ApplicationUser => ApplicationUser.MedicalSensorData)
                    .Include(ApplicationUser => ApplicationUser.Fulfillments)
                    .Single(u => u.Id == queryuser.Id);

            if (user != null)
            {
                //Generate fulfillment record
                Fulfillment fulfillment = new Fulfillment(){
                    DeviceID = _skillRequest.Context.System.Device.DeviceID,
                    Timestamp = _skillRequest.Request.Timestamp,
                    Source = FulfillmentSource.Alexa
                };

                //Generate Alexa Intent History
                AlexaSession newSession = new AlexaSession(){
                    ApplicationUser = user,
                    Type = _skillRequest.Request.Type,
                    RequestId = _skillRequest.Request.RequestId,
                    Locale = _skillRequest.Request.Locale,
                    Timestamp = _skillRequest.Request.Timestamp,
                    ApiAccessToken = _skillRequest.Context.System.ApiAccessToken,
                    ApiEndpoint = _skillRequest.Context.System.ApiEndpoint,
                    UserId = _skillRequest.Session.User.UserId,
                    DeviceID = _skillRequest.Context.System.Device.DeviceID,
                    Fulfillment = fulfillment
                };

                switch (intentRequest.Intent.Name){
                    case "sendalert":
                        return safetyIntent(user, fulfillment, newSession);

                    case "displayMedicalSummaryIntent":
                        return medicalDataIntent(user, fulfillment, newSession);

                    case "requestRide":
                        return requestRideIntent(intentRequest.Intent.Slots, user, fulfillment, newSession);

                    default:
                        var defaultResponse = new Alexa.NET.Response.SsmlOutputSpeech();
                        defaultResponse.Ssml = "<speak>An error occured, please try again.</speak>";
                        response = ResponseBuilder.Tell(defaultResponse);
                        newSession.Fulfillment.Status = FulfillmentStatus.Unfulfilled;
                        return response;
                }
            }
            else
            {
                speech.Ssml = "<speak>Please try again. Error 1</speak>";
                response = ResponseBuilder.Tell(speech);
            }
            return response;

        }

        private SkillResponse requestRideIntent(Dictionary<string, Alexa.NET.Request.Slot> slots, ApplicationUser user, Fulfillment fulfillment, AlexaSession session)
        {
            Slot daySlot = slots["day"];
            Slot timeSlot = slots["time"];
            fulfillment.Note = "Ride requested. " + daySlot.Value + " " + timeSlot.Value;
            fulfillment.Type = FulfillmentType.Medium;
            fulfillment.Category = FulfillmentCategory.Community;
            fulfillment.Status = FulfillmentStatus.Unfulfilled;

            user.AlexaSessions.Add(session);
            user.Fulfillments.Add(fulfillment);
            _context.SaveChanges();

            //Generate Alexa request
            var safetyResponse = new Alexa.NET.Response.SsmlOutputSpeech();
            safetyResponse.Ssml = "<speak>I have entered a fulfillment request for a ride. You should receive a confirmation in the next 24 hours for your ride" 
                + " on " + daySlot.Value + " " + timeSlot.Value + "</speak>";
            return ResponseBuilder.Tell(safetyResponse);
        }

        private SkillResponse safetyIntent(ApplicationUser user, Fulfillment fulfillment, AlexaSession session){
            sendsafetyAlert(user);
            //Update skill-specific fulfillment info
            fulfillment.Note = "Alert sent to Emergency Contact";
            fulfillment.Type = FulfillmentType.High;
            fulfillment.Category = FulfillmentCategory.Safety;
            fulfillment.Status = FulfillmentStatus.Fulfilled;

            user.AlexaSessions.Add(session);
            user.Fulfillments.Add(fulfillment);
            _context.SaveChanges();

            //Generate Alexa request
            var safetyResponse = new Alexa.NET.Response.SsmlOutputSpeech();
            safetyResponse.Ssml = "<speak>I have sent an alert to your emergency contact.</speak>";
            return ResponseBuilder.Tell(safetyResponse);
        }

        private SkillResponse medicalDataIntent(ApplicationUser user, Fulfillment fulfillment, AlexaSession session){
            //Update skill-specific fulfillment info
            fulfillment.Note = "User requested Medical Data Update";
            fulfillment.Category = FulfillmentCategory.Safety;
            fulfillment.Status = FulfillmentStatus.Fulfilled;

            user.AlexaSessions.Add(session);
            user.Fulfillments.Add(fulfillment);
            _context.SaveChanges();

            var medicalResponse = new Alexa.NET.Response.SsmlOutputSpeech();
            MedicalSensorData medicalData = user.MedicalSensorData.Last();
            string healthString="";
            if(medicalData != null){
                if(medicalData.health==true)
                {
                    healthString = "You are healthy!";
                    medicalResponse.Ssml = "<speak>"+healthString+"</speak>";
                }
                else
                {
                    healthString="You aren't healthy.";
                    medicalResponse.Ssml = "<speak>"+healthString+"</speak>";
                }

                return ResponseBuilder.Tell(medicalResponse);                            
            } else {
                medicalResponse.Ssml = "<speak>"+ "An error occured, please try again." + "</speak>"; 
            }
            return ResponseBuilder.Tell(medicalResponse);
        }



        //TODO: Further develop Emergency Contact system & propery retrieve emergency contacts and contact first one on the list.
        private async void sendsafetyAlert(ApplicationUser appuser){
            TwilioClient.Init(TWILIO_ACCOUNT_SID, TWILIO_AUTH_TOKEN);
                try {
                    //Send Message through Twilio API
                    var message = await MessageResource.CreateAsync(
                        to: new PhoneNumber(appuser.EmergencyContact),
                        from: new PhoneNumber("+16147675740"),
                        body: "Hello, " + appuser.FirstName + " " + appuser.LastName + " has triggered an alert. Please get in contact.");
                    Console.WriteLine(message.Sid);

                } catch (Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e);
                }
            }
    }
}