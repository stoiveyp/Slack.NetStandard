using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi.Canvases
{
    public enum CanvasAccessLevel
    {
        [EnumMember(Value ="read")]
        Read,
        [EnumMember(Value ="write")]
        Write
    }
}
