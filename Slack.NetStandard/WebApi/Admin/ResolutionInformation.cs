using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class ResolutionInformation
    {
        [JsonProperty("actor_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ActorId { get; set; }

        [JsonProperty("actor_type",NullValueHandling = NullValueHandling.Ignore)]
        public string ActorType { get; set; }
    }
}