using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class EkmAccessDenied : MessageCallbackEvent
    {
        public const string MessageSubType = "ekm_access_denied";
    }
}