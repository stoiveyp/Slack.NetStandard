using System.Runtime.Serialization;

namespace Slack.NetStandard.WebApi
{
    public enum SortDirection
    {
        [EnumMember(Value="asc")]
        Ascending,
        [EnumMember(Value="desc")]
        Descending
    }
}
