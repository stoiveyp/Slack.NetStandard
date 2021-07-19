using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class SharedChannelInviteApproved: CallbackEvent
    {
        public const string EventType = "shared_channel_invite_approved";

        [JsonProperty("approving_user", NullValueHandling = NullValueHandling.Ignore)]
        public User ApprovingUser { get; set; }

        [JsonProperty("teams_in_channel", NullValueHandling = NullValueHandling.Ignore)]
        public Team[] TeamsInChannel { get; set; }

        [JsonProperty("approving_team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ApprovingTeamId { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public Channel Channel { get; set; }

        [JsonProperty("invite", NullValueHandling = NullValueHandling.Ignore)]
        public Invite Invite { get; set; }
    }
}