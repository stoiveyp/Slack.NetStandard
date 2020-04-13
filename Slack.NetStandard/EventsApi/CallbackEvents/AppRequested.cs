using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class AppRequested:CallbackEvent
    {
        public const string EventType = "app_requested";

        [JsonProperty("app_request")]
        public AppRequest AppRequest { get; set; }

    }
}
