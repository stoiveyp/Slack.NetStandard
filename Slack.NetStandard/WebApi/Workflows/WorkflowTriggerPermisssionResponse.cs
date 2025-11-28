using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.WebApi.Workflows
{
    public class WorkflowTriggerPermisssionResponse : WebApiResponse
    {
        [JsonProperty("permission_type")]
        public string PermissionType { get; set; }

        [JsonProperty("user_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string[] UserIds { get; set; }

        [JsonProperty("channel_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ChannelIds { get; set; }

        [JsonProperty("team_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string[] TeamIds { get; set; }

        [JsonProperty("org_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string[] OrgIds { get; set; }
    }

    public class WorkflowTriggerPermissionManipulationRequest
    {
        public WorkflowTriggerPermissionManipulationRequest(string triggerId)
        {
            TriggerId = triggerId;
        }

        [JsonProperty("trigger_id")]
        public string TriggerId { get; set; }

        [JsonProperty("user_ids")]
        public List<string> UserIds { get; set; } = new();

        [JsonProperty("channel_ids")]
        public List<string> ChannelIds { get; set; } = new();

        [JsonProperty("team_ids")]
        public List<string> TeamIds { get; set; } = new();

        [JsonProperty("org_ids")]
        public List<string> OrgIds { get; set; } = new();

        public bool ShouldSerializeUserIds() => UserIds?.Any() ?? false;
        public bool ShouldSerializeChannelIds() => ChannelIds?.Any() ?? false;
        public bool ShouldSerializeTeamIds() => TeamIds?.Any() ?? false;
        public bool ShouldSerializeOrgIds() => OrgIds?.Any() ?? false;
    }

    public class WorkflowTriggerPermissionRequest : WorkflowTriggerPermissionManipulationRequest
    {
        public WorkflowTriggerPermissionRequest(string triggerId, string permissionType) : base(triggerId)
        {
            PermissionType = permissionType;
        }

        [JsonProperty("permission_type")]
        public string PermissionType { get; set; }
    }
}
