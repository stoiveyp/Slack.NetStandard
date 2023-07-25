using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.WebApi.Admin;

internal class ConversationInviteRequest
{
    [JsonProperty("channel_id")]
    public string ChannelId { get; set; }

    [JsonProperty("user_ids")] public List<string> UserIds { get; set; } = new();

    public bool ShouldSerializeUserIds() => UserIds?.Any() ?? false;
}