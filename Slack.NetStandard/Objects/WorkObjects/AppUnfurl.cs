using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class AppUnfurl
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("bot_id", NullValueHandling = NullValueHandling.Ignore)] 
        public string BotId { get; set; }

        [JsonProperty("bot_team_id", NullValueHandling = NullValueHandling.Ignore)] 
        public string BotTeamId { get; set; }

        [JsonProperty("app_unfurl_url", NullValueHandling = NullValueHandling.Ignore)] 
        public string AppUnfurlUrl { get; set; }

        [JsonProperty("is_app_unfurl", NullValueHandling = NullValueHandling.Ignore)] 
        public bool IsAppUnfurl { get; set; }

        [JsonProperty("fallback", NullValueHandling = NullValueHandling.Ignore)] 
        public string Fallback { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)] 
        public string Text { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)] 
        public string Title { get; set; }

        [JsonProperty("title_link", NullValueHandling = NullValueHandling.Ignore)] 
        public string TitleLink { get; set; }

        [JsonProperty("service_name", NullValueHandling = NullValueHandling.Ignore)] 
        public string ServiceName { get; set; }

        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore), AcceptedArray] 
        public AppUnfurlField[] Fields { get; set; }
    }
}
