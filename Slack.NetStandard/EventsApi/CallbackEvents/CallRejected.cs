using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class CallRejected:CallbackEvent
    {
        public const string EventType = "call_rejected";
    }
}
