using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using AlexaSkillsKit;
using AlexaSkillsKit.Speechlet;
using AlexaSkillsKit.Authentication;
using AlexaSkillsKit.Helpers;
using AlexaSkillsKit.Slu;
using AlexaSkillsKit.UI;
using AlexaSkillsKit.Json;
using System.Diagnostics;

namespace SPECS_Web_Server.Controllers
{

    public class alexaSkillsSpeechlet : Speechlet
    {
        MySql.Data.MySqlClient.MySqlConnection sqlConnection;
        MySql.Data.MySqlClient.MySqlCommand sqlCommand;
        MySql.Data.MySqlClient.MySqlDataReader sqlReader;
        string queryString;

        //
        //BYPASS VALID AMAZON ALEXA REQUEST CHECKS
        //
        public override bool OnRequestValidation(
        SpeechletRequestValidationResult result, DateTime referenceTimeUtc, SpeechletRequestEnvelope requestEnvelope)
        {

            if (result != SpeechletRequestValidationResult.OK)
            {
                if (result.HasFlag(SpeechletRequestValidationResult.NoSignatureHeader))
                {
                    Debug.WriteLine("Alexa request is missing signature header, Overwriting as valid.");
                    return true;
                }
                if (result.HasFlag(SpeechletRequestValidationResult.NoCertHeader))
                {
                    Debug.WriteLine("Alexa request is missing certificate header, Overwriting as valid.");
                    return true;
                }
                if (result.HasFlag(SpeechletRequestValidationResult.InvalidSignature))
                {
                    Debug.WriteLine("Alexa request signature is invalid, Overwriting as valid.");
                    return true;
                }
                else
                {
                    if (result.HasFlag(SpeechletRequestValidationResult.InvalidTimestamp))
                    {
                        var diff = referenceTimeUtc - requestEnvelope.Request.Timestamp;
                        Debug.WriteLine("Alexa request timestamped '{0:0.00}' seconds ago making timestamp invalid, but continue processing.",
                            diff.TotalSeconds);
                    }
                    return true;
                }
            }
            else
            {
                var diff = referenceTimeUtc - requestEnvelope.Request.Timestamp;
                Debug.WriteLine("Alexa request timestamped '{0:0.00}' seconds ago.", diff.TotalSeconds);
                return true;
            }
        }

        public override SpeechletResponse OnIntent(IntentRequest intentRequest, Session session)
        {
            if (intentRequest.Intent.Name.Equals("color_get"))
            {
                string user_id = session.User.Id;
                bool userExists = AlexaUserLookup(user_id);
                if (userExists)
                {
                    string userColor = GetUserData(user_id, "color");
                    return ResponseBuilder("Your Color is " + userColor, false);
                } else
                {
                    return ResponseBuilder("Your Service Place account was not found.", false);
                }

            } else if (intentRequest.Intent.Name.Equals("color_set"))
            {
                if (session.Attributes.ContainsKey("color"))
                {
                    string color;
                    session.Attributes.TryGetValue("color", out color);
                    string user_id = session.User.Id;
                    bool userExists = AlexaUserLookup(user_id);
                    if (userExists)
                    {
                        UpdateUserData(user_id, "color", color);
                        return ResponseBuilder("Your Color has been updated to " + color, false);
                    } else
                    {
                        return ResponseBuilder("Your Service Place account was not found.", false);
                    }
                } else
                {
                    throw new SpeechletException("Invalid Intent");
                }
            } else 
            {
                throw new SpeechletException("Invalid Intent");
            }
        }

        public override SpeechletResponse OnLaunch(LaunchRequest launchRequest, Session session)
        {
            throw new NotImplementedException();
        }

        public override void OnSessionEnded(SessionEndedRequest sessionEndedRequest, Session session)
        {
            return;
        }

        public override void OnSessionStarted(SessionStartedRequest sessionStartedRequest, Session session)
        {
            return;
        }

        private void SaveAlexaRequest(IntentRequest incomingAlexaRequest)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["specsConnectionString"].ToString();
            queryString = "INSERT INTO specs.alexarequests (request_Data)" + "Values('" + incomingAlexaRequest + "')";
            sqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            sqlConnection.Open();
            sqlCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, sqlConnection);
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }

        private bool AlexaUserLookup(string alexaUserID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["specsConnectionString"].ToString();
            sqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            sqlConnection.Open();
            queryString = "SELECT * FROM specs.user_data WHERE id_alexa='" + alexaUserID + "'";
            sqlCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, sqlConnection);

            sqlReader = sqlCommand.ExecuteReader();
            bool userFound = false;
            if (sqlReader.HasRows) userFound = true;
            sqlConnection.Close();

            return userFound;
        }

        private string GetUserData(string alexaUserID, string requestedField)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["specsConnectionString"].ToString();
            sqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            sqlConnection.Open();
            queryString = "SELECT " + requestedField + " FROM specs.user_data WHERE id_alexa='" + alexaUserID + "'";
            sqlCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, sqlConnection);

            sqlReader = sqlCommand.ExecuteReader();
            string fieldData = "";
            if (sqlReader.HasRows && sqlReader.Read())
            {
                fieldData = sqlReader.GetString(sqlReader.GetOrdinal(requestedField));
            }
            sqlConnection.Close();

            return fieldData;
        }

        private bool UpdateUserData(string alexaUserID, string requestedField, string requestedValue)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["specsConnectionString"].ToString();
            sqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            sqlConnection.Open();
            queryString = "UPDATE specs.user_data SET " + requestedField + "='" + requestedValue + "' WHERE id_alexa='" + alexaUserID + "'";
            sqlCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, sqlConnection);
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
            return true;    //Need error checking
        }

        private SpeechletResponse ResponseBuilder(string speech, bool sessionContinue)
        {
            PlainTextOutputSpeech outputSpeech = new PlainTextOutputSpeech();
            outputSpeech.Text = speech;
            SpeechletResponse response = new SpeechletResponse();
            response.ShouldEndSession = sessionContinue;
            response.OutputSpeech = outputSpeech;
            response.Card = null;
            return response;
        }
    }
}