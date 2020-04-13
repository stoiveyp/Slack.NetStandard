using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class EmailDomainChanged:CallbackEvent
    {
        public const string EventType = "email_domain_changed";

        [JsonProperty("email_domain",NullValueHandling = NullValueHandling.Ignore)]
        public string EmailDomain { get; set; }
    }
}
