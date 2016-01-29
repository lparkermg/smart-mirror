using System;
using Nancy.Hosting.Self;

namespace webapi
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (var host = new NancyHost (new Uri ("http://localhost:9998/"))) {
				Console.WriteLine ("Setting Up Nancy Host.");
				host.Start ();
				Console.ReadLine ();
			}
		}
	}
}
