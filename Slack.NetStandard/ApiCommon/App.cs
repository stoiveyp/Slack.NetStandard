using Newtonsoft.Json;

namespace Slack.NetStandard.ApiCommon
{
    public class App
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        
        [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("help_url", NullValueHandling = NullValueHandling.Ignore)]
        public string HelpUrl { get; set; }

        [JsonProperty("privacy_policy_url",NullValueHandling = NullValueHandling.Ignore)]
        public string PrivacyPolicyUrl { get; set; }

        [JsonProperty("app_homepage_url",NullValueHandling = NullValueHandling.Ignore)]
        public string AppHomepageUrl { get; set; }

        [JsonProperty("app_directory_url",NullValueHandling = NullValueHandling.Ignore)]
        public string AppDirectoryUrl { get; set; }

        [JsonProperty("is_app_directory_approved", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAppDirectoryApproved { get; set; }

        [JsonProperty("is_internal",NullValueHandling = NullValueHandling.Ignore)]
        public bool IsInternal { get; set; }

        [JsonProperty("additional_info",NullValueHandling = NullValueHandling.Ignore)]
        public string AdditionalInfo { get; set; }
    }
}