using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    class DeleteRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("ts")]
        public string Timestamp { get; set; }

        [JsonProperty("as_user", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AsUser { get; set; }
    }

    class DeleteScheduledMessageRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("scheduled_message_id")]
        public string ScheduledMessageId { get; set; }

        [JsonProperty("as_user", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AsUser { get; set; }
    }
}
