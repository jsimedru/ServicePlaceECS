﻿using System;
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
            ApplicationUser result;
            var intentRequest = _skillRequest.Request as IntentRequest;
            var speech = new Alexa.NET.Response.SsmlOutputSpeech();
            var response = new SkillResponse();

            //Get User which triggered request
            //var queryResult = _userManager.Users
              //  .Single(b => b.AlexaID == _skillRequest.Session.User.UserId);
              var queryResult = _userManager.Users;

            result = queryResult.Single(b => b.AlexaID == _skillRequest.Session.User.UserId);
            
            if (result != null)
            {
                //Generate fulfillment record
                Fulfillment fulfillment = new Fulfillment(){
                    ApplicationUser = result,
                    DeviceID = _skillRequest.Context.System.Device.DeviceID,
                    Timestamp = _skillRequest.Request.Timestamp,
                    Source = FulfillmentSource.Alexa,
                    Type = FulfillmentType.Informational,

                };

                //Store Alexa Intent History
                AlexaSession newSession = new AlexaSession(){
                    ApplicationUser = result,
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
                        safetyAlert(result);
                        //Generate Alexa request
                        var safetyResponse = new Alexa.NET.Response.SsmlOutputSpeech();
                        safetyResponse.Ssml = "<speak>I have sent an alert to your emergency contact.</speak>";
                        response = ResponseBuilder.Tell(safetyResponse);
                        newSession.Fulfillment.Status = FulfillmentStatus.Fulfilled;
                        newSession.Fulfillment.Category = FulfillmentCategory.Safety;
                        break;

                    case "displayMedicalSummaryIntent":
                        var medicalResponse = new Alexa.NET.Response.SsmlOutputSpeech();
                        MedicalSensorData medicalData = user.MedicalSensorData;
                        string healthString="";
                        if(medicalData != null){
                            try {
                                if(medicalData.healthy==true)
                                {
                                    healthString = "You are healthy!"
                                    medicalResponse.Ssml = "<speak>"+healthString+"</speak>";
                                }
                                else
                                {
                                    healthString="You aren't healthy."
                                    medicalResponse.Ssml = "<speak>"+healthString+"</speak>";
                                }

                            } catch (Exception e){
                                healthString = "error"
                                medicalResponse.Ssml = "<speak>"+healthString+"</speak>";
                            }
                        response = ResponseBuilder.Tell(medicalResponse);
                        //var finalResponse = ResponseBuilder.TellWithCard(medicalResponse, "Health Summary", healthString);
                        //return finalResponse;
                        //Generate Alexa request
                        newSession.FulfillmentStatus = "Fulfilled";
                        break;

                    default:
                        var defaultResponse = new Alexa.NET.Response.SsmlOutputSpeech();
                        defaultResponse.Ssml = "<speak>An error occured, please try again.</speak>";
                        response = ResponseBuilder.Tell(defaultResponse);
                        newSession.Fulfillment.Status = FulfillmentStatus.Unfulfilled;
                        break;
                }

                _context.Update(result);
                result.AlexaSessions.Add(newSession);
                result.Fulfillments.Add(fulfillment);
                //_userManager.UpdateAsync(result);
               
                _context.SaveChanges();
            }
            else
            {
                speech.Ssml = "<speak>Please try again. Error 1</speak>";
                response = ResponseBuilder.Tell(speech);
            }
            return response;
        }

        //TODO: Further develop Emergency Contact system & propery retrieve emergency contacts and contact first one on the list.
        private async void safetyAlert(ApplicationUser user){
            TwilioClient.Init(TWILIO_ACCOUNT_SID, TWILIO_AUTH_TOKEN);

            Family family = user.Family;
            if(family != null){
                for(int i = 0; i < family.Members.Count; i++){
                    try {
                        //Send Message through Twilio API
                        var message = await MessageResource.CreateAsync(
                            to: new PhoneNumber(family.Members.ElementAt(i).PhoneNumber.ToString()),
                            from: new PhoneNumber("+16147675740"),
                            body: "Hello, " + family.Members.ElementAt(i).FirstName + ". " + user.FirstName + " " + user.LastName + " has triggered an alert. Please get in contact.");
                        Console.WriteLine(message.Sid);

                    } catch (Exception e){
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e);
                    }
                }
            }
        }
        
    }
}