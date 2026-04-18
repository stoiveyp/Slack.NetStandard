using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.Messages.Blocks
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AlertLevel
    {
        [EnumMember(Value = "default")]
        Default,

        [EnumMember(Value = "info")]
        Info,

        [EnumMember(Value = "warning")]
        Warning,

        [EnumMember(Value = "error")]
        Error
    }
}
