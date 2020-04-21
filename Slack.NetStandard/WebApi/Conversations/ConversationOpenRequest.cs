using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class ConversationOpenRequest
    {
        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("users",NullValueHandling = NullValueHandling.Ignore)]
        public string Users { get; set; }
        
        [JsonProperty("return_im",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReturnIm { get; set; }

    }
}