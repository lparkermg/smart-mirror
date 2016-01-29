using System;
using Newtonsoft.Json;

namespace weatherprocessor
{
	public class WeatherObject
	{
		public int CityId { get; private set;}
		public string CityName { get; private set;}
		public string Country { get; private set;}
		public int WeatherId { get; private set;}
		public string WeatherMain { get; private set;}
		public string WeatherDescription { get; private set;}
		public float CurrentTemp { get; private set;}
		public float MinTemp { get; private set;}
		public float MaxTemp { get; private set;}
		public int Humidity { get; private set;}
		public float WindSpeed { get; private set;}
		public float WindDirection { get; private set;}

		public WeatherObject (string weatherJson)
		{
			//Process the weather json into the object.
			var weatherStuff = JsonConvert.DeserializeObject<dynamic>(weatherJson);

			CityId = weatherStuff.id;
			CityName = weatherStuff.name;
			Country = weatherStuff.sys.country;
			WeatherId = weatherStuff.weather [0].id;
			WeatherMain = weatherStuff.weather [0].main;
			WeatherDescription = weatherStuff.weather [0].description;
			CurrentTemp = weatherStuff.main.temp;
			MinTemp = weatherStuff.main.temp_min;
			MaxTemp = weatherStuff.main.temp_max;
			Humidity = weatherStuff.main.humidity;
			WindSpeed = weatherStuff.wind.speed;
			WindDirection = weatherStuff.wind.deg;
		}
	}
}

