using System;
using System.Timers;
using weatherprocessor;

namespace logic
{
	public class LogicSystem
	{
		private Weather _weatherSystem;

		public LogicSystem ()
		{
			_weatherSystem = new Weather ();

			var weatherTimer = new Timer ();
			weatherTimer.Elapsed += (sender, EventArgs) => GetCurrentWeather ();
			weatherTimer.Interval = (1000 * 60);
			weatherTimer.Start ();
		}

		private void GetCurrentWeather()
		{
			Console.WriteLine ("Downloading Weather");
			_weatherSystem.DownloadCurrentWeather ("2653144");
		}
	}
}

