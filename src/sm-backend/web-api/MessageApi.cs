using System;
using Nancy;
using Nancy.Extensions;
using jsonmessagestorage;

namespace webapi
{
	public class MessageApi : NancyModule
	{
		private JsonStorer _jsonStorer = new JsonStorer ();
		public MessageApi () : base("Messages")
		{
			//Add to message lists.
			Post ["/Morning"] = _ => {
				var message = Request.Body.AsString();

				_jsonStorer.StoreNewMessage("Morning",message);

				return Response.AsText("Good Morning - Morning Message Adder.").WithStatusCode(200);
			};

			Post ["/Afternoon"] = _ => {
				var message = Request.Body.AsString();

				_jsonStorer.StoreNewMessage("Afternoon",message);

				return Response.AsText("Good Afternoon - Afternoon Message Adder.").WithStatusCode(200);
			};

			Post ["/Evening"] = _ => {
				var message = Request.Body.AsString();

				_jsonStorer.StoreNewMessage("Evening",message);

				return Response.AsText("Good Evening - Evening Message Adder.").WithStatusCode(200);
			};

			Post ["/Night"] = _ => {
				var message = Request.Body.AsString();

				_jsonStorer.StoreNewMessage("Night",message);

				return Response.AsText("Good Night - Night time Message Adder.").WithStatusCode(200);
			};

			Put ["/Welcome"] = _ => {
				var message = Request.Body.AsString ();

				_jsonStorer.StoreNewMessage ("Welcome", message);

				return Response.AsText ("Updated Welcome Message.").WithStatusCode (200);
			};

			Put ["/Goodbye"] = _ => {
				var message = Request.Body.AsString ();

				_jsonStorer.StoreNewMessage ("Goodbye", message);

				return Response.AsText ("Goodbye Message Updated.").WithStatusCode (200);
			};

			Put ["/Goodnight"] = _ => {
				var message = Request.Body.AsString ();

				_jsonStorer.StoreNewMessage ("Goodnight", message);

				return Response.AsText ("Goodnight Message Updated.").WithStatusCode (200);
			};

			//Get all the messages.
			Get ["/All"] = _ => {
				return Response.AsText("Getting All Messages.").WithStatusCode(200);
			};
		}
	}
}

