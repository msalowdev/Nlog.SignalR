using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace NLog.SignalR.Server.DisplayConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var hubConnection = new HubConnection("http://localhost:54278/");

            var hub = hubConnection.CreateHubProxy("LogHub");
            hub.On<string, DateTime ,string>("broadcastLogMessage", (level, date, message) =>
            {
                Console.WriteLine($"Date: {date}, Level: {level}, Message: {message}");
            });

            hubConnection.Start().Wait();

            Console.WriteLine("Display Console Connected and ready");

            Console.ReadLine();
        }
    }
}
