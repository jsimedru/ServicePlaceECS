using Newtonsoft.Json.Linq;
using SPECS_Web_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

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




        //Need authentication before hitting this method
       /* [HttpPost]
        public IHttpActionResult PostAlexa([FromBody] AlexaRequest incomingAlexaRequest)
        {
            var headers = Request.Headers;
            dynamic AlexaRequestObject = incomingAlexaRequest;
            try
            {
                //var contentType = headers.GetValues("Content-Type").First();
                //var host = headers.GetValues("Host").First();
                //var accept = headers.GetValues("Accept").First();
                //var acceptCharset = headers.GetValues("Accept-Charset").First();
                //var signatureCertChainUrl = headers.GetValues("SignatureCertChainUrl").First();
                SaveAlexaRequest(incomingAlexaRequest);
                return Ok<dynamic>(AlexaRequestObject);
            } catch (Exception e)
            {
                string error = e.Message;
                return BadRequest(error);
            }
        }

        private void SaveAlexaRequest(AlexaRequest incomingAlexaRequest)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["specsConnectionString"].ToString();
            queryString = "INSERT INTO specs.alexarequests (request_Data)" + "Values('" + incomingAlexaRequest + "')";
            sqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            sqlConnection.Open();
            sqlCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, sqlConnection);
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }

    }*/
}
