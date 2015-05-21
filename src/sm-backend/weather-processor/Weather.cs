using System;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace weatherprocessor
{
	public class Weather
	{
		private string _currentWeatherUrl = "http://api.openweathermap.org/data/2.5/weather?id=";
		private string _currentWeatherFile = "CurrentWeather.json";

		public Weather ()
		{
		}

		public void DownloadCurrentWeather(string cityId)
		{
			using (var webClient = new WebClient())
			{
				SaveToJson(new WeatherObject(webClient.DownloadString (_currentWeatherUrl + cityId)));
			}
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

