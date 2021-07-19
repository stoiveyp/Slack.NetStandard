using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class InviteSharedResponse : WebApiResponse
    {
        [JsonProperty("invite_id",NullValueHandling = NullValueHandling.Ignore)]
        public string InviteId { get; set; }

        [JsonProperty("conf_code",NullValueHandling = NullValueHandling.Ignore)]
        public string ConfCode { get; set; }

        [JsonProperty("url",NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("is_legacy_shared_channel",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsLegacySharedChannel { get; set; }
    }
}