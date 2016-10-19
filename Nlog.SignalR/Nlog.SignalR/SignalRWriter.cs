using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using NLog;

namespace Nlog.SignalR
{
    public class SignalRWriter
    {

        public async Task Write(SignalRConfig config, LogEventInfo logEvent)
        {
            try
            {
                using (var hubConnection = new HubConnection(config.Url))
                {
                    var hub = hubConnection.CreateHubProxy(config.HubName);

                    await hubConnection.Start();
                    await hub.Invoke(config.LogMethodName, logEvent.Level.Name, logEvent.TimeStamp,
                            logEvent.FormattedMessage);
                    hubConnection.Stop();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //do nothing
            }
        }
    }
}
