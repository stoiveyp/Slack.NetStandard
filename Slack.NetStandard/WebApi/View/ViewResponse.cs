using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.View
{
    public class ViewResponse:WebApiResponse
    {
        [JsonProperty("view",NullValueHandling = NullValueHandling.Ignore)]
        public Objects.View View { get; set; }
    }
}
