using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class SharedChannelInviteDeclined: CallbackEvent
    {
        public const string EventType = "shared_channel_invite_declined";

        [JsonProperty("declining_user", NullValueHandling = NullValueHandling.Ignore)]
        public User DecliningUser { get; set; }

        [JsonProperty("teams_in_channel", NullValueHandling = NullValueHandling.Ignore)]
        public Team[] TeamsInChannel { get; set; }

        [JsonProperty("declining_team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DecliningTeamId { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public Channel Channel { get; set; }

        [JsonProperty("invite", NullValueHandling = NullValueHandling.Ignore)]
        public Invite Invite { get; set; }
    }
}