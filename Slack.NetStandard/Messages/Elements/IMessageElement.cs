using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public interface IMessageElement
    {
        [JsonProperty("type")]
        string Type { get; }
    }
}
