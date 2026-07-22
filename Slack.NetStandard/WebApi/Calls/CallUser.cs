using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.WebApi.Calls;

[JsonConverter(typeof(CallUserConverter))]
public class CallUser
{
}