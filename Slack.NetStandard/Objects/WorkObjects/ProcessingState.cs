using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class ProcessingState
    {
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool Enabled { get; set; }

        [JsonProperty("interstitial_text", NullValueHandling = NullValueHandling.Ignore)] 
        public string InterstitialText { get; set; }
    }
}