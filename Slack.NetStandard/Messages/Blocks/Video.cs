using System;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Video:IMessageBlock
    {
        public Video()
        {
        }

        public Video(string title, string videoUrl, string thumbnailUrl, string altText)
        {
            Title = title;
            VideoUrl = videoUrl;
            ThumbnailUrl = thumbnailUrl;
            AltText = altText;
        }

        public string Type => nameof(Video).ToLower();

        [JsonProperty("alt_text", NullValueHandling = NullValueHandling.Ignore)]
        public string AltText { get; set; }

        [JsonProperty("author_name", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorName { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Description { get; set; }

        [JsonProperty("provider_icon_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ProviderIconUrl { get; set; }

        [JsonProperty("provider_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ProviderName { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Title { get; set; }

        [JsonProperty("title_url", NullValueHandling = NullValueHandling.Ignore)]
        public string TitleUrl { get; set; }

        [JsonProperty("thumbnail_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("video_url", NullValueHandling = NullValueHandling.Ignore)]
        public string VideoUrl { get; set; }
    }
}

