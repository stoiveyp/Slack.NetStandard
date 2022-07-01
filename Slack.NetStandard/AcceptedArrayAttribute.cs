using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class AcceptedArrayAttribute:Attribute
    {
    }
}
