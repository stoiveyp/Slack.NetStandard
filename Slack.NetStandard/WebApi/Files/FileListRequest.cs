using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Files
{
    public class FileListRequest
    {
        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty("show_files_hidden_by_limit",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowFilesHidenByLimit { get; set; }

        [JsonProperty("ts_from",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp From { get; set; }

        [JsonProperty("ts_to",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp To { get; set; }

        [JsonProperty("types",NullValueHandling = NullValueHandling.Ignore)]
        public string Types { get; set; }

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }
    }

    public class FileUploadRequest
    {
        [JsonProperty("channels",NullValueHandling = NullValueHandling.Ignore)]
        public string Channels { get; set; }

        [JsonProperty("content",NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonIgnore]
        public Stream File { get; set; }

        [JsonProperty("filename",NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }

        [JsonProperty("filetype",NullValueHandling = NullValueHandling.Ignore)]
        public string Filetype { get; set; }

        [JsonProperty("initial_comment",NullValueHandling = NullValueHandling.Ignore)]
        public string InitialComment { get; set; }

        [JsonProperty("thread_ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp ThreadTimestamp { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

    }
}
