using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public enum ListAccessLevel
    {
        [EnumMember(Value = "read")]
        Read,
        [EnumMember(Value = "write")]
        Write,
        [EnumMember(Value = "owner")]
        Owner
    }
}
