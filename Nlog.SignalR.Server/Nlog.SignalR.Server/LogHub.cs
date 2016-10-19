using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Nlog.SignalR.Server
{
    public class LogHub : Hub
    {
        public void SendLogMessage(string level, DateTime date, string message)
        {
            Clients.All.broadcastLogMessage(level, date, message);
        }
    }
}