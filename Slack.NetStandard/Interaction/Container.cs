﻿using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Interaction
{
    [JsonConverter(typeof(InteractionContainerConverter))]
    public class Container
    {

    }
}