using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class SubteamMembersChanged : CallbackEvent
    {
        public const string EventType = "subteam_members_changed";

        [JsonProperty("subteam_id",NullValueHandling = NullValueHandling.Ignore)]
        public string Subteam { get; set; }

        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string Team { get; set; }

        [JsonProperty("date_previous_update",NullValueHandling = NullValueHandling.Ignore)]
        public long? DatePreviousUpdate { get; set; }

        [JsonProperty("date_update",NullValueHandling = NullValueHandling.Ignore)]
        public long DateUpdate { get; set; }

        [JsonProperty("added_users",NullValueHandling = NullValueHandling.Ignore)]
        public string[] AddedUsers { get; set; }

        [JsonProperty("removed_users",NullValueHandling = NullValueHandling.Ignore)]
        public string[] RemovedUsers { get; set; }

        [JsonProperty("added_users_count",NullValueHandling = NullValueHandling.Ignore)]
        public int? AddedUsersCount { get; set; }

        [JsonProperty("removed_users_count",NullValueHandling = NullValueHandling.Ignore)]
        public int? RemovedUsersCount { get; set; }
    }
}