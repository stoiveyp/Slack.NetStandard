using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    [AcceptedArray]
    public class Conversation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("purpose",NullValueHandling = NullValueHandling.Ignore)]
        public string Purpose { get; set; }

        [JsonProperty("member_count",NullValueHandling = NullValueHandling.Ignore)]
        public int? MemberCount { get; set; }

        [JsonProperty("created",NullValueHandling = NullValueHandling.Ignore)]
        public long? Created { get; set; }

        [JsonProperty("creator_id",NullValueHandling = NullValueHandling.Ignore)]
        public string CreatorId { get; set; }

        [JsonProperty("is_private",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPrivate { get; set; }

        [JsonProperty("is_archived",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsArchived { get; set; }

        [JsonProperty("is_general",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsGeneral { get; set; }

        [JsonProperty("last_activity_ts",NullValueHandling = NullValueHandling.Ignore)]
        public long LastActivityTimestamp { get; set; }

        [JsonProperty("is_ext_shared",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsExtShared { get; set; }

        [JsonProperty("is_global_shared",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsGlobalShared { get; set; }

        [JsonProperty("is_org_default",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsOrgDefault { get; set; }

        [JsonProperty("is_org_mandatory",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsOrgMandatory { get; set; }

        [JsonProperty("is_org_shared",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsOrgShared { get; set; }

        [JsonProperty("is_frozen",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsFrozen { get; set; }

        [JsonProperty("connected_teams_id",NullValueHandling = NullValueHandling.Ignore)]
        public string[] ConnectedTeamsId { get; set; }

        [JsonProperty("internal_team_ids_count",NullValueHandling = NullValueHandling.Ignore)]
        public int? InternalTeamIdsCount { get; set; }

        [JsonProperty("internal_team_ids_sample_team",NullValueHandling = NullValueHandling.Ignore)]
        public string InternalTeamIdsSampleTeam { get; set; }

        [JsonProperty("pending_connected_team_ids",NullValueHandling = NullValueHandling.Ignore)]
        public string[] PendingConnectedTeamIds { get; set; }

        [JsonProperty("is_pending_ext_shared",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPendingExtShared { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}
