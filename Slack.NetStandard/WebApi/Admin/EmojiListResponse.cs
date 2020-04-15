using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class EmojiListResponse:WebApiResponse
    {
        [JsonProperty("emoji",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,Emoji> Emoji { get; set; }

        [JsonProperty("cache_ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp CacheTimestamp { get; set; }

        [JsonProperty("categories_version",NullValueHandling = NullValueHandling.Ignore)]
        public string CategoriesVersion { get; set; }

        [JsonProperty("categories",NullValueHandling = NullValueHandling.Ignore)]
        public EmojiCategory[] Categories { get; set; }
    }
}
