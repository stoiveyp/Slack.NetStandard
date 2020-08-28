using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.Messages.TextEntities
{
    public class Link:TextEntity
    {
        public Link(string url)
        {
            Url = url;
        }
        public string Url { get; }
    }
}
