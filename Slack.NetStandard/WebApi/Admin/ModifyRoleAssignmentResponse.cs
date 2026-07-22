using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class ModifyRoleAssignmentResponse : WebApiResponse
{
    [JsonProperty("rejected_entities",NullValueHandling = NullValueHandling.Ignore)]
    public RejectedEntity[] RejectedEntities { get; set; }
}