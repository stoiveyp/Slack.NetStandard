using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.WebApi.Conversations
{
    internal class CreateConversationRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_private",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPrivate { get; set; }

        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("user_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> UserIds { get; set; } = new List<string>();

        public bool ShouldSerializeUserIds() => UserIds?.Any() ?? false;
    }
}