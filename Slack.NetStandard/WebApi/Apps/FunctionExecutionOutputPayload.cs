using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class FunctionExecutionOutputPayload
{
    [JsonProperty("log")]
    public string Log { get; set; }
}