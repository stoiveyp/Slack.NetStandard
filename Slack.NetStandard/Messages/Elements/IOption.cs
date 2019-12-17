using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Messages.Elements
{
    [JsonConverter(typeof(OptionConverter))]
    public interface IOption
    {
    }
}