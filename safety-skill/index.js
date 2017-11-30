'use strict';

var Alexa = require('alexa-sdk');
var AWS = require('aws-sdk');
var twilio = require('twilio');

var accountSid = 'ACbfd1cdfeca56268e901a060afab370d4'; // Your Account SID from www.twilio.com/console
var authToken = '1b11a32283f190d5b66c3ec11e09ba34';   // Your Auth Token from www.twilio.com/console
var client = new twilio(accountSid, authToken);

const tableParams = {
    TableName: 'serviceplacecontacttesting',
    Key:{ "CustomerID": '0'  }
};

//Handlers contains the different intents
var handlers = {
    'messageintent' : function() {
        //var phoneNumber = this.event.request.intent.slots.phonenumber.value;
        this.response.speak("Sending message");
        this.emit(":responseReady");
    },

    'helpintent' : function(){
        getDynamoContacts(tableParams, result => {
            if(result.helppending == true){
                this.emit(":tell", 'You currently have a pending help request, if you wish to cancel please say, Alexa, ask serviceplace to cancel my help.');
            } else {
                var cardTitle = 'Help Requested!';
                var cardContent = 'We have sent a notification to ' + result.name + ' to assist. To check in on my progress say, Alexa, ask ServicePlace what is the status on my help.';
                var imageObj = {
                    smallImageUrl: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ_7Vj1EBy_CmfbXJwAsQ0w37WBimrSWFabG-mT3p1LsYPQH-vksA',
                    largeImageUrl: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ_7Vj1EBy_CmfbXJwAsQ0w37WBimrSWFabG-mT3p1LsYPQH-vksA'
                };

                this.emit(":tellWithCard", 'I have notified an emergency contact named ' + result.name +
                '. To check in on my progress say, Alexa, ask Serviceplace what is the status on my help.',
                cardTitle, cardContent, imageObj);
                sendSMSNotification(result.phone, 'Help requested for ' + result.name + ', please reply if you can assist.');
                updateHelpStatus(true);
            }
        });
    },  

    'helptypeintent' : function(){
        var helpType = this.event.request.intent.slots.emergencytype.value;
        if(helpType == 'Fire Department' || helpType == 'Police'){
            this.response.speak('I have contacted someone to help as I cannot do this myself. To check in on my progress say, Alexa, ask Serviceplace what is the status on my help.');
            sendSMSNotification('4802736800', 'Help requested for, please reply with yes or no. If yes, call help.');
        }
        //this.response.speak('To call the ' + helpType + ' dial 911');        
        this.emit(":responseReady");
    },

    'helpstatus' : function(){
        getDynamoContacts(tableParams, result => {
            if(result.helppending){
                this.emit(':tell', 'You help request is still pending. Please try again in a couple of minutes.');
            } else {
                this.emit(':tell', 'There is currently no help request pending.');
            }
        });
    },

    'cancelHelp' : function(){
        getDynamoContacts(tableParams, result => {
            if(result.helppending){
                this.emit(':tell', 'You help request is being canceled. To verify, please say, Alexa, ask Serviceplace what is my help status?');
                updateHelpStatus(false);
                sendSMSNotification(result.phone, result.name + '\'s help request has been canceled. Please verify with ' + result.name + ' before taking any further action.');
            } else {
                this.emit(':tell', 'There is currently no help request pending.');
            }
        });
    },

    'addemergencycontact' : function(){
        var emergencynumber = this.event.request.intent.slots.emergencynumber.value;
        
    },

    'listemergencycontacts' : function(){
        getDynamoContacts(tableParams, result => {
            var contacts = result.message;
            this.emit(':tell', 'The first person in your emergency contacts is ' + contacts);
        });
    }
}

exports.handler = function(event, context, callback){
    var alexa = Alexa.handler(event, context, callback);
    alexa.registerHandlers(handlers);
    //alexa.dynamoDBTableName = 'serviceplacecontacttesting';   Use to store session attribute info
    alexa.execute();
};


//Retrieve Phone number from dynamoDB
function getDynamoContacts(params, callback){
    var docClient = new AWS.DynamoDB.DocumentClient();
    docClient.get(params, (error, data) => {
        if (error) {
            console.error("Unable to read item. Error JSON:", JSON.stringify(error, null, 2));
        } else {
            console.log("GetItem succeeded:", JSON.stringify(data, null, 2));

            callback(data.Item);  // this particular row has an attribute called message

        }     
    })
}

//Update HelpStats entry of Customer
function updateHelpStatus(helpStatus){
    var docClient = new AWS.DynamoDB.DocumentClient();
    var helpStatusparams = {
        //Can we put var tableparams in here?
        TableName: 'serviceplacecontacttesting',
        Key:{ "CustomerID": '0'  },
        UpdateExpression:"set helppending = :hp",
        ExpressionAttributeValues:{
            ":hp":helpStatus
        },
        ReturnValues:"UPDATED_NEW"
    };

    docClient.update(helpStatusparams, (error, data) =>{
        if (error) {
            console.error("Unable to read item. Error JSON:", JSON.stringify(error, null, 2));
        } else {
            console.log("GetItem succeeded:", JSON.stringify(data, null, 2));
        }     
    });

}

//Send SMS
function sendSMSNotification(pnumTo, pmessage){
    client.messages.create({
    body: pmessage,
    to: '+1' + pnumTo,  // Text this number
    from: '+14805681131' // From a valid Twilio number
    })
    .then((message) => console.log(message.sid));

}

