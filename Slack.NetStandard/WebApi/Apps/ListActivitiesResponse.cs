using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class ListActivitiesResponse : WebApiResponse<ResponseMetadataCursor>
{
    [JsonProperty("activities",NullValueHandling = NullValueHandling.Ignore)]
    public Activity[] Activities { get; set; }
}