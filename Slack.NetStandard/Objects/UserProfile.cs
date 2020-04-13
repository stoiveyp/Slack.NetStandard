using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class UserProfile
    {
        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("phone",NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonProperty("skype",NullValueHandling = NullValueHandling.Ignore)]
        public string Skype { get; set; }

        [JsonProperty("real_name",NullValueHandling = NullValueHandling.Ignore)]
        public string RealName { get; set; }

        [JsonProperty("real_name_normalized",NullValueHandling = NullValueHandling.Ignore)]
        public string RealNameNormalized { get; set; }

        [JsonProperty("display_name",NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("display_name_normalized",NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayNameNormalized { get; set; }

        [JsonProperty("status_text",NullValueHandling = NullValueHandling.Ignore)]
        public string StatusText { get; set; }

        [JsonProperty("status_emoji",NullValueHandling = NullValueHandling.Ignore)]
        public string StatusEmoji { get; set; }

        [JsonProperty("status_expiration",NullValueHandling = NullValueHandling.Ignore)]
        public long? StatusExpiration { get; set; }

        [JsonProperty("avatar_hash",NullValueHandling = NullValueHandling.Ignore)]
        public string AvatarHash { get; set; }

        [JsonProperty("first_name",NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty("last_name",NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty("email",NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("image_original",NullValueHandling = NullValueHandling.Ignore)]
        public string ImageOriginal { get; set; }

        [JsonProperty("image_24",NullValueHandling = NullValueHandling.Ignore)]
        public string Image24 { get; set; }

        [JsonProperty("image_32", NullValueHandling = NullValueHandling.Ignore)]
        public string Image32 { get; set; }

        [JsonProperty("image_48", NullValueHandling = NullValueHandling.Ignore)]
        public string Image48 { get; set; }

        [JsonProperty("image_72", NullValueHandling = NullValueHandling.Ignore)]
        public string Image72 { get; set; }

        [JsonProperty("image_192", NullValueHandling = NullValueHandling.Ignore)]
        public string Image192 { get; set; }

        [JsonProperty("image_512", NullValueHandling = NullValueHandling.Ignore)]
        public string Image512 { get; set; }


        [JsonProperty("team",NullValueHandling = NullValueHandling.Ignore)]
        public string Team { get; set; }


        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}