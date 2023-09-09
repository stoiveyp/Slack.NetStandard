using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Apps
{
    public class ListActivitiesRequest:ListActivitiesRequestBase
    {
        public ListActivitiesRequest(string appId)
        {
            AppId = appId;
        }

        [JsonProperty("app_id")]
        public string AppId { get; set; }
    }
}
