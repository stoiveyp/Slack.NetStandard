using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class AppUninstalled:CallbackEvent
    {
        public const string EventType = "app_uninstalled";
    }
}
