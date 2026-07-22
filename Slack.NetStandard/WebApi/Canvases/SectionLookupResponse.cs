using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Canvases
{
    public class SectionLookupResponse:WebApiResponse
    {
        [JsonProperty("sections", NullValueHandling = NullValueHandling.Ignore)]
        public SlackId[] Sections { get; set; }
    }
}
