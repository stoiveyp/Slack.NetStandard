using Newtonsoft.Json;
using Slack.NetStandard.ApiCommon;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ResolvedApp
    {
        public class AppRequest
        {
            [JsonProperty("app")]
            public App App { get; set; }

            [JsonProperty("scopes", NullValueHandling = NullValueHandling.Ignore)]
            public Scope[] Scopes { get; set; }

            [JsonProperty("date_updated",NullValueHandling = NullValueHandling.Ignore)]
            public long DateUpdated { get; set; }

            [JsonProperty("last_resolved_by",NullValueHandling = NullValueHandling.Ignore)]
            public ResolutionInformation LastResolvedBy { get; set; }
        }
    }
}