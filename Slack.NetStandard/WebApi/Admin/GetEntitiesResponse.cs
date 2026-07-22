using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class GetEntitiesResponse:WebApiResponse
{
    [JsonProperty("entities")]
    public Entity[] Entities { get; set; }

    [JsonProperty("entity_total_count")]
    public int EntityTotalCount { get; set; }
}