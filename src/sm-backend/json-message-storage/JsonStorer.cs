using System;
using System.IO;
using Newtonsoft.Json;

namespace jsonmessagestorage
{
	public class JsonStorer
	{
		private string _fileLocation = "messages.json";

		public JsonStorer ()
		{
			
		}

		public void StoreNewMessage(string area, string message)
		{
			var messages = LoadMessages ();

			switch(area){
			case("Morning"):
				messages.Morning.Add (message);
				break;
			case("Afternoon"):
				messages.Afternoon.Add (message);
				break;
			case("Evening"):
				messages.Evening.Add (message);
				break;
			case("Night"):
				messages.Night.Add (message);
				break;
			case("Welcome"):
				messages.WelcomeMessage = message;
				break;
			case("Goodbye"):
				messages.GoodbyeMessage = message;
				break;
			case("Goodnight"):
				messages.GoodnightMessage = message;
				break;
			}

			SaveMessagesToJson (messages);
		}

		private MessageHolder LoadMessages()
		{
			var loadedFile = "";
			if (File.Exists (_fileLocation))
				using (var fileStream = new FileStream (_fileLocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
					using (TextReader tr = new StreamReader (fileStream)) {
						loadedFile = tr.ReadToEnd ();
					}
				}
			else
				return new MessageHolder ();

			return JsonConvert.DeserializeObject<MessageHolder> (loadedFile);
		}

		private void SaveMessagesToJson(MessageHolder messages)
		{
			string strMessages = JsonConvert.SerializeObject (messages);

			using(var file = File.OpenWrite(_fileLocation))
			{
				using (var textWriter = new StreamWriter(file))
				{
					textWriter.Write (strMessages);
					textWriter.Flush ();
				}
			}
		}
	}
}

