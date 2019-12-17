using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Messages
{
    public interface IMessage
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        string Text { get; set; }

        [JsonProperty("blocks",NullValueHandling = NullValueHandling.Ignore)]
        IList<IMessageBlock> Blocks { get; set; }

        [JsonProperty("thread_ts",NullValueHandling = NullValueHandling.Ignore)]
        string ThreadId { get; set; }

        [JsonProperty("mrkdwn", NullValueHandling = NullValueHandling.Ignore)]
        bool? UseMarkdown { get; set; }
    }
}