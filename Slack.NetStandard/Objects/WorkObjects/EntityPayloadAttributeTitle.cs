using Newtonsoft.Json;
using Slack.NetStandard.Objects.WorkObjects.Fields;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayloadAttributeTitle
    {
        public EntityPayloadAttributeTitle() { }
        public EntityPayloadAttributeTitle(string text)
        {
            Text = text;
        }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("edit", NullValueHandling = NullValueHandling.Ignore)]
        public EditOptions EditOptions { get; set; }
    }
}