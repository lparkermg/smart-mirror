using System;

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
		}
	}
}

