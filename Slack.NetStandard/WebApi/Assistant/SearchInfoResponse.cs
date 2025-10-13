using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.WebApi.Assistant
{
    public class SearchInfoResponse : WebApiResponse
    {
        [JsonProperty("is_ai_search_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsIaSearchEnabled { get; set; }
    }
}
