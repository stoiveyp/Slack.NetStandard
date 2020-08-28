using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.Messages.TextEntities
{
    public class Unknown:TextEntity
    {
        public Unknown(string value)
        {
            Value = value;
        }
        public string Value { get; }
    }
}
