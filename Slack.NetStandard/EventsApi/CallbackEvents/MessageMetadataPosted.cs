using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class MessageMetadataPosted: CallbackEvent
    {
        public const string EventType = "message_metadata_posted";
    }
}
