using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.MessageBlocks
{
    public interface IMessageBlock
    {
        [JsonProperty("type")]
        string Type { get; }

    }
}
