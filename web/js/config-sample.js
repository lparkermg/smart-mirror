//All this maybe put into a json file at some point as to have it work with the backend api stuff.
//Change to config.js and add the APPID for the openweathermap API.
//Language
var lang = 'en';

//Weather Parameters.
var weatherParams = {
	'id':'2653144',
	'units':'metric',
	'lang':lang,
	'APPID':'AddTheIDHere'
};

//Compliments and Messages

//Name.
var name = 'Name Here';

//Messages. Switch to json format of messages.
var jsonLocation = '';

var welcomeMessage = ['Welcome to the Smart Mirror UI, ' + name + '.'];
var goodbyeMessage = ['See you later, ' + name + '.'];
var goodnightMessage = ['Goodnight, ' + name + '.'];

var morning = [ 'Good morning, ' + name + '.', 'Here\'s to a good day!', 'Did you sleep well?'];

var afternoon = ['Hello, ' + name + '.\n Is it me you\'re looking for?', 'Having a good day?', 'It\'s the afternoon!'];

var evening = ['Good evening, ' + name + '.'];

//Reddit Stuff
var redditPage = "gamedev";
