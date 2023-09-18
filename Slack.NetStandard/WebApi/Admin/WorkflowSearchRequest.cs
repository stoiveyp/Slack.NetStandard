using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Admin
{
    public class WorkflowSearchRequest
    {
        [JsonProperty("app_id",NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("collaborator_ids", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> CollaboratorIds { get; set; } = new();

        [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty("no_collaborators",NullValueHandling = NullValueHandling.Ignore)]
        public bool? NoCollaborators { get; set; }

        [JsonProperty("num_trigger_ids",NullValueHandling = NullValueHandling.Ignore)]
        public int? NumTriggerIds { get; set; }

        [JsonProperty("query",NullValueHandling = NullValueHandling.Ignore)]
        public string Query { get; set; }

        [JsonProperty("sort",NullValueHandling = NullValueHandling.Ignore)]
        public string Sort { get; set; }

        [JsonProperty("sort_dir",NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public SortDirection? SortDirection { get; set; }

        [JsonProperty("source",NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        public bool ShouldSerializeCollaboratorIds() => CollaboratorIds?.Any() ?? false;
    }
}
