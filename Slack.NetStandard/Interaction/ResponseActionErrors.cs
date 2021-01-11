using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class ResponseActionErrors : ResponseAction
    {
        public ResponseActionErrors(){}

        public ResponseActionErrors(Dictionary<string, string> errors)
        {
            Errors = errors;
        }

        [JsonProperty("errors")]
        public Dictionary<string, string> Errors { get; set; } = new ();

        [JsonProperty("response_action")]
        public override string Type => "errors";
    }
}