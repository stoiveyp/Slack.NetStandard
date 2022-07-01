using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.ApiCommon;
using Slack.NetStandard.EventsApi.CallbackEvents;

namespace Slack.NetStandard.Objects
{
    public class File:SlackId
    {
        [JsonProperty("created",NullValueHandling = NullValueHandling.Ignore)]
        public long? Created { get; set; }

        [JsonProperty("timestamp",NullValueHandling = NullValueHandling.Ignore)]
        public long? Timestamp { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("mimetype",NullValueHandling = NullValueHandling.Ignore)]
        public string Mimetype { get; set; }

        [JsonProperty("filetype",NullValueHandling = NullValueHandling.Ignore)]
        public string Filetype { get; set; }

        [JsonProperty("pretty_type",NullValueHandling = NullValueHandling.Ignore)]
        public string PrettyType { get; set; }

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("editable",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Editable { get; set; }

        [JsonProperty("size",NullValueHandling = NullValueHandling.Ignore)]
        public int? Size { get; set; }

        [JsonProperty("mode",NullValueHandling = NullValueHandling.Ignore)]
        public string Mode { get; set; }

        [JsonProperty("is_external",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsExternal { get; set; }

        [JsonProperty("external_type",NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalType { get; set; }

        [JsonProperty("is_public",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPublic { get; set; }

        [JsonProperty("public_url_shared",NullValueHandling = NullValueHandling.Ignore)]
        public bool? PublicUrlShared { get; set; }

        [JsonProperty("display_as_bot",NullValueHandling = NullValueHandling.Ignore)]
        public bool? DisplayAsBot { get; set; }

        [JsonProperty("username",NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("url_private",NullValueHandling = NullValueHandling.Ignore)]
        public string UrlPrivate { get; set; }

        [JsonProperty("url_private_download",NullValueHandling = NullValueHandling.Ignore)]
        public string UrlPrivateDownload { get; set; }

        [JsonProperty("thumb_64",NullValueHandling = NullValueHandling.Ignore)]
        public string Thumb64 { get; set; }

        [JsonProperty("thumb_80", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumb80 { get; set; }

        [JsonProperty("thumb_160", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumb160 { get; set; }

        [JsonProperty("thumb_360", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumb360 { get; set; }

        [JsonProperty("thumb_360_w", NullValueHandling = NullValueHandling.Ignore)]
        public int? Thumb360Width { get; set; }

        [JsonProperty("thumb_360_h", NullValueHandling = NullValueHandling.Ignore)]
        public int? Thumb360Height { get; set; }

        [JsonProperty("image_exif_rotation",NullValueHandling = NullValueHandling.Ignore)]
        public int? ImageExifRotation { get; set; }

        [JsonProperty("original_w", NullValueHandling = NullValueHandling.Ignore)]
        public int? OriginalWidth { get; set; }

        [JsonProperty("original_h", NullValueHandling = NullValueHandling.Ignore)]
        public int? OriginalHeight { get; set; }

        [JsonProperty("deanimate_gif",NullValueHandling = NullValueHandling.Ignore)]
        public string DeanimateGif { get; set; }

        [JsonProperty("pjpeg",NullValueHandling = NullValueHandling.Ignore)]
        public string Pjpeg { get; set; }
        
        [JsonProperty("permalink",NullValueHandling = NullValueHandling.Ignore)]
        public string Permalink { get; set; }

        [JsonProperty("permalink_public",NullValueHandling = NullValueHandling.Ignore)]
        public string PermalinkPublic { get; set; }

        [JsonProperty("comments_count",NullValueHandling = NullValueHandling.Ignore)]
        public int? CommentsCount { get; set; }

        [JsonProperty("is_starred",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsStarred { get; set; }

        [JsonProperty("has_rich_preview",NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasRichPreview { get; set; }

        [JsonProperty("shares",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,Dictionary<string,Share[]>> Shares { get; set; }

        [JsonProperty("reactions", NullValueHandling = NullValueHandling.Ignore),AcceptedArray]
        public Reaction[] Reactions { get; set; }
    }
}
