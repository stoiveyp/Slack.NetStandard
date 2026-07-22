using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class WorkflowBotInvitedPayload
{
    [JsonProperty("channel_id")]
    public string ChannelId { get; set; }

    [JsonProperty("bot_user_id")]
    public string BotUserId { get; set; }
}