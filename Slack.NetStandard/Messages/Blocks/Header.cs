using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Header:IMessageBlock
    {
        public Header() { }

        public Header(string plainText) : this(new PlainText(plainText))
        {

        }

        public Header(PlainText text)
        {
            Text = text;
        }

        [JsonProperty("type")] public string Type => nameof(Header).ToLower();

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Text { get; set; }

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }
    }
}
