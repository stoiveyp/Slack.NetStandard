using System;
using System.Collections.Generic;
using System.Text;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Messages
{
    public class Message:IMessage
    {
        public string Text { get; set; }
        public IList<IMessageBlock> Blocks { get; set; }
        public string ThreadId { get; set; }
        public bool? UseMarkdown { get; set; }
    }
}
