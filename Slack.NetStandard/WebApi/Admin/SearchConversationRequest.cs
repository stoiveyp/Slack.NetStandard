using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;

namespace Slack.NetStandard.WebApi.Admin;

public class SearchConversationRequest
{
    [JsonProperty("connected_team_ids", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> ConnectedTeamIds { get; set; } = new();

    [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
    public string Cursor { get; set; }

    [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    [JsonProperty("query",NullValueHandling = NullValueHandling.Ignore)]
    public string Query { get; set; }

    [JsonProperty("search_channel_types", NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
    public List<ConversationSearchChannelType> SearchChannelTypes { get; set; } = new();

    [JsonProperty("sort",NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ConversationSortMethod Sort { get; set; }

    [JsonProperty("sort_dir",NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SortDirection? SortDirection { get; set; }

    [JsonProperty("team_ids", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> TeamIds { get; set; } = new();

    public bool ShouldSerializeTeamIds() => TeamIds?.Any() ?? false;
    public bool ShouldSerializeSearchChannelTypes() => SearchChannelTypes?.Any() ?? false;
    public bool ShouldSerializeConnectedTeamIds() => ConnectedTeamIds?.Any() ?? false;
}