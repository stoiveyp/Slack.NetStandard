using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class BotMessage : Message
    {
        public const string MessageSubType = "bot_message";

        [JsonProperty("bot_id",NullValueHandling = NullValueHandling.Ignore)]
        public string BotId { get; set; }

        [JsonProperty("username",NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("icons",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,string> Icons { get; set; }
    }
}