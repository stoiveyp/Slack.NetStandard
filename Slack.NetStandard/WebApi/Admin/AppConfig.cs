using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Admin
{
    public class AppConfig
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("workflow_auth_strategy",NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public WorkflowAuthStrategy? WorkflowAuthStrategy { get; set; }

        [JsonProperty("domain_restrictions",NullValueHandling = NullValueHandling.Ignore)]
        public DomainRestrictions DomainRestrictions { get; set; }
    }
}
