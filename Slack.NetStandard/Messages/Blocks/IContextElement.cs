using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Messages.Blocks
{
    [JsonConverter(typeof(ContextElementConverter))]
    public interface IContextElement
    {

    }
}