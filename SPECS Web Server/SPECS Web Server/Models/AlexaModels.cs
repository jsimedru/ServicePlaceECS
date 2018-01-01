using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//Work in Progress -- Using Dynamically binded objects for now

namespace SPECS_Web_Server.Models
{
    //Root Object
    public class AlexaRequest
    {
        public string version { get; set; }
        public Session session { get; set; }
        public Context context { get; set; }
        public Request request { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////
    //Session object && Session-Specific child Objects
    ////////////////////////////////////////////////////////////////////////
    public class Session
    {
        public bool @new { get; set; }
        public string sessionId { get; set; }
        public Application application { get; set; }
        public Dictionary<string, dynamic> attributes { get; set; }
        //public Attributes attributes { get; set; }
        public User user { get; set; }
    }


    ////////////////////////////////////////////////////////////////////////
    //Context object && Context-Specific child Objects
    ////////////////////////////////////////////////////////////////////////
    public class Context
    {
        public System System { get; set; }
        public AudioPlayer AudioPlayer { get; set; }
    }

    public class Device
    {
        public string deviceId { get; set; }
        public SupportedInterfaces supportedInterfaces { get; set; }
    }

    public class System
    {
        public Device device { get; set; }
        public Application application { get; set; }
        public User user { get; set; }
        public string apiEndpoint { get; set; }
        public string apiAccessToken { get; set; }
    }

    public class Permissions
    {
        public string consentToken { get; set; }
    }

    public class SupportedInterfaces
    {
        public AudioPlayer AudioPlayer { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////
    //Request object && Request-Specific child Objects
    ////////////////////////////////////////////////////////////////////////
    public class Request
    {
        public string type { get; set; }
        public string requestId { get; set; }

    }

    ////////////////////////////////////////////////////////////////////////
    //Shared child objects
    ////////////////////////////////////////////////////////////////////////
    public class Application
    {
        public string applicationId { get; set; }
    }

    public class AudioPlayer
    {
        public string playerActivity { get; set; }
        public string token { get; set; }
        public int offsetInMilliseconds { get; set; }
    }

    public class User
    {
        public string userId { get; set; }
        public string accessToken { get; set; }
        public Permissions permissions { get; set; }
    }

   




    //Models for basic Alexa request
    /*
        public class AlexaRequest
        {
            public Session session { get; set; }
            public Context context { get; set; }
        }

        public class Session
        {
            public bool _new { get; set; }
            public string sessionId { get; set; }
            public Application application { get; set; }
            public Attributes attributes { get; set; }
            public User user { get; set; }
        }

        public class Context
        {
            public System System { get; set; }
            public Application application { get; set; }
            public User user { get; set; }
            public string apiEndpoint { get; set; }
            public string apiAccessToken { get; set; }
        }

        public class Attributes
        {
            public string key { get; set; } //Will need to be updated later (attributes hold many custom key/value pairs)
        }

        public class System
        {
            public Device device { get; set; }
        }

        public class Device
        {
            public string deviceId { get; set; }
            public List<string> supportedInterfaces { get; set; }   //This will need to be updated later (Each Interface has sub items)
        }

        public class Application
        {
            public string applicationId { get; set; }
        }

        public class User
        {
            public string userId { get; set; }
            public string accessToken { get; set; }
        }
        */
}