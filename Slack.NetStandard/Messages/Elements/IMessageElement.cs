using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Messages.Elements
{
    [JsonConverter(typeof(MessageElementConverter))]
    public interface IMessageElement
    {
        [JsonProperty("type")]
        string Type { get; }
    }
}
