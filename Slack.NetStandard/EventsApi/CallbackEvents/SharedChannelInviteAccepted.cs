using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class SharedChannelInviteAccepted: CallbackEvent
    {
        public const string EventType = "shared_channel_invite_accepted";

        [JsonProperty("approval_required",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ApprovalRequired { get; set; }

        [JsonProperty("teams_in_channel",NullValueHandling = NullValueHandling.Ignore)]
        public Team[] TeamsInChannel { get; set; }

        [JsonProperty("accepting_user",NullValueHandling = NullValueHandling.Ignore)]
        public User AcceptingUser { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public Channel Channel { get; set; }

        [JsonProperty("invite", NullValueHandling = NullValueHandling.Ignore)]
        public Invite Invite { get; set; }
    }
}