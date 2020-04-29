using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class ResponseActionClear : ResponseAction
    {
        [JsonProperty("response_action")]
        public override string Type => "clear";
    }
}