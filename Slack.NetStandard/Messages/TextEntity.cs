using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard.Messages
{
    public class TextEntity
    {
        public int TextIndex { get; set; }
        public int TextLength { get; set; }
        public string Label { get; set; }
    }
}
