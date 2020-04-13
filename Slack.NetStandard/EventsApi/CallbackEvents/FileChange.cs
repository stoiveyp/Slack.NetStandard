using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class FileChange:CallbackEvent
    {
        public const string EventType = "file_change";
    }
}
