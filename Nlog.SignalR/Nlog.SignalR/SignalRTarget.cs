using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Nlog.SignalR
{
    [Target("SignalR")]
    public class SignalRTarget : TargetWithLayout
    {
        [RequiredParameter]
        public string Url { get; set; }
        [RequiredParameter]
        public string LogMethodName { get; set; }
        [RequiredParameter]
        public string HubName { get; set; }

        protected override void Write(LogEventInfo logEvent)
        {
            var writer = new SignalRWriter();

            writer.Write(new SignalRConfig
            {
                LogMethodName = LogMethodName,
                HubName = HubName,
                Url = Url
            }, logEvent).Wait();
        }
    }
}
