using System;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace weatherprocessor
{
	public class Weather
	{
		private WeatherObject _currentWeather;
		private string _currentWeatherUrl = "http://api.openweathermap.org/data/2.5/weather?id=";
		private string _currentWeatherFile = "..\\CurrentWeather.json";

		public Weather ()
		{
		}

		public string DownloadCurrentWeather(string cityId)
		{
			using (var webClient = new WebClient())
			{
				SaveToJson(new WeatherObject(webClient.DownloadString (_currentWeatherUrl + cityId)));
			}
		}

		public string DownloadFivedayWeather(string cityId)
		{
			//Download the Fiveday weather forecast using the City ID. Future Release Stuff...

		}
			
		private void SaveToJson(WeatherObject currentWeather)
		{
			string serializedData = JsonConvert.SerializeObject(currentWeather);

			using(var file = File.OpenWrite(_currentWeatherFile))
			{
				using(var textWriter = new StreamWriter(file))
				{
					textWriter.Write (serializedData);
					textWriter.Flush ();
				}
			}
		}
	}
}

