'use strict';

var Express = require('express');
var https = require('https');
var bodyParser = require('body-parser');
var fs = require('fs');
var Alexa = require('alexa-sdk');
var Verifier_Alexa = require('alexa-verifier-middleware');

const cert_info = {
    key: fs.readFileSync(''),
    cert: fs.readFileSync(''),
    ca: fs.readFileSync('')
};

var jsonParser = bodyParser.json();
var app = express();
//Router for alexa requests
var alexaRouter = Express.Router();

//specs.serviceplace.org/skills - route to alexaRouter
app.use('/skills', alexaRouter);    
alexaRouter.use(Verifier_Alexa);    //Verify Requests from Amazon
alexaRouter.use(jsonParser);

/*
Alexa Router
*/
//specs.serviceplace.org/skills/
alexaRouter.post('/', (req, res) => {
    console.log('Alexa Request Received');
    //Route to handlers to process request, get responses from handler, send back to Alexa Services
});  
