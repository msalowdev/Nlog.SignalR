using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace NLog.SignalR.Server.SendConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var hub =
          ConnectToLogMessage();

            Console.WriteLine("Connected to hub and read to send messages");

            var stringValue =
            Console.ReadLine();

            while (stringValue != "quit")
            {
                SendMessage(hub, stringValue);

                stringValue = Console.ReadLine();
            }
        }


        private static IHubProxy ConnectToLogMessage()
        {

            var hubConnection = new HubConnection("http://localhost:54278/");

            var hub = hubConnection.CreateHubProxy("LogHub");

            hubConnection.Start().Wait();
            return hub;
        }

        private static void SendMessage(IHubProxy hub, string message)
        {

            hub.Invoke("SendLogMessage", "Error", DateTime.Now, message).Wait();

        }
    }
}
