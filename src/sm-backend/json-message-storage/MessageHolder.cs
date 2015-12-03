using System;
using System.Collections.Generic;

namespace jsonmessagestorage
{
	public class MessageHolder
	{
		public string WelcomeMessage;
		public string GoodbyeMessage;
		public string GoodnightMessage;
		public List<string> Morning = new List<string>();
		public List<string> Afternoon = new List<string>();
		public List<string> Evening = new List<string>();
		public List<string> Night = new List<string>();

		public MessageHolder ()
		{
			
		}
	}
}

