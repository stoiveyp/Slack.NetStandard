using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class ListRoleAssignmentResponse : WebApiResponse<ResponseMetadataCursor>
{
    [JsonProperty("role_assignments", NullValueHandling = NullValueHandling.Ignore),AcceptedArray]
    public RoleAssignment[] RoleAssignments { get; set; }
}