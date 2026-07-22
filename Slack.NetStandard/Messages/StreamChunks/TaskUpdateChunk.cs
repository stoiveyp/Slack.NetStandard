using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.Messages.Elements;
using System.Linq;

namespace Slack.NetStandard.Messages.StreamChunks;

public class TaskUpdateChunk : IStreamChunk
{
    public TaskUpdateChunk()
    {
        
    }
    
    public TaskUpdateChunk(string taskId)
    {
        TaskId = taskId;
    }
    
    public const string ElementType = "task_update";
    [JsonProperty("type")]
    public string Type => ElementType;
    
    [JsonProperty("id")]
    public string TaskId { get; set; }
    
    [JsonProperty("details",NullValueHandling = NullValueHandling.Ignore)]
    public string Details { get; set; }
    
    [JsonProperty("output",NullValueHandling = NullValueHandling.Ignore)]
    public string Output { get; set; }
    
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public TaskCardStatus Status { get; set; }
    
    [JsonProperty("sources", NullValueHandling = NullValueHandling.Ignore)]
    public IList<TaskCardSource> Sources { get; set; } = new List<TaskCardSource>();

    public bool ShouldSerializeSources() => Sources?.Any() ?? false;
}