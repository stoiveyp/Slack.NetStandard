using Newtonsoft.Json;
using Slack.NetStandard.Objects.Workflows;

namespace Slack.NetStandard.WebApi.Admin;

public class FunctionListResponse : WebApiResponse<ResponseMetadataCursor>
{
    [JsonProperty("functions",NullValueHandling = NullValueHandling.Ignore)]
    public Function[] Functions { get; set; }
}