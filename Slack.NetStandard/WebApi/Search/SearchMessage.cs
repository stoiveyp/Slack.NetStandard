using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.WebApi.Search
{
    public class SearchMessage:Message
    {
        [JsonProperty("iid",NullValueHandling = NullValueHandling.Ignore)]
        public string Iid { get; set; }

        [JsonProperty("previous",NullValueHandling = NullValueHandling.Ignore)]
        public SearchMessage Previous { get; set; }

        [JsonProperty("previous_2",NullValueHandling = NullValueHandling.Ignore)]
        public SearchMessage Previous2 { get; set; }
    }
}
