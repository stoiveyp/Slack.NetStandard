using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class BotMessage : MessageCallbackEvent
    {
        public const string MessageSubType = "bot_message";
    }
}