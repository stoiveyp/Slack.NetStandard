using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.Interaction
{
    public class ResponseActionPush : ResponseAction
    {
        public ResponseActionPush() { }

        public ResponseActionPush(View view)
        {
            View = view;
        }

        [JsonProperty("view")]
        public View View { get; set; }

        [JsonProperty("response_action")]
        public override string Type => "push";
    }
}