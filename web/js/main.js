jQuery.fn.updateWithText = function(text,speed)
{
	var dummy = $('<div/>').html(text);

	if ($(this).html() != dummy.html())
	{
		$(this).fadeOut(speed/2, function() {
			$(this).html(text);
			$(this).fadeIn(speed/2, function() {

			});
		});
	}
};

jQuery.fn.outerHTML = function(s) {
	return s ? this.before(s).remove() : jQuery("<p>").append(this.eq(0).clone()).html();
};

function roundVal(temp){
	return Math.round(temp * 10) /10;
}

jQuery(document).ready(function($) {

	var lastCompliment;
	var compliment;
	var doneWelcome = false;
	moment.locale(lang);

	(function updateTime()
	{
		var now = moment();
		var date = now.format('LLLL').split(' ',4);

		date = date[0] + ' ' + date[1] + ' ' + date[2] + ' ' + date[3];

		$('.date').updateWithText(date,1000);
		$('.time').updateWithText(now.format('HH') + ':' + now.format('mm'),1000);

		setTimeout(function() {
			updateTime();
		}, 60000);
	})();

	(function updateCurrentWeather()
	{
		var iconTable = {
			'01d':'wi-day-sunny',
			'02d':'wi-day-cloudy',
			'03d':'wi-cloudy',
			'04d':'wi-cloudy-windy',
			'09d':'wi-showers',
			'10d':'wi-rain',
			'11d':'wi-thunderstorm',
			'13d':'wi-snow',
			'50d':'wi-fog',
			'01n':'wi-night-clear',
			'02n':'wi-night-cloudy',
			'03n':'wi-night-cloudy',
			'04n':'wi-night-cloudy',
			'09n':'wi-night-showers',
			'10n':'wi-night-rain',
			'11n':'wi-night-thunderstorm',
			'13n':'wi-night-snow',
			'50n':'wi-night-alt-cloudy-windy'
		};

		$.getJSON('http://api.openweathermap.org/data/2.5/weather', weatherParams, function (json, textStatus) {
			var temp = roundVal(json.main.temp);
			var temp_min = roundVal(json.main.temp_min);
			var temp_max = roundVal(json.main.temp_max);

			var locationString = json.name + ', ' + json.sys.country;
			$('.location').updateWithText(locationString,1000);

			var wind = roundVal(json.wind.speed / 1.609344);
			console.log(json);
			var iconClass = iconTable[json.weather[0].icon];
			var icon = $('<span/>').addClass('icon').addClass('xdimmed').addClass('wi').addClass(iconClass);
			$('.temp').updateWithText(icon.outerHTML() + temp + '&deg', 1000);

			var now = new Date();
			var sunrise = new Date(json.sys.sunrise*1000).toTimeString().substring(0,5);
			var sunset = new Date(json.sys.sunset*1000).toTimeString().substring(0,5);

			var windString = '<span class="wi wi-strong-wind dimmed"></span> ' + wind + ' mph';
			var sunString = '<span class="wi wi-sunrise dimmed"></span>' + sunrise;
			if (json.sys.sunrise*1000 < now && json.sys.sunset*1000 > now){
				sunString = '<span class="wi wi-sunset dimmed"></span> ' + sunset;
			}

			$('.windsun').updateWithText(windString + ' ' + sunString, 1000);
		});

		setTimeout(function() {
			updateCurrentWeather();
		}, 60000);

	})();

	(function updateCompliment()
	{

		while(compliment == lastCompliment){	
			var date = new Date();
			var hour = date.getHours();

			if(hour >= 3 && hour < 12) compliments = morning;
			if (hour >= 12 && hour < 17) compliments = afternoon;
			if(hour >= 17 || hour < 3) compliments = evening;

			compliment = Math.floor(Math.random()*compliments.length);

		}

		if(doneWelcome === true){
			$('.message').updateWithText(compliments[compliment],4000);
		}
		else{
			$('.message').updateWithText(welcomeMessage[0],4000);
			doneWelcome = true;
		}
		lastComliment = compliment;

		setTimeout(function() {
			updateCompliment(true);
		},30000);
	})();
});


