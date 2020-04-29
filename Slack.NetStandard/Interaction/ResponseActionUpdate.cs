using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.Interaction
{
    public class ResponseActionUpdate : ResponseAction
    {
        public ResponseActionUpdate() { }

        public ResponseActionUpdate(View view)
        {
            View = view;
        }

        [JsonProperty("view")]
        public View View { get; set; }

        [JsonProperty("response_action")]
        public override string Type => "update";
    }
}