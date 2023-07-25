using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class CreateConversationResponse : WebApiResponse
{
    [JsonProperty("channel_id",NullValueHandling = NullValueHandling.Ignore)]
    public string ChannelId { get; set; }
}