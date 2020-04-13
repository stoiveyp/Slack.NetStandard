using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Slack.NetStandard.EventsApi
{
    public class AppRateLimited:Event
    {
        public const string EventType = "app_rate_limited";
        [JsonProperty("token",NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

        [JsonProperty("team_id")]
        public string Team { get; set; }

        [JsonProperty("minute_rate_limited")]
        public long MinuteRateLimited { get; set; }

        [JsonProperty("api_app_id")]
        public string ApiAppId { get; set; }
    }
}
