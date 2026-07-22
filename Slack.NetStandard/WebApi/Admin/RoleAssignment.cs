using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class RoleAssignment
{
    [JsonProperty("role_id")]
    public string RoleId { get; set; }

    [JsonProperty("entity_id")]
    public string EntityId { get; set; }

    [JsonProperty("user_id")]
    public string UserId { get; set; }

    [JsonProperty("date_create")]
    public long DateCreated { get; set; }
}