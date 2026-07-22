using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class EnumChoice<T>
{
    public EnumChoice(T value, string title, string description)
    {
        Value = value;
        Title = title;
        Description = description;
    }

    [JsonProperty("value")]
    public T Value { get; set; }

    [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }

    [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }
}