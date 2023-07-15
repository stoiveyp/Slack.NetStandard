using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using Slack.NetStandard.EventsApi.CallbackEvents;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Admin
{
    public class SetTeamsRequest
    {
        public SetTeamsRequest(string channelId)
        {
            Channel = channelId;
        }

        [JsonProperty("channel_id")]
        public string Channel { get; set; }

        [JsonProperty("org_channel",NullValueHandling = NullValueHandling.Ignore)]
        public bool? OrgChannel { get; set; }

        [JsonProperty("target_team_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> TargetTeams { get; set; } = new List<string>();

        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string Team { get; set; }

        public bool ShouldSerializeTargetTeams() => TargetTeams?.Any() ?? false;
    }
}
