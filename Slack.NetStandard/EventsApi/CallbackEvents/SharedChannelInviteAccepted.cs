using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class SharedChannelInviteAccepted: CallbackEvent
    {
        public const string EventType = "shared_channel_invite_accepted";

        [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("authorizations", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(AuthorizationConverter))]
        public Authorization[] Authorizations { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public Channel Channel { get; set; }

        [JsonProperty("invite", NullValueHandling = NullValueHandling.Ignore)]
        public Invite Invite { get; set; }
    }
}