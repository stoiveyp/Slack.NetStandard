using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.WebApi.Files;

public class CompleteExternalUploadRequest
{
    [JsonProperty("files")] public List<CompletedFile> Files { get; set; } = new();

    [JsonProperty("channel_id",NullValueHandling = NullValueHandling.Ignore)]
    public string ChannelId { get; set; }

    [JsonProperty("initial_comment",NullValueHandling = NullValueHandling.Ignore)]
    public string InitialComment { get; set; }

    [JsonProperty("thread_ts",NullValueHandling = NullValueHandling.Ignore)]
    public Timestamp ThreadTimestamp { get; set; }
    
    [JsonProperty("channels", NullValueHandling = NullValueHandling.Ignore)]
    public string Channels { get; set; }

    public bool ShouldSerializeFiles() => Files?.Any() ?? false;
}