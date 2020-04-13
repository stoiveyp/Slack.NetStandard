using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Slack.NetStandard.Objects
{
    public enum ChannelType
    {
        [EnumMember(Value="C")]
        Channel,
        [EnumMember(Value="G")]
        Group
    }
}
