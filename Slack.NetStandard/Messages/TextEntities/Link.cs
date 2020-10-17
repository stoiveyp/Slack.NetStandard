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

        public static string Text(string uri, string label = null)
        {
            if (!string.IsNullOrWhiteSpace(label))
            {
                return $"<!{uri}|{label}>";
            }

            return $"<!{uri}>";
        }
    }
}
